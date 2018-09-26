using System;

/**
 * Class that adds entered decimal SEK values together and converts them to a 
 * desired currency.
 * Created by Jonas Eiselt on 2018-09-22.
 */
namespace Assignment2
{
    public class CurrencyConverter
    {
        private decimal sumOfSekAmounts;
        private string foreignCurrency;
        private decimal foreignCurrencyExchangeRate;
        private decimal foreignCurrencyAmount;

        public void Start()
        {
            DisplayProgramInfo();
            ReadSwedishCurrencyAmounts();
            ReadForeignCurrency();
            ReadForeignCurrencyExchangeRate();
            ConvertSekToForeignCurrency();
            DisplayResults();
            DisplayFarewellMessage();
        }

        private void DisplayProgramInfo()
        {
            Console.WriteLine("\n********************************************");
            Console.WriteLine("Currency converter");
            Console.WriteLine("Write 0 to finish!\n");
        }

        private void ReadSwedishCurrencyAmounts()
        {
            decimal floatInput;
            do
            {
                Console.Write("Write an amount in Swedish currency to add to the total: ");
                floatInput = (decimal) ConsoleInput.ReadDouble();
                sumOfSekAmounts += floatInput;

            }
            while (Math.Round(floatInput, 7) != 0);
        }

        private void ReadForeignCurrency()
        {
            Console.Write("Enter the foreign currency you want to exchange to: ");
            foreignCurrency = Console.ReadLine();
        }

        private void ReadForeignCurrencyExchangeRate()
        {
            Console.Write("Enter the foreign currency exchange rate, meaning how many " +
                "SEK are equal to 1 " + foreignCurrency + ": ");
            foreignCurrencyExchangeRate = (decimal) ConsoleInput.ReadDouble();
        }

        private void ConvertSekToForeignCurrency()
        {
            foreignCurrencyAmount = sumOfSekAmounts / foreignCurrencyExchangeRate;
        }

        private void DisplayResults()
        {
            Console.WriteLine("\nThe total amount entered is " + sumOfSekAmounts + " SEK");
            Console.WriteLine(sumOfSekAmounts.ToString("0.00") + " SEK amounts to " + 
                foreignCurrencyAmount.ToString("0.00") + " USD with the exchange rate of " +
                foreignCurrencyExchangeRate + " SEK/" + foreignCurrency);
        }

        private void DisplayFarewellMessage()
        {
            Console.WriteLine("\n********************************************");
        }
    }
}