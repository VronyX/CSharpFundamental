using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesA
{
    // Method, membungkus statements (beberapa code). Hanya memiliki 1 tujuan.
    // void, tidak mengembalikan value
    // non-void, mengembalikan value
    public class GMethod
    {
        public static void Introduction()
        {
            Console.WriteLine("Full Name: Fran Dello");
            Console.WriteLine("Job Position: Application Developer");
            Console.WriteLine();
        }

        public static void WhoAreYou(string fullName, string position) 
        {
            Console.WriteLine("Full Name: " + fullName);
            Console.WriteLine("Job Position: " + position);
            Console.WriteLine();
        }

        public static string FullName(string firstName, string lastName)
        {
            return firstName + " " + lastName;
        }

        public static int BirthDate(int year, int month, int day)
        {
            DateTime birthDate = new DateTime(year, month, day);
            DateTime now = DateTime.Now;
            return now.Year - birthDate.Year;
        }
    }
}
