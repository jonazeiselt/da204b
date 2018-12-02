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

        /*
         * Reads double inputs, represented as amounts in SEK, until 0 is provided. 
         * The input is added to a sum variable that later is used to convert the 
         * sum to a foreign currency.
         */
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

        /* Reads name of the desired currency the SEK amount is to be converted to. */
        private void ReadForeignCurrency()
        {
            Console.Write("Enter the foreign currency you want to exchange to: ");
            foreignCurrency = Console.ReadLine();
        }
        
        /* Reads the foreign currency exhange rate in proportion to SEK currency. */
        private void ReadForeignCurrencyExchangeRate()
        {
            Console.Write("Enter the foreign currency exchange rate, meaning how many " +
                "SEK are equal to 1 " + foreignCurrency + ": ");
            foreignCurrencyExchangeRate = (decimal) ConsoleInput.ReadDouble();
        }

        /* Converts the total SEK amount to the desired foreign currency. */
        private void ConvertSekToForeignCurrency()
        {
            foreignCurrencyAmount = sumOfSekAmounts / foreignCurrencyExchangeRate;
        }

        /*
         * Displays, in the console, the user's entered total amount in SEK and how much
         * in a certain foreign currency that total amount corresponds.
         */
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