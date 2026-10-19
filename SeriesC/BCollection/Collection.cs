namespace SeriesC.BCollection;

public class Collection
{
    public static void ListCollection()
    {
        // Membuat list kosong
        List<string> courses = new List<string>();

        // Membuat list langsung dengan isi
        List<int> scores = new List<int>
        {
            10, 15, 12,
        };

        courses.Add("SQL Server"); // index akhir
        courses.Add("React.ts");
        courses.Add("C#");
        courses.Insert(0, "Class Diagram"); // di index tertentu

        // Akses Data
        Console.WriteLine("Index 0: " + courses[0]);

        // Modifikasi Data
        courses[3] = "C# Fundamental";

        // Jumlah Data
        Console.WriteLine("Total: " + courses.Count);

        // Cari Data
        Console.WriteLine("Ada C#: " + courses.Contains("C#"));
        Console.WriteLine("Lokasi index C#: " + courses.IndexOf("C#"));

        Console.WriteLine("===================");
        foreach (string course in courses)
        {
            Console.WriteLine("Course : " + course);
        }
        Console.WriteLine("===================");

        // Urutkan Data
        scores.Sort();
        Console.WriteLine("Nilai terendah: " + scores[0]);

        // Hapus semua data
        courses.Clear();
        Console.WriteLine("Jumlah Courses: " + courses.Count);
    }
}
