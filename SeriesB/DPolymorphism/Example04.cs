namespace SeriesB.DPolymorphism;

public class Example04
{
    public void PolymorphismExample()
    {
        Person fran = new Person()
        {
            FullName = "Fran Dello",
            Age = 22,
            Password = "1234",
            //Id = 123 ketolak access modifier
        };

        Person wowo = new Person("wowo", 60, "4321");
        wowo.Introduction();
        Console.WriteLine();

        fran.Introduction();
        Console.WriteLine();

        fran.Introduction("Prabowo", 60);
        Console.WriteLine();

        //Employee dello = new Employee(12345678)
        //{
        //    FullName = "Dello Fran",
        //    Age = 22,
        //    Password = "1234",
        //    Salary = 100
        //};
        //dello.Introduction();
    }
}
