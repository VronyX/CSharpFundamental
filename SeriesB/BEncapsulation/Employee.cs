namespace SeriesB.BEncapsulation;

/*
 * Encapsulation, menyembunyikan data didalam class dan hanya membuka jalur yang dikontrol oleh class itu sendiri
 * melalui Access Modifier, agar data tidak dapat diisi dengan nilai dari luar class
 * 
 * Access Modifier:
 * public -> bisa diakses dari mana saja dan siapa saja
 * private -> hanya bisa diakses dari dalam class (default)
 * internal -> bisa diakses siapa saja selama masih 1 project yang sama
 * protected -> bisa diakses oleh kelas turunannya saja
 */
public class Employee
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Id { private get; set; }
    private string password;
    public int Salary {
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

    //private int salary;

    //public void SetSalary(int salary)
    //{
    //    if (salary <= 0)
    //    {
    //        Console.WriteLine("Salary must be greater than 0");
    //    }
    //    else
    //    {
    //        this.salary = salary;
    //    }
    //}

    //public int GetSalary()
    //{
    //    return this.salary;
    //}

    //public int GetId()
    //{
    //    return id;
    //}

    public void SetPassword(string password)
    {
        this.password = password;
    }

    public int AnnualSalary // Hanya butuh get yang dimodif dan set default
    {
        get
        {
            return Salary * 12;
        }
        set;
    }

    public int AnnualSalary2 => Salary * 12; // Hanya butuh get yang dimodif

    public Employee(int id)
    {
        this.Id = id;
    }

    public void Introduction()
    {
        Console.WriteLine("EmployeeId: " + Id);
        Console.WriteLine("EmployeeName: " + FullName);
        Console.WriteLine("EmployeeAge: " + Age);
        Console.WriteLine("Password: " + password);
        Console.WriteLine("Salary: " + Salary);
    }
}
