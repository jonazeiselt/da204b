using System;

/**
 * Class representing a main menu in the console window with six different menu
 * options. Each of five menu options (1-5) start its own program. The sixth menu 
 * option (0) is used for exiting the program.
 * Created by Jonas Eiselt on 2018-09-22.
 */
namespace Assignment2
{
    public class Menu
    {
        private int menuChoice;
        private bool enableMenu;

        public void Start()
        {
            enableMenu = true;
            while (enableMenu)
            {
                DisplayMenu();
                ReadMenuInput();
                HandleInput();
            }
        }

        private void DisplayMenu()
        {
            Console.WriteLine("\nMain menu" +
                "\n~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Whole numbers with for loop: 1");
            Console.WriteLine("Floating point numbers with while loop: 2");
            Console.WriteLine("Currency converter with do-while loop: 3");
            Console.WriteLine("Temperature table: 4");
            Console.WriteLine("Work schedule: 5");
            Console.WriteLine("Exit the program: 0");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
        }

        private void ReadMenuInput()
        {
            Console.Write("Your choice: ");
            menuChoice = ConsoleInput.ReadInt();
        }

        private void HandleInput()
        {
            switch (menuChoice)
            {
                case 0:
                    enableMenu = false;
                    break;
                case 1:
                    WholeNumbersForAdd wholeNumbersForAdd = new WholeNumbersForAdd();
                    wholeNumbersForAdd.Start();
                    break;
                case 2:
                    FloatingPointsNumberWhileAdd floatingPointsNumberWhileAdd = 
                        new FloatingPointsNumberWhileAdd();
                    floatingPointsNumberWhileAdd.Start();
                    break;
                case 3:
                    CurrencyConverter currencyConverter = new CurrencyConverter();
                    currencyConverter.Start();
                    break;
                case 4:
                    TemperatureTable temperatureTable = new TemperatureTable();
                    temperatureTable.Start();
                    break;
                case 5:
                    WorkScheduleMenu workScheduleMenu = new WorkScheduleMenu();
                    workScheduleMenu.Start();
                    break;
            };
        }
    }
}