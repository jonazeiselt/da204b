/**
 * Main class for the Song class. Creates a song object and calls its methods
 * to let the user enter a song's information.
 * Created by Jonas Eiselt on 2018-09-16. 
 */
namespace Assignment1B
{
    class SongMain
    {
        static void Main(string[] args)
        {
            Song song = new Song();
            song.ShowGreeting();
            song.ReadUserInput();
            song.DisplaySongInformation();
        }
    }
}
