using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesA
{
    public class DOperator
    {
        public static void Arithmetic()
        {
            int x = 3;
            int y = 5;

            int add = x + y;
            int subtract = x - y;
            int multiply = x * y;
            int divide = x / y;
            int modulus = x % y;

            Console.WriteLine("=== Operator ===");
            Console.WriteLine("x + y: " + add);
            Console.WriteLine("x - y: " + subtract);
            Console.WriteLine("x * y: " + multiply);
            Console.WriteLine("x / y: " + divide);
            Console.WriteLine("x % y: " + modulus);
            Console.WriteLine();

            Console.WriteLine("=== Increment and Decrement ===");
            int number = 5;
            // number = number + 1
            Console.WriteLine("Post-Increment: " + number++);
            number = 5;
            Console.WriteLine("Pre-Increment: " + ++number);
            number = 5;
            // number = number - 1;
            Console.WriteLine("Post-Decrement: " + number--);
            number = 5;
            Console.WriteLine("Pre-Decrement: " + --number);
            Console.WriteLine();
        }

        public static void Assignment()
        {
            // Cascade
            int x, y, z;
            x = y = z = 5;

            Console.WriteLine(x);
            Console.WriteLine(y);
            Console.WriteLine(z);
            Console.WriteLine();

            x += 2; // x = x + 2
            Console.WriteLine("x += 2: " + x);
            x -= 2; // x = x - 2
            x *= 2; // x = x * 2
            x /= 2; // x = x / 2
            x %= 2; // x = x % 2
        }

        public static void Logical()
        {
            int x = 3;
            int y = 5;

            Console.WriteLine("=== Logical AND ===");
            // True && True > True
            // True && False > False
            // False && True > False
            // False && False > False
            bool condition = (x == 3) && (y == 5);
            Console.WriteLine("True And True: " + condition);
            Console.WriteLine();

            Console.WriteLine("=== Logical OR ===");
            // True || True > True
            // True || False > True
            // False || True > True
            // False || False > False
            condition = x == y || true;
            Console.WriteLine("False Or True: " + condition);
            Console.WriteLine();

            Console.WriteLine("=== Logical Negation ===");
            // True > False
            // False > True
            condition = !(x == y);
            Console.WriteLine("False Negation: " + condition);
            Console.WriteLine();

        }
    }
}
