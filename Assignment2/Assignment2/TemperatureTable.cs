using System;

/**
 * Created by Jonas Eiselt on 2018-09-25.
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

        private void ReadTypeOfConversion()
        {
            Console.Write("Enter CF to to calculate temperatures from" +
                " 0 to 100° Celsius to corresponding Fahrenheit " +
                "values, or FC for vice versa: ");
            
            do
            {
                wrongInput = false;

                string typeOfConversionInput = Console.ReadLine();
                if (typeOfConversionInput.Equals("CF"))
                    convertToCelsius = false;
                else if (typeOfConversionInput.Equals("FC"))
                    convertToCelsius = true;
                else
                    DisplayWrongInputMessage();
            }
            while (wrongInput);
        }

        private void DisplayWrongInputMessage()
        {
            wrongInput = true;
            Console.WriteLine("Wrong input! Please, try again.");
            Console.Write("\nEnter CF or FC: ");
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

        private void DisplayTableBody()
        {
            if (convertToCelsius)
            {
                // Convert fahrenheit to celsius
                double celsius;
                for (int fahrenheit = 0; fahrenheit <= 100; fahrenheit += 4)
                {
                    celsius = (5.0 / 9.0) * (fahrenheit - 32);
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
                    fahrenheit = (9.0 / 5.0) * (celsius + 32);
                    Console.WriteLine("{0,12} {1,18}", ((double)celsius).ToString("0.00") +
                        "°C", fahrenheit.ToString("0.00") + "°F");
                }
            }
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