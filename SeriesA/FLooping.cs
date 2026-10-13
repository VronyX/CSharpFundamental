using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesA
{
    // Looping, mengulang statement sampai kondisi berakhir/false
    //for-loop
    //while-loop
    public class FLooping
    {
        public static void ForLoop()
        {
            /*
             Format:
             for (init; condition; operator) {
                Statement
             }
             */

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Counter: " + i);
            }

            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            foreach (int number in numbers)
            {
                Console.WriteLine("No: " + number);
            }
        }

        public static void WhileLoop() 
        {
            int counter = 0;
            while (counter < 10)
            {
                Console.WriteLine("Counter: " + counter);
                counter++;
            }

            counter = 0;
            do
            {
                Console.WriteLine("Counter: " + counter);
                counter++;
            } while (counter < 10);
        }
    }
}
