using System.Text;
using System.Text.Json;

namespace SeriesC.FFileHandling;

public class FileHandling
{
    /* File Handling, membaca dan menulis data ke file agar data tidak hilang saat program ditutup
     * Berada di namespace System.IO
     *
     * Path      -> mengolah teks alamat file (tidak menyentuh file-nya)
     * Directory -> membuat, memeriksa, dan menghapus folder
     * File      -> membuat, membaca, menulis, menyalin, dan menghapus file
     */

    // Semua file contoh disimpan di folder Data, di sebelah file hasil build (bin)
    // AppContext.BaseDirectory, alamat folder tempat program berjalan
    static string folder = Path.Combine(AppContext.BaseDirectory, "Data");

    public static void FileDirectoryPath()
    {
        // #1 Path
        // Path.Combine, menggabung alamat dengan pemisah yang sesuai sistem operasi
        // (\ pada Windows, / pada Linux dan macOS). Hindari menggabung dengan + "\\"
        string filePath = Path.Combine(folder, "employees.txt");

        Console.WriteLine("Alamat : " + filePath);
        Console.WriteLine("GetFileName : " + Path.GetFileName(filePath));
        Console.WriteLine("GetFileNameWithoutExtension : " + Path.GetFileNameWithoutExtension(filePath));
        Console.WriteLine("GetExtension : " + Path.GetExtension(filePath));
        Console.WriteLine();

        // #2 Directory
        // CreateDirectory tidak error jika folder sudah ada
        Directory.CreateDirectory(folder);
        Console.WriteLine("Folder ada : " + Directory.Exists(folder));

        // #3 File
        // WriteAllLines, menulis tiap data sebagai satu baris. File lama ditimpa
        string[] names = { "Andi", "Budi", "Citra" };
        File.WriteAllLines(filePath, names);

        // AppendAllText, menambah teks di akhir file tanpa menghapus isi lama
        // Environment.NewLine, tanda pindah baris yang sesuai sistem operasi
        File.AppendAllText(filePath, "Dewi" + Environment.NewLine);

        Console.WriteLine("File ada : " + File.Exists(filePath));

        // ReadAllText, membaca seluruh isi file sebagai satu string
        string content = File.ReadAllText(filePath);
        Console.WriteLine("Jumlah karakter : " + content.Length);

        // ReadAllLines, membaca seluruh isi file sebagai array per baris
        string[] lines = File.ReadAllLines(filePath);
        foreach (string line in lines)
        {
            Console.WriteLine("Baris : " + line);
        }

        // Copy dan Move, true artinya file tujuan ditimpa jika sudah ada
        string backupPath = Path.Combine(folder, "employees-backup.txt");
        string archivePath = Path.Combine(folder, "employees-archive.txt");

        File.Copy(filePath, backupPath, true);
        File.Move(backupPath, archivePath, true);   // Move juga dipakai untuk rename

        // GetFiles, daftar file di dalam folder
        foreach (string file in Directory.GetFiles(folder))
        {
            Console.WriteLine("Isi folder : " + Path.GetFileName(file));
        }

        // Delete tidak error jika file tidak ada
        File.Delete(archivePath);
        Console.WriteLine("Archive ada setelah dihapus : " + File.Exists(archivePath));

        // Membaca file yang tidak ada menghasilkan exception
        try
        {
            File.ReadAllText(Path.Combine(folder, "tidak-ada.txt"));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("File tidak ditemukan");
        }

        // Directory.Delete(folder, true) menghapus folder beserta seluruh isinya
    }

