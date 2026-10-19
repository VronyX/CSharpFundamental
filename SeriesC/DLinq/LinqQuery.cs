using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesC.DLinq;

public class LinqQuery
{
    public static void Introduction()
    {
        var employees = SampleData.GetEmployees();
        var departments = SampleData.GetDepartments();

        // Tanpa LINQ, nama karyawan dengan gaji diatas 8 juta
        var names = new List<string>();
        foreach (var employee in employees)
        {
            if (employee.Salary > 8000000)
            {
                names.Add(employee.Name);
            }
        }
        Console.WriteLine($"Tanpa LINQ: {names.Count} employees.");

        // LINQ
        var names2 = employees
            .Where(e => e.Salary > 8000000)
            .Select(e => e.Name)
            .ToList();
        Console.WriteLine($"Dengan LINQ: {names2.Count} employees.");

        // LINQ pada collection lain
        int[] numbers = { 5, 7, 8, 9, 12, 4 };
        Console.WriteLine($"Array, jumlah genap: {numbers.Where(n => n % 2 == 0).Count()}");
        //Console.WriteLine($"Array, jumlah genap: {numbers.Count(n => n % 2 == 0)}"); // Alternatif

        // Deferred Function, query tidak dijalankan saat ditulis, tetapi hasilnya dipakai
        // contohnya :(foreach, count, ToList, dsb)

        List<int> scores = new List<int>()
        {
            60, 90, 85
        };

        var passed = scores.Where(s => s >= 75); // dijalankannya saat di panggil
        scores.Add(100);
        Console.WriteLine($"Lulus: {passed.Count()}"); // 3 bukan 2, nilai 100 ikut terhitung
        var passedList = scores.Where(s => s >= 75).ToList();
        scores.Add(95);
        Console.WriteLine($"Lulus (ToList): {passedList.Count()}"); // tetap 3, nilai 95 tidak terhitung
        Console.WriteLine($"Lulus (Query): {passed.Count()}"); // jadi 4, nilai 95 terhitung
    }

    public static void Transformation()
    {
        var employees = SampleData.GetEmployees();

        // Select, mengambil satu property
        var names = employees.Select(e => e.Name);
        Console.WriteLine($"Nama: {string.Join(", ", names)}"); // string.Join menggabung data dengan pemisah (wajib string)

        // Select, dengan perhitungan
        var annualSalaries = employees.Select(e => e.Salary * 12);
        Console.WriteLine($"Gaji tahunan pertama: {annualSalaries.First()}");

        // Select, dengan anonymous type, jika perlu untuk beberapa property
        var summaries = employees.Select(e => new Summary
        {
            Name = e.Name,
            AnnualSalary = e.Salary * 12,
            YearOfService = DateTime.Now.Year - e.JoinYear
        }).ToList();

        foreach (var employee in summaries)
        {
            Console.WriteLine($"{employee.Name} : {employee.AnnualSalary} : {employee.YearOfService}");
        }
    }

    public static void Grouping()
    {
        var employees = SampleData.GetEmployees();
        var groups = employees.GroupBy(e => e.DepartmentId);
        foreach (var group in groups)
        {
            Console.WriteLine($"Department: {group.Key} : {group.Count()} Karyawan");
            foreach (var employee in group)
            {
                Console.WriteLine($"Name: {employee.Name}");
            }
        }
    }

    public static void Joining()
    {
        var employees = SampleData.GetEmployees();
        var departments = SampleData.GetDepartments();

        // Inner Join
        var innerJoin = employees
            .Join(departments,
            e => e.DepartmentId, d => d.Id,
            (e, d) => new
            {
                EmployeeId = e.Id,
                Name = e.Name,
                Department = d.Name
            });

        foreach (var employee in innerJoin)
        {
            Console.WriteLine($"{employee.EmployeeId} : {employee.Name} : {employee.Department}");
        }
    }

    // Groupiong + Join, total gaji per nama department
    public static void GroupAndJoin()
    {
        var employees = SampleData.GetEmployees();
        var departments = SampleData.GetDepartments();

        var innerJoin = employees
            .Join(departments,
            e => e.DepartmentId, d => d.Id,
            (e, d) => new
            {
                Department = d.Name,
                Salary = e.Salary
            });

        var grouping = innerJoin
            .GroupBy(g => g.Department)
            .Select(g => new 
            {
                Department = g.Key,
                Total = g.Sum(e => e.Salary)
            });

        foreach (var department in grouping)
        {
            Console.WriteLine($"{department.Department} : {department.Total}");
        }
    }
}
