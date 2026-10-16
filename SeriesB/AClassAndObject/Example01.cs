namespace SeriesB.AClassAndObject;

public class Example01
{
    public void ClassObjectExample()
    {
        Person dello = new Person();

        dello.name = "Fran Dello";
        dello.age = 22;

        dello.Introduction();

        Person fran = new Person()
        {
            name = "Dello Fran",
            age = 22
        };

        fran.Introduction();

        Person wowo = new Person("Prabowo Subianto", 60);
        wowo.Introduction();

        // Static member dipanggil lewat nama class, bukan lewat nama object
        Console.WriteLine("Count: " + Person.count);
        Console.WriteLine("Count: " + dello.PlusOne());

        

    }
}
