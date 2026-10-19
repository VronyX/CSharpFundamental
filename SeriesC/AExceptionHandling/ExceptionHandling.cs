namespace SeriesC.AExceptionHandling;

/*
 * Exception, error yang terjadi saat program berjalan (runtime), bukan saat compile
 * Jika tidak ditangani, program akan berhenti (crash)\
 * 
 * Semua Exception adalah class turunan dari System.Exception (inheritance)
 */
public class ExceptionHandling
{
    public static void TryCatchFinally()
    {
        string[] inputs = { "4", "0", "abc" };
        foreach (string input in inputs)
        {
            Console.WriteLine("Input: " + input);

            // try, kode yang berpotensi error
            try
            {
                int divisor = int.Parse(input);
                int result = 100 / divisor;
                Console.WriteLine("Result: " + result);
            }
            // catch, akan dijalankan jika terjadi error, boleh lebih dari satu
            catch (FormatException ex)
            {
                Console.WriteLine("Input harus berupa angka");
                Console.WriteLine(ex.Message);
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine("Pembagi tidak boleh 0");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error yang tidak diketahui");
                Console.WriteLine(ex.Message);
            }
            // finally, akan selalu dijalankan 
            finally
            {
                Console.WriteLine("Proses selesai");
                Console.WriteLine();
            }

            /*
             * Message, pesan error
             * StackTrace, lokasi terjadinya error (class, method, baris)
             * GetType, jenis exception
             */

        }
    }

    public static void OtherException()
    {
        // NullReferenceException
        try
        {
            string[] names = new string[2];
            Console.WriteLine(names[0].Length);
        }
        catch (NullReferenceException ex)
        {
            Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            Console.WriteLine();
        }

        // InvalidCastException
        try
        {
            object value = "sertaus";
            int number = (int)value;
            Console.WriteLine(number);
        }
        catch (InvalidCastException ex)
        {
            Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            Console.WriteLine();
        }

        // OverflowException
        try
        {
            int big = 300;
            byte small = Convert.ToByte(big);
            Console.WriteLine(small);
        }
        catch (OverflowException ex)
        {
            Console.WriteLine(ex.GetType().Name + ": " + ex.Message);
            Console.WriteLine();
        }
    }

    public static void ThrowKeyword()
    {
        /* Throw, melempar exception secara sengaja, 
         * dipakai saat data tidak sesuai aturan program, walaupun menurut C# tidak error
         * Format : throw new JenisException("Pesan")
         */

        #region Throw
        try
        {
            SetAge(20);
            SetAge(-5);
            SetAge(30); // Tidak akan dijalankan
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
            Console.WriteLine();
        }
        #endregion

        #region ReThrow
        try
        {
            int average = CalculateAverage(100, 0);
            Console.WriteLine("Average: " + average);
        }
        catch (DivideByZeroException ex)
        {
            Console.WriteLine("Error diterima oleh re-throw: " + ex.Message);
            Console.WriteLine();
        }
        #endregion
    }

    public static void SetAge(int age)
    {
        if (age < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(age), "must be greater than 0");
        }

        Console.WriteLine("Umur: " + age);
    }

    public static int CalculateAverage(int total, int count)
    {
        try
        {
            return total / count;
        }
        catch (DivideByZeroException)
        {
            Console.WriteLine("{LOG} Gagal menghitung rata-rata");

            throw; // stack trace tetap utuh
            //throw ex > stack trace bakal reset
        }
    }
}
