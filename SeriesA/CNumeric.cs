using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeriesA
{
    public class CNumeric
    {
        // byte > short > int > long > float > double
        static byte byteType = 5;
        static short shortType = 5;
        static int intType = 5;
        static long longType = 5;
        static float floatType = 5;
        static double doubleType = 5;

        public static void toDouble()
        {
            double toDouble;
            toDouble = byteType;
            toDouble = shortType;
            toDouble = intType;
            toDouble = longType;
            toDouble = floatType;
            toDouble = doubleType;
        }

        public static void toFloat()
        {
            float toFloat;
            toFloat = byteType;
            toFloat = shortType;
            toFloat = intType;
            toFloat = longType;
            toFloat = floatType;
            //toFloat = (float)doubleType;
        }

        public static void toLong()
        {
            long toLong;
            toLong = byteType;
            toLong = shortType;
            toLong = intType;
            toLong = longType;
            //toLong = (long)floatType;
            //toLong = (long)doubleType;
        }

        public static void toInt()
        {
            int toInt;
            toInt = byteType;
            toInt = shortType;
            toInt = intType;
            //toInt = (int)longType;
            //toInt = (int)floatType;
            //toInt = (int)doubleType;
        }

        public static void toShort()
        {
            short toShort;
            toShort = byteType;
            toShort = shortType;
            //toShort = (short)intType;
            //toShort = (short)longType;
            //toShort = (short)floatType;
            //toShort = (short)doubleType;
        }

        public static void toByte()
        {
            byte toByte;
            toByte = byteType;
            //toByte = (byte)shortType;
            //toByte = (byte)intType;
            //toByte = (byte)longType;
            //toByte = (byte)floatType;
            //toByte = (byte)doubleType;
        }

        public static void Conversion()
        {
            long l1 = 500L;
            long l2 = 500;

            //int i1 = l1; DITOLAK
            int i2 = (int)l1; // Convert with Cast
            int i3 = Convert.ToInt32(l1); //Convert with Parsing
            Console.WriteLine("=== Numerics (Conversion) ===");
            Console.WriteLine(i2);
            Console.WriteLine(i3);
            Console.WriteLine();
        }
    }
}