    public static void Streams()
    {
        /* Stream, aliran data yang dibaca atau ditulis sedikit demi sedikit
         * File.ReadAllText memuat seluruh isi file ke memory, cocok untuk file kecil
         * Stream cocok untuk file besar karena data diproses per bagian
         *
         * FileStream   -> membaca dan menulis byte
         * StreamWriter -> menulis teks
         * StreamReader -> membaca teks
         *
         * using, memastikan stream ditutup (Dispose) saat blok selesai,
         * termasuk ketika terjadi exception. Sama seperti try-finally yang memanggil Dispose
         * File yang tidak ditutup tetap terkunci dan tidak bisa dibuka program lain
         */

        Directory.CreateDirectory(folder);

        // #1 FileStream
        string binaryPath = Path.Combine(folder, "data.bin");

        // FileMode.Create, membuat file baru atau menimpa file lama
        using (FileStream stream = new FileStream(binaryPath, FileMode.Create))
        {
            // File hanya menyimpan byte, teks harus dirubah menjadi byte lebih dulu
            byte[] bytes = Encoding.UTF8.GetBytes("HRIS");
            stream.Write(bytes, 0, bytes.Length);
        }

        // FileMode.Open, membuka file yang sudah ada
        using (FileStream stream = new FileStream(binaryPath, FileMode.Open))
        {
            byte[] buffer = new byte[stream.Length];
            int totalRead = stream.Read(buffer, 0, buffer.Length);

            Console.WriteLine("Jumlah byte : " + totalRead);
            Console.WriteLine("Byte pertama : " + buffer[0]);   // 72, kode huruf H
            Console.WriteLine("Teks : " + Encoding.UTF8.GetString(buffer));
        }

        // #2 StreamWriter
        string logPath = Path.Combine(folder, "attendance.log");

        using (StreamWriter writer = new StreamWriter(logPath))     // file lama ditimpa
        {
            writer.WriteLine("08:00 Andi masuk");
            writer.WriteLine("08:05 Budi masuk");
        }

        // true, menambah di akhir file (append)
        using (StreamWriter writer = new StreamWriter(logPath, true))
        {
            writer.WriteLine("17:00 Andi pulang");
        }

        // #3 StreamReader
        using (StreamReader reader = new StreamReader(logPath))
        {
            // ReadLine membaca satu baris, mengembalikan null jika sudah di akhir file
            string? line;
            int lineNumber = 1;

            while ((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(lineNumber + " : " + line);
                lineNumber++;
            }
        }

        // ReadToEnd, membaca semua sisa isi file
        using (StreamReader reader = new StreamReader(logPath))
        {
            string content = reader.ReadToEnd();
            Console.WriteLine("Jumlah karakter : " + content.Length);
        }

        // Setelah blok using selesai, stream sudah ditutup sehingga file bisa dihapus
        File.Delete(binaryPath);
        Console.WriteLine("File data.bin dihapus : " + !File.Exists(binaryPath));
    }

    public static void Serialization()
    {
        /* Serialization   -> merubah object menjadi teks agar bisa disimpan ke file atau dikirim
         * Deserialization -> merubah teks kembali menjadi object
         *
         * Format yang paling umum adalah JSON, memakai class JsonSerializer
         * dari namespace System.Text.Json
         *
         * Yang ikut diproses hanya property public
         * Class harus punya constructor tanpa parameter agar bisa di deserialize
         */

        Directory.CreateDirectory(folder);

        // #1 Serialize satu object
        Employee employee = new Employee(1, "Andi", 1, 9000000, 2019);

        string json = JsonSerializer.Serialize(employee);
        Console.WriteLine(json);

        // WriteIndented, JSON ditulis dengan baris dan indentasi agar mudah dibaca
        JsonSerializerOptions options = new JsonSerializerOptions();
        options.WriteIndented = true;

        Console.WriteLine(JsonSerializer.Serialize(employee, options));

        // #2 Deserialize satu object
        // Hasilnya bisa null (misal isi JSON adalah null), sehingga perlu diperiksa
        Employee? result = JsonSerializer.Deserialize<Employee>(json);
        if (result != null)
        {
            Console.WriteLine("Deserialize : " + result.Name + " " + result.Salary);
        }

        // #3 Menyimpan List ke file JSON
        string jsonPath = Path.Combine(folder, "employees.json");
        List<Employee> employees = SampleData.GetEmployees();

        File.WriteAllText(jsonPath, JsonSerializer.Serialize(employees, options));
        Console.WriteLine("Tersimpan di : " + jsonPath);

        // #4 Membaca file JSON menjadi List
        string fileContent = File.ReadAllText(jsonPath);
        List<Employee>? loaded = JsonSerializer.Deserialize<List<Employee>>(fileContent);

        if (loaded != null)
        {
            Console.WriteLine("Jumlah data dari file : " + loaded.Count);
            Console.WriteLine("Data terakhir : " + loaded[loaded.Count - 1].Name);
        }

        // #5 JSON yang tidak valid menghasilkan exception
        try
        {
            JsonSerializer.Deserialize<Employee>("{ Name : Andi }");
        }
        catch (JsonException)
        {
            Console.WriteLine("Format JSON tidak valid");
        }

        // Nama property pada JSON harus sama persis dengan nama property class (case sensitive)
        // Agar huruf besar kecil diabaikan : options.PropertyNameCaseInsensitive = true
    }
}
