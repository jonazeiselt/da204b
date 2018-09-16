using System;

/**
 * Class that contains methods for reading user input and setting the pet object's 
 * descriptive variables.
 * Created by Jonas Eiselt on 2018-09-13.
 */
namespace Assignment1A
{
    public class Pet
    {
        // Declarations of pet variables
        private string name;
        private int age;
        private bool isFemale;

        public void ShowGreeting()
        {
            Console.WriteLine("Greetings from a Pet object!\n");
        }

        /* Reads user input and sets pet variables based on the given input. */
        public void ReadUserInput()
        {
            name = ReadPetName();
            age = ReadPetAge(name);
            isFemale = ReadPetGender();
        }

        private string ReadPetName()
        {
            Console.Write("What is the name of your pet? ");
            return Console.ReadLine();
        }

        private int ReadPetAge(string nameOfPet)
        {
            Console.Write("What is " + nameOfPet + "'s age? ");
            return int.Parse(Console.ReadLine());
        }

        private bool ReadPetGender()
        {
            Console.Write("Is your pet a female (y/n)? ");
            string femaleYesOrNo = Console.ReadLine();

            // Set variable isFemale based on the input given 
            if (femaleYesOrNo.Equals("y"))
                return true;
            else if (femaleYesOrNo.Equals("n"))
                return false;

            Console.WriteLine("Wrong input!");
            return false;
        }

        public void DisplayPetInformation()
        {
            Console.WriteLine("\n~~~~~~~~~~~~~~~~~~");

            Console.WriteLine("Name: " + name);
            Console.WriteLine("Age: " + age);

            // Print specific message depending on the pet's gender
            if (isFemale)
                Console.WriteLine(name + " is a female");
            else
                Console.WriteLine(name + " is a male");

            Console.WriteLine("~~~~~~~~~~~~~~~~~~\n");
        }
    }
}
