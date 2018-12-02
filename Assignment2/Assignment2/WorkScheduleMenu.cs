using System;

/**
 * Class representing a menu in the console window with three different menu 
 * options. There is a menu option to return to the main window and two other 
 * options which both start the work schedule program.
 * Created by Jonas Eiselt on 2018-09-25.
 * 
 * Why is a while-loop used in the method Start?
 * A while-loop is used because we do not know when the user will enter a 0 (ie 
 * exit the program). We do not know how many iterations it will take for the user
 * to enter 0.
 */
namespace Assignment2
{
    public class WorkScheduleMenu
    {
        private int menuChoice;
        private bool enableMenu;

        /*
         * Displays menu in console and keeps asking the user for an input until
         * the user has chosen to exit the program in which case the variable enableMenu
         * is set to false.
         */
        public void Start()
        {
            DisplayMenuInfo();

            enableMenu = true;
            while (enableMenu)
            {
                DisplayMenu();
                ReadMenuInput();
                HandleInput(); // Set enableMenu to false if input is 0
            }

            DisplayFarewellMessage();
        }

        private void DisplayMenuInfo()
        {
            Console.WriteLine("\n********************************************");
            Console.WriteLine("Work schedule");
            Console.WriteLine("Select from the menu which type of schedule you want to see\n");
        }

        private void DisplayMenu()
        {
            Console.WriteLine("{0,4} {1,38}", "1", "Show a list of the weekends to work");
            Console.WriteLine("{0,4} {1,36}", "2", "Show a list of the nights to work");
            Console.WriteLine("{0,4} {1,22}", "0", "Return to main menu");
        }

        /* Reads user's menu choice until a valid one has been entered by the user. */
        private void ReadMenuInput()
        {
            Console.Write("\nYour choice: ");
            menuChoice = ConsoleInput.ReadInt();
        }
        
        /*
         * Handles user input and displays work schedule in console if the input
         * entered was 1 or 2. If the input entered is 0 the menu is disabled, meaning 
         * that the while-loop in the Start-method will not perform another iteration.
         */
        private void HandleInput()
        {
            if (menuChoice == 0)
                enableMenu = false;
            else if (menuChoice == 1 || menuChoice == 2)
            {
                WorkSchedule workSchedule = new WorkSchedule(menuChoice);
                workSchedule.Start();
            }
        }

        private void DisplayFarewellMessage()
        {
            Console.WriteLine("\n********************************************");
        }
    }
}