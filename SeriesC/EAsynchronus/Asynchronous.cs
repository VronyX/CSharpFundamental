using System.Diagnostics;

namespace SeriesC.EAsynchronus;

public class Asynchronous
{
    /*
     * Asynchronous, memulai Task tanpa membuat Thread diam menunggu sampai task-nya selesai
     * Dipakai untuk task yang banyak menunggu: baca file, query database, API call
     * 
     * Thread > membuat dan mengatur Thread sendiri (Start, Join)
     * Task > mewakili pekerjaan yang hasilnya bisa disediakan nanti.
     *          Thread diambil dari thread pool, bisa return nilai dan membawa exception
     *          
     * async/await > cara menulis kode asynchronous agar terbaca seperti kode biasa
     */

    public static void TaskClass()
    {
        Console.WriteLine($"Main Thread: {Thread.CurrentThread.ManagedThreadId}");

        // #1 Task.Run, menjalankan pekerjaan di thread lain dari thread pool
        Task task = Task.Run(() =>
        {
            Console.WriteLine($"Task berjalan di thread: {Thread.CurrentThread.ManagedThreadId}");
            Thread.Sleep(500);
        });

        // Wait, menunggu task selesai (seperti join pada thread)
        task.Wait();
        Console.WriteLine($"Status: {task.Status}");

        // #2 Task<T>, task yang mengembalikan nilai
        Task<int> salaryTask = Task.Run(() => CalculateSalary(8000000, 150000));

        // Result, menunggu task selesai lalu mengambil hasil type
        int salary = salaryTask.Result;
        Console.WriteLine($"Salary: {salary}");

        // #3 Menjalankan beberapa Task sekaligus
        var stopwatch = Stopwatch.StartNew();
        Task<int> task1 = Task.Run(() => CalculateSalary(8000000, 150000));
        Task<int> task2 = Task.Run(() => CalculateSalary(6500000, 50000));
        Task<int> task3 = Task.Run(() => CalculateSalary(12000000, 200000));

        // WaitAll, menunggu semua task selesai
        Task.WaitAll(task1, task2, task3);
        // WaitAny, WhenAll, WhenAny, WhenEach
        // Wait > synchronous, blocking thread -> menunggu task hingga benar benar selesai (deadlock)
        // When > asynchronous, non-block thread -> bisa mengerjakan task lain ketika task sedang berlangsung
        // All > menunggu semua task selesai dan dijalankan secara bersamaan
        // Any > salah satu dari task yang selesai
        // Each > menjalankan task secara berurutan dan hingga selesai

        stopwatch.Stop();
        Console.WriteLine($"Total Payroll: {task1.Result + task2.Result + task3.Result}");
        Console.WriteLine($"Total elapsed: {stopwatch.ElapsedMilliseconds}ms");

        // #4 Exception dalam task
        Task<int> failedTask = Task.Run(() => CalculateSalary(-1, 0));
        try
        {
            failedTask.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine($"Satus: {failedTask.Status}");
            Console.WriteLine($"Error: {ex.InnerException?.Message}");
        }

        // Wait dan Result membuat thread call diam menunggu (blocking)
        // Cara menunggu tanpa blocking adalah await
    }

    public static int CalculateSalary(int baseSalary, int allowance)
    {
        if (baseSalary < 0) throw new ArgumentException("Gaji pokok tidak boleh negatif");

        Thread.Sleep(500);
        return baseSalary + allowance;
    }

