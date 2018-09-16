/**
 * Main class for the Pet class. Creates a pet object and calls its methods
 * to let the user enter a pet's information.
 * Created by Jonas Eiselt on 2018-09-13.
 */
namespace Assignment1A
{
    class PetMain
    {
        static void Main(string[] args)
        {
            Pet pet = new Pet();
            pet.ShowGreeting();
            pet.ReadUserInput();
            pet.DisplayPetInformation();
        }
    }
}
