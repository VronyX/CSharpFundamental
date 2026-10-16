namespace SeriesB.DPolymorphism;

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

    public override int Age { get => base.Age; set => base.Age = value; }

    public Employee(int id, string fullName, int age, int salary, string password) : base(fullName, age, password)
    {
        Id = id;
        Salary = salary;
        Password = password;
    }

    public override void Introduction()
    {
        Console.WriteLine("EmployeeID: " + Id);
        base.Introduction();
        Console.WriteLine("Salary: " + Salary);
    }
}
