using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class EmployeeUI
    {
        //member variables
        private string employeeNumber;

        //constructor
        public EmployeeUI()
        {

        }

        //member methods
        private void AddAnimal(List<Room> availableRooms)
        {
            Animal newAnimal;
            Console.WriteLine("Adding animal to the adoption system:");
            newAnimal = GetAnimalType();
            GetAnimalName(newAnimal);
            GetAnimalGender(newAnimal);
            GetAnimalInnoculationStatus(newAnimal);
            AssignAnimalToRoom(availableRooms, newAnimal);
        }

        private void AssignAnimalToRoom(List<Room> availableRooms, Animal animal)
        {
            Console.WriteLine("Available rooms:");
            foreach (Room room in availableRooms)
            {
                Console.WriteLine(room.roomNumber);
            }
            Console.WriteLine("Assign to Room:");
            string userInput = Console.ReadLine();
            foreach (Room room in availableRooms)
            {
                if (userInput == room.roomNumber)
                {
                    availableRooms.Remove(room);
                    room.occupied = true;
                    animal.assignedRoom = room.roomNumber;
                }
                else if(availableRooms == null)
                {
                    Console.WriteLine("Facility Full!  Please transfer to another facility.");
                }
                else
                {
                    Console.WriteLine("Room not available.  Please try again.");
                    AssignAnimalToRoom(availableRooms, animal);
                }
            }
        }

        private void FinalizeAdoption()
        {

        }

        private void CollectPayment()
        {

        }

        private void TrackInnoculations()
        {

        }

        private void AcceptTransfers()
        {

        }

        private void OrderFood(Food food)
        {
            
        }

        

        private Animal GetAnimalType()
        {
            Animal newAnimal = new Animal();
            Console.WriteLine("Animal type:");
            Console.WriteLine("[1] Dog  [2] Cat");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Dog dog = new Dog();
                    newAnimal = dog;
                    break;
                case "2":
                    Cat cat = new Cat();
                    newAnimal = cat;
                    break;
                default:
                    Console.WriteLine("Invalid entry.  Please enter '1' or '2' ");
                    GetAnimalType();
                    break;
            }
            return newAnimal;
        }

        private void GetAnimalName(Animal newAnimal)
        {
            Console.WriteLine("Animal name:");
            string userInput = Console.ReadLine();
            newAnimal.name = userInput;
        }

        public void GetAnimalGender(Animal newAnimal)
        {
            Console.WriteLine("Animal gender: [1] Male  [2] Female");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    newAnimal.gender = "Male";
                    break;
                case "2":
                    newAnimal.gender = "Female";
                    break;
                default:
                    Console.WriteLine("Invalid Entry.  Enter '1' or '2'");
                    GetAnimalGender(newAnimal);
                    break;
            }
        }

        private void GetAnimalInnoculationStatus(Animal newAnimal)
        {
            Console.WriteLine("Innoculation status: [1] Innoculated  [2] Not innoculated");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    newAnimal.innoculated = true;
                    break;
                case "2":
                    newAnimal.innoculated = false;
                    break;
                default:
                    Console.WriteLine("Invalid Entry.  Enter '1' or '2'");
                    GetAnimalInnoculationStatus(newAnimal);
                    break;
            }
        }









    }
}
