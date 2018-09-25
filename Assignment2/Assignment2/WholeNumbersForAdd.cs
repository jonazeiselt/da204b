using System;

/**
 * Created by Jonas Eiselt on 2018-09-22.
 */
namespace Assignment2
{
    public class WholeNumbersForAdd
    {
        private int numberOfWholeNumbersToAdd;
        private int sumOfAllWholeNumbers;

        public void Start()
        {
            DisplayProgramInfo();
            ReadNumberOfWholeNumbersToAdd();
            ReadEachWholeNumber();
            DisplayTotalSum();
            DisplayFarewellMessage();
        }

        private void DisplayProgramInfo()
        {
            Console.WriteLine("\n********************************************");
            Console.WriteLine("Summation of whole numbers using a for loop");
        }

        private void ReadNumberOfWholeNumbersToAdd()
        {
            Console.Write("Number of whole numbers to add? ");
            numberOfWholeNumbersToAdd = ConsoleInput.ReadInt();

            Console.WriteLine("");
        }

        private void ReadEachWholeNumber()
        {
            for (int i = 1; i <= numberOfWholeNumbersToAdd; i++)
            {
                Console.Write(i + ": whole number to add is ");
                sumOfAllWholeNumbers += ConsoleInput.ReadInt();
            }
        }

        private void DisplayTotalSum()
        {
            Console.WriteLine("The sum is " + sumOfAllWholeNumbers);
        }

        private void DisplayFarewellMessage()
        {
            Console.WriteLine("\n********************************************");
        }
    }
}