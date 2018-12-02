using System;

/**
 * Class that displays a list of two columns of temperature values, where each 
 * column represents either temperatures in Celcius or Fahrenheit. The user has 
 * the option to either convert 0-100°C to corresponding °F values or vice versa.
 * Created by Jonas Eiselt on 2018-09-25.
 * 
 * Why is a for-loop used in the method DisplayTableBody?
 * A for-loop is used here because we know the range values (the start value which
 * is 0 and end value which is 100).
 */
namespace Assignment2
{
    public class TemperatureTable
    {
        private bool convertToCelsius;
        private bool wrongInput;

        public void Start()
        {
            DisplayProgramInfo();
            ReadTypeOfConversion();
            DisplayTemperatureTable();
            DisplayFarewellMessage();
        }

        private void DisplayProgramInfo()
        {
            Console.WriteLine("\n********************************************");
            Console.WriteLine("Temperature table\n");
        }

        /*
         * This method determines what kind of temperature conversion is to be done. 
         * It asks for the user's choice at least once (hence the do-while loop) and
         * continues asking until the user has provided a correct answer (1 or 2).
         */
        private void ReadTypeOfConversion()
        {
            DisplayConversionChoices();
            do
            {
                wrongInput = false;

                int choice = ConsoleInput.ReadInt();
                if (choice == 1)
                    convertToCelsius = false;
                else if (choice == 2)
                    convertToCelsius = true;
                else
                    DisplayWrongInputMessage();
            }
            while (wrongInput);
        }

        private void DisplayConversionChoices()
        {
            Console.WriteLine("To convert from Celsius to Fahrenheit, " +
                "enter 1.\nTo convert from Fahrenheit to Celsius, enter 2.");
            Console.Write("Your choice: ");
        }

        private void DisplayWrongInputMessage()
        {
            wrongInput = true; // User has provided wrong input
            Console.WriteLine("Wrong input! Please, try again.");
            Console.Write("\nYour choice: ");
        }

        private void DisplayTemperatureTable()
        {
            DisplayTableHeader();
            DisplayTableBody();
            DisplayTableFooter();
        }

        private void DisplayTableHeader()
        {
            Console.WriteLine("\n--------------------------------------------");
            if (convertToCelsius)
                Console.WriteLine("{0,12} {1,18}", "Fahrenheit", "Celsius");
            else
                Console.WriteLine("{0,12} {1,18}", "Celsius", "Fahrenheit");
            Console.WriteLine("--------------------------------------------");
        }

        /*
         * Displays a table, with two columns of temperature values, in the console. In one 
         * column can either Fahrenheit or Celsius be viewed and in the other column the 
         * corresponding temperature values in either Celsius or Fahrenheit be viewed.
         */
        private void DisplayTableBody()
        {
            if (convertToCelsius)
            {
                // Convert fahrenheit to celsius
                double celsius;
                for (int fahrenheit = 0; fahrenheit <= 100; fahrenheit += 4)
                {
                    celsius = convertFahrenheitToCelsius(fahrenheit);
                    Console.WriteLine("{0,12} {1,18}", ((double)fahrenheit).ToString("0.00") +
                        "°F", celsius.ToString("0.00") + "°C");
                }
            }
            else
            {
                // Convert celsius to fahrenheit
                double fahrenheit;
                for (int celsius = 0; celsius <= 100; celsius += 4)
                {
                    fahrenheit = convertCelsiusToFahrenheit(celsius);
                    Console.WriteLine("{0,12} {1,18}", ((double)celsius).ToString("0.00") +
                        "°C", fahrenheit.ToString("0.00") + "°F");
                }
            }
        }
        
        /*
         * Converts temperature in Fahrenheit to corresponding 
         * temperature in Celsius. 
         */
        private double convertFahrenheitToCelsius(int fahrenheit)
        {
            return (5.0 / 9.0) * (fahrenheit - 32);
        }

        /*
         * Converts temperature in Celsius to corresponding
         * temperature in Fahrenheit.
         */
        private double convertCelsiusToFahrenheit(int celsius)
        {
            return (9.0 / 5.0) * (celsius + 32);
        }

        private void DisplayTableFooter()
        {
            Console.WriteLine("--------------------------------------------");
        }

        private void DisplayFarewellMessage()
        {
            Console.WriteLine("\n********************************************");
        }
    }
}