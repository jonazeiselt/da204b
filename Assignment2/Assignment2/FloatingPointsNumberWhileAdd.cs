using System;

/**
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

        private void ReadFloatNumbers()
        {
            bool zeroEntered = false;
            while (!zeroEntered)
            {
                Console.Write("Write a number to add to the sum: ");
                double floatInput = ConsoleInput.ReadDouble();
                sumOfAllFloatNumbers += floatInput;

                if (Math.Round(floatInput, 7) == 0.0)
                    zeroEntered = true;
            }
        }

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