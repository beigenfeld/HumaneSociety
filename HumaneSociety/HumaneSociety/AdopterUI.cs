using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class AdopterUI
    {
        //member variables
        

        //constructor
        public AdopterUI()
        {

        }

        //member methods
        public void CreateNewProfile()
        {
            Adopter adopter = new Adopter();
            adopter.firstName = GetFirstName();
            adopter.lastName = GetLastName();
            adopter.address = GetAddress();
            adopter.username = CreateUsername();
            adopter.password = CreatePassword();
            //AddAdopterToDatabase();
        }

        public void FindAPet(Facility facility)
        {
            Console.WriteLine("[1] See all animals in this facility.");
            Console.WriteLine("[2] Search by type of animal.");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    facility.ShowCurrentAnimals(facility.animalList);
                    break;
                case "2":
                    List<Animal> animalTypeList = facility.SortAnimalsByType();
                    facility.DisplayAnimalTypeList(animalTypeList);
                    break;
                default:
                    Console.WriteLine("Invalid answer.  Please enter '1' or '2'");
                    break;
            }
        }

        private string GetFirstName()
        {
            Console.WriteLine("Please enter your first name:");
            string firstName = Console.ReadLine();
            return firstName;
        }

        private string GetLastName()
        {
            Console.WriteLine("Please enter your last name:");
            string lastName = Console.ReadLine();
            return lastName;
        }

        private string GetAddress()
        {
            Console.WriteLine("Please enter your address:");
            string address = Console.ReadLine();
            return address;
        }

        private string CreateUsername()
        {
            Console.WriteLine("Please create a username");
            string username = Console.ReadLine();
            return username;
        }

        private string CreatePassword()
        {
            Console.WriteLine("Please create a password");
            string password = Console.ReadLine();
            return password;
        }


    }
}
