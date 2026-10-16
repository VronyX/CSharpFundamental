using System;
using System.Collections.Generic;
using System.Text;

namespace SeriesB.CInheritance;

public class Person
{
    public string FullName { get; set; }
    public int Age { get; set; }
    public int Id { get; protected set; }
    public string Password { protected get; set; }

    public void Introduction()
    {
        Console.WriteLine("Id: " + Id);
        Console.WriteLine("Name: " + FullName);
        Console.WriteLine("Age: " + Age);
        Console.WriteLine("Password: " + Password);
    }
}
