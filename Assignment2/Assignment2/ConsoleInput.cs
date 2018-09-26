using System;

/**
 * Helper class that converts the input entered in the console to either an
 * integer or to a double.
 * Created by Jonas Eiselt on 2018-09-22.
 */
namespace Assignment2
{
    public static class ConsoleInput
    {
        /* 
         * Converts the input entered in the console to an integer. If the input
         * is not an integer, it keeps asking until the user has input an integer. 
         */
        public static int ReadInt()
        {
            bool successfulConversion; int integer;
            do
            {
                successfulConversion = int.TryParse(Console.ReadLine(), out integer);

                if (!successfulConversion)
                {
                    Console.WriteLine("Invalid input!");
                    Console.Write("\nEnter again: ");
                }
            }
            while (!successfulConversion);

            return integer;
        }

        /* 
         * Converts the input entered in the console to a double. If the input
         * is not a double, it keeps asking until the user has input a double. 
         */
        public static double ReadDouble()
        {
            bool successfulConversion; double number;
            do
            {
                successfulConversion = double.TryParse(Console.ReadLine(), out number);

                if (!successfulConversion)
                {
                    Console.WriteLine("Invalid input!");
                    Console.Write("\nEnter again: ");
                }
            }
            while (!successfulConversion);

            return number;
        }
    }
}