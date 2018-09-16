using System;
using System.Globalization;

/**
 * Class that contains methods for reading user input and setting a song object's 
 * descriptive variables.
 * Created by Jonas Eiselt on 2018-09-16. 
 */
namespace Assignment1B
{
    public class Song
    {
        // Declarations of song variables
        private string title;
        private string artist;
        private DateTime releaseDate;
        private int lengthInSeconds;

        public void ShowGreeting()
        {
            Console.WriteLine("Greetings from a Song object!\n");
        }

        public void ReadUserInput()
        {
            Console.Write("What is the title of your favorite song? ");
            title = Console.ReadLine();

            Console.Write("What is the name of the artist that is singing your favorite song? ");
            artist = Console.ReadLine();

            Console.Write("When did " + artist + " release (yyyy-MM-dd) your favorite song? ");

            // Contol user input by the format yyyy-MM-dd with the IFormatProvider
            IFormatProvider iFormatProvider = CultureInfo.InvariantCulture;
            releaseDate = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", iFormatProvider);

            Console.Write("How long is '" + title + "' in seconds? ");
            lengthInSeconds = int.Parse(Console.ReadLine());
        }

        /* Prints song's information in console window. */
        public void DisplaySongInformation()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("Title of song: " + title);
            Console.WriteLine("Artist: " + artist);
            Console.WriteLine("The song was released at " + releaseDate.ToString("yyyy-MM-dd"));
            Console.WriteLine("The song is " + lengthInSeconds + " seconds long");

            Console.WriteLine("~~~~~~~~~~~~~~~~~~\n");
        }
    }
}