    public static async Task AsyncAwait()
    {
        /*
         * async > menandai method sebagai asynchronous sehingga boleh memakai await
         * await > menunggu task selesai tanpa membuat thread diam (non-blocking)
         * 
         * Selama menunggu, thread dilepas(release) dan bisa mengerjakan hal lain
         * 
         * Return Type method async
         * Task > tidak mengembalikan nilai (void)
         * Task<T> > mengembalikan nilai bertipe T
         * 
         * Nama method async wajib diakhiri dengan kata Async
         */

        // #1 Await
        Console.WriteLine($"Before await, thread: {Thread.CurrentThread.ManagedThreadId}");

        string name = await GetEmployeeNameAsync(1);
        // Setelah await, kode bisa dilanjutkan oleh thread yang berbeda
        Console.WriteLine($"After await, thread : {Thread.CurrentThread.ManagedThreadId}");
        Console.WriteLine($"Name: {name}");

        // #2 await 1 per 1
        Stopwatch stopwatch = Stopwatch.StartNew();
        string employee = await GetEmployeeNameAsync(1);
        int leave = await GetLeaveBalanceAsync(1);

        stopwatch.Stop();
        Console.WriteLine($"Employee ID: {employee} - leave: {leave}. Time: {stopwatch.ElapsedMilliseconds}ms");

        // #3 memulai semua Task lebih dulu, baru di tunggu bersama
        stopwatch.Restart();

        var employeeTask = GetEmployeeNameAsync(3);
        var leaveTask = GetLeaveBalanceAsync(3);

        await Task.WhenAll(employeeTask, leaveTask); //WhenAll, versi async dari WaitAll

        // await pada task yang sudah selesai langsugn mengembalikan hasilnya
        employee = await employeeTask;
        leave = await leaveTask;

        stopwatch.Stop();
        Console.WriteLine($"Employee ID: {employee} - leave: {leave}. Time: {stopwatch.ElapsedMilliseconds}ms");

        // #4 Exception
        // Dengan await, exception asli langsung diterima tanpa AggregateException
        try
        {
            await GetLeaveBalanceAsync(-1);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        /*
         * Hal yang perlu dihindari
         * - async void, exception didalamnya tidak bisa ditangkap pemanggil. Pakai async Task
         * - Result dan Wait didalam method async, thread menjadi blocking. Pakai Await
         * - Lupa menulis await, method lanjut sebelum pekerjaan selesai
         */
    }

    public static async Task<string> GetEmployeeNameAsync(int id)
    {
        await Task.Delay(1000);

        return "Employee " + id;
    }

    public static async Task<int> GetLeaveBalanceAsync(int id)
    {
        await Task.Delay(1000);
        if (id < 0)
        {
            throw new ArgumentException("Id tidak boleh negatif");
        }
        return 12;
    }

    public static async Task Cancelation()
    {
        /*
         * Cancellation, membatalkan pekerjaan asynchronous yang sedang berjalan
         * Contoh: user menekan tombol batal, atau proses melebihi batas waktu
         * 
         * CancellationTokenSource > pihak yang meminta pembatalan (cancel)
         * CancellationToken > dikirim ke method, dipakai untuk memeriksa permintaan batal
         * 
         * Pembatalan itu bersifat kerjasama, task tidak akan dihentikan paksa
         * Method yang menerima token harus memeriksa token itu sendiri
         */

        // #1 Cancellation Manual
        CancellationTokenSource cts = new CancellationTokenSource();
        Task payrollTask = ProcessPayrollAsync(10, cts.Token);

        await Task.Delay(1200, cts.Token);
        Console.WriteLine("Permintaan Batal");
        cts.Cancel();

        try
        {
            await payrollTask;
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine($"Process Payroll Dibatalkan: {ex.Message}");
        }

        // #2 CancelAfter, batal otomatis setelah batas waktu (timeout)
        CancellationTokenSource cts2 = new CancellationTokenSource();
        cts2.CancelAfter(1200);

        try
        {
            await ProcessPayrollAsync(10, cts2.Token);
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine("Process payroll melebihi batas waktu 1200ms");
        }
        finally
        {
            cts2.Dispose();
            Console.WriteLine();
        }

        // #3 Tidak dibatalkan, process berjalan sampai selesai
        CancellationTokenSource cts3 = new CancellationTokenSource();
        await ProcessPayrollAsync(10, cts3.Token);
        Console.WriteLine("Process Payroll Selesai");
        cts3.Dispose();
    }

    public static async Task ProcessPayrollAsync(int totalEmployees, CancellationToken cancellationToken)
    {
        for (int i = 0; i < totalEmployees; i++)
        {
            // Melempar OperationCancelledException jika pembatalan sudah diminta
            cancellationToken.ThrowIfCancellationRequested();

            // Token diteruskan ke method asynchronous lain agar ikut dibatalkan
            await Task.Delay(500, cancellationToken);

            Console.WriteLine($"Payroll Employee ID: {i}");
        }
    }
}
