namespace SeriesB.DPolymorphism;

public class Person
{
    public string FullName { get; set; }
    public virtual int Age { get; set; }
    public int Id { get; protected set; }
    public string Password { protected get; set; }

    public Person()
    {
        Console.WriteLine("Create a new Person");
    }

    public Person(string fullName, int age, string password)
    {
        FullName = fullName;
        Age = age;
        Password = password;
    }

    public virtual void Introduction()
    {
        Console.WriteLine("Name: " + FullName);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Password: " + Password);
    }

    public virtual void Introduction(string fullName, int age)
    {
        Console.WriteLine("Name: " + fullName);
        Console.WriteLine("Age: " + age);
        Console.WriteLine("Password: " + Password);
    }
}
