namespace SeriesB.AClassAndObject;

public class Person
{

    // Attribute or Property, milik tiap object sehingga nilainya bisa berbeda setiap object (instance)
    public string name;
    public int age;

    /*
     * Constructor, method khusus untuk instansiasi object. Dipanggil setiap kali membuat object dan tidak 
     * bisa di panggil berulang di object yg sama
    */
    public Person()
    {
        count++;
        Console.WriteLine("Creating a new Person");
    }

    public Person(string name,  int age)
    {
        count++;
        this.name = name;
        this.age = age;
    }

    // Static, milik class > hanya ada 1 dan dipakai bersama oleh semua object
    public static int count;

    // Behavior or Method, suatu perilaku atau tingkah laku yang dapat dilakukan oleh object
    public void Introduction()
    {
        Console.WriteLine("Name: " + name);
        Console.WriteLine("Age: " + age);
    }

    public int PlusOne()
    {
        return count++;
    }
}
