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
        private string firstName;
        private string lastName;
        private string address;
        private string username;
        private string password;

        //constructor
        public AdopterUI()
        {

        }

        //member methods
        private void CreateNewProfile()
        {
            firstName = GetFirstName();
            lastName = GetLastName();
            address = GetAddress();
            username = CreateUsername();
        
        }

        private void FindAPet(Facility facility, List<Animal> currentAnimals)
        {
            facility.ShowCurrentAnimals(currentAnimals);
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
