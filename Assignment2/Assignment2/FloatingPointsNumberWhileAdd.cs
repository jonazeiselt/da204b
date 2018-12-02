using System;

/**
 * Class that adds entered doubles together with a while loop. 
 * Created by Jonas Eiselt on 2018-09-22.
 */
namespace Assignment2
{
    public class FloatingPointsNumberWhileAdd
    {
        private double sumOfAllFloatNumbers;

        public void Start()
        {
            DisplayProgramInfo();
            ReadFloatNumbers();
            DisplayTotalSum();
            DisplayFarewellMessage();
        }

        private void DisplayProgramInfo()
        {
            Console.WriteLine("\n********************************************");
            Console.WriteLine("Summation of numbers using a while loop");
            Console.WriteLine("Write 0 to finish!\n");
        }

        /* Reads and adds entered float numbers to a sum variable until a 0 was entered. */
        private void ReadFloatNumbers()
        {
            bool zeroEntered = false;
            while (!zeroEntered) // Keep going until 0 is entered
            {
                Console.Write("Write a number to add to the sum: ");
                double floatInput = ConsoleInput.ReadDouble();
                sumOfAllFloatNumbers += floatInput;

                if (Math.Round(floatInput, 7) == 0.0)
                    zeroEntered = true;
            }
        }

        /* Displays the sum of all entered float numbers in the console. */
        private void DisplayTotalSum()
        {
            Console.WriteLine("The sum is " + sumOfAllFloatNumbers);
        }

        private void DisplayFarewellMessage()
        {
            Console.WriteLine("\n********************************************");
        }
    }
}