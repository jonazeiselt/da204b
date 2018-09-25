using System;

/**
 * Class that displays a list of weeks to work, depending on the type of
 * schedule (nights or weekends). A for loop is used for printing the list. 
 * A for loop is used in this case because it requires lesser lines of code
 * than that of a while loop.
 * Created by Jonas Eiselt on 2018-09-25. 
 */
namespace Assignment2
{
    public class WorkSchedule
    {
        private int menuChoice;

        private readonly int weekends = 1;
        private readonly int nights = 2;

        private readonly int startAtWeek1 = 1;
        private readonly int everyThirdWeek = 3;
        private readonly int startAtWeek6 = 6;
        private readonly int everyFifthWeek = 5;
        private readonly int endAtWeek52 = 52;

        public WorkSchedule(int menuChoice)
        {
            this.menuChoice = menuChoice;
        }

        /* 
         * Decides which week list to display in console window, based on the 
         * value entered in the work schedule menu. 
         */
        public void Start()
        {
            if (menuChoice == weekends)
                DisplayListOfWeeksToWork(startAtWeek1, endAtWeek52, everyThirdWeek);
            else if (menuChoice == nights)
                DisplayListOfWeeksToWork(startAtWeek6, endAtWeek52, everyFifthWeek);
            else
                Console.WriteLine("Oops, something went wrong!");
        }

        /* 
         * Displays a week list ranging from a start week to an end week with a 
         * regular week interval. 
         */
        private void DisplayListOfWeeksToWork(int startWeek, int endWeek, int weeksBetweenWork)
        {
            int columnCounter = 1, weeksPerRow = 3;
            for (int week = startWeek; week <= endWeek; week += weeksBetweenWork)
            {
                Console.Write("{0,12}", "Week " + week);

                // Print 3 weeks per row in console window
                if (columnCounter % weeksPerRow == 0)
                    Console.WriteLine();

                columnCounter++;
            }
            Console.WriteLine("\n--------------------------------------------\n");
        }
    }
}