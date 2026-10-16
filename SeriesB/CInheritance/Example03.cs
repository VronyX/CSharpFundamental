namespace SeriesB.CInheritance;

public class Example03
{
    public void InheritanceExample()
    {
        Person fran = new Person()
        {
            FullName = "Fran Dello",
            Age = 22,
            Password = "1234",
            //Id = 123 ketolak access modifier
        };

        fran.Introduction();
        Console.WriteLine();

        Employee dello = new Employee(12345678)
        {
            FullName = "Dello Fran",
            Age = 22,
            Password = "1234",
            Salary = 100
        };
        dello.Introduction();
    }
}
