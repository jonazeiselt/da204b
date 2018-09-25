using System;

/**
 * Created by Jonas Eiselt on 2018-09-22.
 */
namespace Assignment2
{
    public static class ConsoleInput
    {
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