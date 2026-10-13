namespace LatihanA;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("================================");
        Console.WriteLine("=                              =");
        Console.WriteLine("=          GPA COUNTER         =");
        Console.WriteLine("=                              =");
        Console.WriteLine("================================");
        string choice = "Y";
        while (choice == "Y")
        {
            Menu.InputCourse();

            do
            {
                Console.Write("Do you want to calculate your GPA again? (Y/N): ");
                choice = Console.ReadLine().Trim().ToUpper();
            }
            while (choice != "Y" && choice != "N");

            Console.Clear();

        }
        Console.WriteLine("================================");
        Console.WriteLine("=                              =");
        Console.WriteLine("=           THANKYOU           =");
        Console.WriteLine("=                              =");
        Console.WriteLine("================================");

    }
}
