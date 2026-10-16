namespace SeriesB.EAbstraction.Abstract;

// Abstract Class -> Partial Abstraction, isinya bisa method biasa, method tanpa implement, dan attribute
// Abstract Class, tidak bisa di instance sebagai object, hanya bisa diwariskan
public abstract class Employee
{
    public string name;

    public Employee(string name)
    {
        this.name = name;
    }

    public void ShowPaysSlip()
    {
        Console.WriteLine($"Name: {name}, {CalculateSalary():N0}");
    }

    protected abstract int CalculateSalary();
}
