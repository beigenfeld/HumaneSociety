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
            Console.WriteLine("[1] Add Animal");
            Console.WriteLine("[2] Show Rooms & Occupants");
            Console.WriteLine("[3] Track Innoculations");
            Console.WriteLine("[4] Update Innoculation Status of an Animal");
            Console.WriteLine("[5] Collect Payment");
            Console.WriteLine();
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    AddAnimal(facility);
                    break;
                case "2":
                    ShowRoomOccupation(facility);
                    break;
                case "3":
                    TrackInnoculations(facility);
                    break;
                case "4":
                    Animal updateThisAnimal = IdentifyAnimal(facility);
                    SetAnimalInnoculationStatus(updateThisAnimal);
                    break;
                case "5":
                    Animal collectForThisAnimal = IdentifyAnimal(facility);
                    CollectPayment(facility, collectForThisAnimal);
                    break;
            }
        }

        private void AddAnimal(Facility facility)
        {
            Animal newAnimal;
            Console.WriteLine("Adding animal to the adoption system:");
            newAnimal = GetAnimalType();
            newAnimal.name = GetAnimalName();
            newAnimal.gender = GetAnimalGender();
            newAnimal.innoculated = SetAnimalInnoculationStatus(newAnimal);
            newAnimal.assignedRoom = AssignAnimalToRoom(facility);
            newAnimal.animalID++;
            //AddAnimalToDatabase(newAnimal);
            Console.WriteLine("Animal added to system.");
            ChooseAction(facility);
        }


        private void ShowAvailableRooms(Facility facility)
        {
            Console.WriteLine("Available rooms:");
            foreach (Room room in facility.availableRooms)
            {
                Console.WriteLine(room.roomNumber);
            }
        }


    private void CheckForVacancy(Facility facility)
        {
            if (facility.availableRooms == null)
            {
                Console.WriteLine("Facility Full!  Please transfer to another facility.");
                ChooseAction(facility);
            }
        }

        private string AssignAnimalToRoom(Facility facility)
        {
            ShowAvailableRooms(facility);
            CheckForVacancy(facility);
            string assignedRoom = "";
            Console.WriteLine("Assign to Room:");
            string userInput = Console.ReadLine();
            for (int i = 0; i < facility.availableRooms.Count; i++) //(Room room in facility.availableRooms)
            {
                if (userInput == facility.availableRooms[i].roomNumber)//room.roomNumber)
                {
                    facility.availableRooms.Remove(facility.availableRooms[i]);
                    facility.availableRooms[i].occupied = true;
                    assignedRoom = facility.availableRooms[i].roomNumber;
                    break;
                }
            }
            if (assignedRoom == "")
            {
                Console.WriteLine("Room not available. Please choose from list below.");
                AssignAnimalToRoom(facility);
            }
            return assignedRoom;
        }

        private void FinalizeAdoption(Facility facility, Adopter adopter, Animal animal)
        {
            if (facility.paymentReceived == true && animal.innoculated == true)
            facility.animalList.Remove(animal);
            animal.adoptionStatus = true;
            animal.adoptedBy = adopter;
        }

        private void CollectPayment(Facility facility, Animal animal)
        {
            facility.register += animal.adoptionFee;
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

        private string GetAnimalName()
        {
            Console.WriteLine("Animal name:");
            string name = Console.ReadLine();
            return name;
        }

        public string GetAnimalGender()
        {
            Console.WriteLine("Animal gender: [1] Male  [2] Female");
            string userInput = Console.ReadLine();
            string gender = "";
            switch (userInput)
            {
                
                case "1":
                    gender = "Male";
                    break;
                case "2":
                    gender = "Female";
                    break;
                default:
                    Console.WriteLine("Invalid Entry.  Enter '1' or '2'");
                    GetAnimalGender();
                    break;
            }
            return gender;
        }

        private bool SetAnimalInnoculationStatus(Animal animal)
        {
            Console.WriteLine("Innoculation status: [1] Innoculated  [2] Not innoculated");
            string userInput = Console.ReadLine();
            bool innoculated = false;
            switch (userInput)
            {
                case "1":
                    innoculated = true;
                    break;
                case "2":
                    innoculated = false;
                    break;
                default:
                    Console.WriteLine("Invalid Entry.  Enter '1' or '2'");
                    SetAnimalInnoculationStatus(animal);
                    break;
            }
            return innoculated;

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

        private void ShowRoomOccupation(Facility facility)
        {
            foreach (Room room in facility.roomList)
            {
                if (room.occupied)
                {
                    Console.WriteLine("Room: {0}, Occupied by: {1}", room.roomNumber, room.occupiedBy);
                }
                else if (room.occupied == false)
                {
                    Console.WriteLine("Room: {0}, Occupied by: {1}", room.roomNumber, "vacant");
                }
            }
        }

        



    }
}
