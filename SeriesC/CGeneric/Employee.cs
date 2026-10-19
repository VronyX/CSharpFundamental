namespace SeriesC.CGeneric;

public class Employee<TId>
{
    public TId Id { get; set; }
    public string FullName { get; set; }
    public decimal Salary { get; set; }
    public string Job { get; set; }

    public void Introduction()
    {
        Console.WriteLine("===================");
        Console.WriteLine("ID: " + Id);
        Console.WriteLine("NAME: " + FullName);
        Console.WriteLine("SALARY: " + Salary);
        Console.WriteLine("JOB: " + Job);
    }

    public decimal CalculateTax()
    {
        decimal tax = 2.5m;

        return Salary * tax;
    }
}
