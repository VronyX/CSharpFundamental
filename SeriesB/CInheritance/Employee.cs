namespace SeriesB.CInheritance;

public class Employee : Person
{
    public int Salary
    {
        get;
        set
        {
            if (value <= 0)
            {
                Console.WriteLine("Salary must be greater than 0");
            }
            else
            {
                field = value;
            }
        }
    }

    public int AnnualSalary
    {
        get
        {
            return Salary * 12;
        }
        set;
    }

    public int AnnualSalary2 => Salary * 12;

    public Employee(int id)
    {
        this.Id = id;
    }

    public void Introduction()
    {
        Console.WriteLine("EmployeeId: " + Id);
        Console.WriteLine("EmployeeName: " + FullName);
        Console.WriteLine("EmployeeAge: " + Age);
        Console.WriteLine("Password: " + Password);
        Console.WriteLine("Salary: " + Salary);
    }
}
