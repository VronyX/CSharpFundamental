namespace SeriesA
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //BDataTypeAndVariable.Variable();
            BDataTypeAndVariable.Array();
            //CNumeric.Conversion();
            //DOperator.Arithmetic();
            //DOperator.Logical();
            //ECondition.IfCondition();
            //ECondition.SwitchCondition();
            GMethod.Introduction();
            GMethod.WhoAreYou("Fran Dello", "Application Developer");
            string dello = GMethod.FullName("Fran", "Dello");
            int age = GMethod.BirthDate(2004, 4, 14);
            Console.WriteLine(dello);
            Console.WriteLine(age);
            Extra();

        }

        public static void Extra()
        {
            var fullName = "Fran Dello";
            var age = 22;
            // String Interpolation
            Console.WriteLine($"Full Name: {fullName}\nAge: {age}");

            // Input Text
            string text = Console.ReadLine();
            Console.WriteLine($"Inputan string: {text}");

            int number = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"Inputan int: {number}");

        }
    }
}
