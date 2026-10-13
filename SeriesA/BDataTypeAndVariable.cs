using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace SeriesA
{
    public class BDataTypeAndVariable
    {
        /*
         * Variable, menampung suatu nilai (value). Tujuan, supaya value bisa digunakan secara berulang kali.
         * Data Type, format penampung untuk penyimpanan nilai ( value). Berisi rentang (array) tertentu atau tipe.
         * Value, nilai yang dapat dimanipulasi oleh program (dinamis).
         * 
         * Penulisan Variable:
            - Explicit
              Format:
              DataType Variable;
              Variable = Value;
         
            - Implicit
              Format:
              DataType Variable = Value;
         */
        public static void Variable()
        {
            // Deklarasi
            string fullName;
            char gender;
            int age;
            float gpa;
            bool isActive;

            // Inialisasi
            fullName = "Fran Dello";
            gender = 'M';
            age = 22;
            gpa = 3.6f;
            isActive = true;

            // Print
            Console.WriteLine("=== DataType and Variable ===");
            Console.WriteLine("Full Name: " + fullName);
            Console.WriteLine("Gender: " + gender);
            Console.WriteLine("Age: " + age);
            Console.WriteLine("GPA: " + gpa);
            Console.WriteLine("IsActive: " + isActive);
            Console.WriteLine();
        }

        // Constant, tampungan yang tidak dapat diubah nilainya ketika ditentukan
        public static void Constant()
        {
            const float phi = 3.14f;

            // phi = 5f; DITOLAK
        }

        /*
         Array, dapat menampung beberapa value dengan tipe data yang sama
         Array dibagi menjadi 3: indexed, multidimensional, dan associative
         Panjang array bersifat tetap dan harus ditentukan saat init dan tidak bisa ditambah/dikurang

         Untuk menampilkan array dimulai dari index 0
         */
        public static void Array()
        {
            // Indexed Array
            string[] studyProgram = { "IT", "CS", "SI", "GD" };
            string[] masterProgram = new string[2];
            masterProgram[0] = "Science";
            masterProgram[1] = "Business Administration";

            foreach (var master in masterProgram)
            {
                Console.WriteLine(master);
            }

            Console.WriteLine();

            // Multi-dimensional Array
            string[,] fullNames = new string[2, 3];
            string[,] masterNames =
            {
                { "Fran", "Dello" },
                { "Fahri", "Hanif" }
            };

            Console.WriteLine(masterNames[0, 0]);
            Console.WriteLine(masterNames[0, 1]);
            Console.WriteLine(masterNames[1, 0]);
            Console.WriteLine(masterNames[1, 1]);
            Console.WriteLine();
        }
    }
}
