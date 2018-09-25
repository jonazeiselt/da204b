using System;

/**
 * Created by Jonas Eiselt on 2018-09-25.
 */
namespace Assignment2
{
    public class WorkScheduleMenu
    {
        private int menuChoice;
        private bool enableMenu;

        public void Start()
        {
            DisplayMenuInfo();

            enableMenu = true;
            while (enableMenu)
            {
                DisplayMenu();
                ReadMenuInput();
                HandleInput();
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

        private void ReadMenuInput()
        {
            Console.Write("\nYour choice: ");
            menuChoice = ConsoleInput.ReadInt();
        }

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