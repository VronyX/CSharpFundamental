using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesA
{
    // Condition, Evaluasi boolean berdasarkan syarat/kondisi
    // if
    // switch-case
    public class ECondition
    {
        public static void IfCondition()
        {
            bool isActive = true;
            float gpa = 3.7f;
            float studyPeriod = 5;

            /* if (kondisi)
               {
                    statement
               }
             */
            Console.WriteLine("=== If Condition ===");
            if (isActive)
            {
                Console.WriteLine("Active");
            }
            else
            {
                Console.WriteLine("Not Active");
            }

            if (gpa > 3.9f && studyPeriod < 4)
            {
                Console.WriteLine("Summa Cumlaude");
            }
            else if (gpa < 3.5f && studyPeriod < 4)
            {
                Console.WriteLine("Cumlaude");
            }
            else
            {
                Console.WriteLine("Lulus");
            }

            // Nested If
            if (studyPeriod < 4)
            {
                if (gpa > 3.9f)
                {
                    Console.WriteLine("Summa Cumlaude");
                }
                else if (gpa < 3.5f)
                {
                    Console.WriteLine("Cumlaude");
                }
            }
            else
            {
                Console.WriteLine("Lulus");
            }
            Console.WriteLine();
        }

        public static void SwitchCondition()
        {
            int month = 5;
            string monthName;

            Console.WriteLine("=== Switch-Case ===");
            switch (month)
            {
                case 1:
                    monthName = "Januari";
                    break;
                case 2:
                    monthName = "Februari";
                    break;
                case 3:
                    monthName = "Maret";
                    break;
                case 4:
                    monthName = "April";
                    break;
                case 5:
                    monthName = "Mei";
                    break;
                case 6:
                    monthName = "Juni";
                    break;
                case 7:
                    monthName = "Juli";
                    break;
                case 8:
                    monthName = "Agustus";
                    break;
                case 9:
                    monthName = "September";
                    break;
                case 10:
                    monthName = "Oktober";
                    break;
                case 11:
                    monthName = "November";
                    break;
                case 12:
                    monthName = "Desember";
                    break;
                default:
                    monthName = "Anomali";
                    break;
            }

            Console.WriteLine(monthName);
            Console.WriteLine();
        }
    }
}
