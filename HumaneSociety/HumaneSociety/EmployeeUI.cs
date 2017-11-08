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

        //constructor
        public EmployeeUI()
        {

        }

        //member methods

        public void ChooseAction(Facility facility)
        {
            Console.WriteLine("What would you like to do?");
            Console.WriteLine("[1] Add Animal\n[2] Track Innoculations \n [3] Collect Payment\n[4]Finalize an Adoption\n[5]");
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddAnimal(facility.availableRooms);
                    break;
                case "2":
                    TrackInnoculations(facility);
                    break;
                case "3":
                    CollectPayment(facility, animal, adopter);
                    break;
            }
        }

        private void AddAnimal(List<Room> availableRooms)
        {
            Animal newAnimal;
            Console.WriteLine("Adding animal to the adoption system:");
            newAnimal = GetAnimalType();
            GetAnimalName(newAnimal);
            GetAnimalGender(newAnimal);
            SetAnimalInnoculationStatus(newAnimal);
            AssignAnimalToRoom(availableRooms, newAnimal);
            newAnimal.animalID++;
            //AddAnimalToDatabase();
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

        private void FinalizeAdoption(Facility facility, Adopter adopter, Animal animal)
        {
            if (facility.paymentReceived == true && animal.innoculated == true)
            facility.animalList.Remove(animal);
            animal.adoptionStatus = true;
            animal.adoptedBy = adopter.username;
        }

        private void CollectPayment(Facility facility)
        {
            facility.register += facility.adoptionFee;
        }

        private void TrackInnoculations(Facility facility)
        {
            foreach (Animal item in facility.animalList)
            {
                Console.WriteLine();
            }
        }

        private void AcceptTransfers()
        {
            //import csv file
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

        private void SetAnimalInnoculationStatus(Animal newAnimal)
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
                    SetAnimalInnoculationStatus(newAnimal);
                    break;
            }
        }

        private Animal IdentifyAnimal(Facility facility)
        {
            for (int i = 0; i < facility.animalList.Count; i++)
            {
                Console.WriteLine("{0}) {1}, ID {3}", i + 1, facility.animalList[i].name, facility.animalList[i].animalID);
            }
            Console.WriteLine("Please select the animal based on the ID number in the list above.");
            string userInput = Console.ReadLine();
            int numValue;
            bool parsed = Int32.TryParse(userInput, out numValue);
            if (!parsed)
            {
                Console.WriteLine("Invalid entry; please try again. Could not parse '{0}' to an int.\n", userInput);
                return IdentifyAnimal(facility);
            }
            else
            {
                for (int i = 0; i < facility.animalList.Count; i++)
                {
                    if (numValue == facility.animalList[i].animalID)
                    {
                        return facility.animalList[i];
                    }
                }
            }
            Console.WriteLine("Animal not found at this facility");
            return IdentifyAnimal(facility);
        }

       





    }
}
