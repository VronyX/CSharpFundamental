namespace SeriesC.FFileHandling;

public class SampleData
{
    public static List<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new Employee(1, "Andi", 1, 9000000, 2019),
            new Employee(2, "Budi", 2, 6500000, 2021),
            new Employee(3, "Citra", 1, 12000000, 2017),
            new Employee(4, "Dewi", 3, 8000000, 2020),
            new Employee(5, "Eka", 1, 7000000, 2023),
            new Employee(6, "Fajar", 2, 6500000, 2018),
            new Employee(7, "Gita", 3, 10000000, 2016)
        };
    }
}
