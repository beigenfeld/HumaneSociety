using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Facility
    {
        //member variables
        private string facilityName;
        public double register = 0;
        private List<string> roomNames = new List<string> { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
        public List<Room> roomList = new List<Room>();
        public List<Room> availableRooms = new List<Room>();
        public List<Animal> animalList = new List<Animal>();
        private List<Animal> animalTypeList;
        public bool paymentReceived = false;

        //constructor
        public Facility()
        {

        }

        //member methods
        public void Run()
        {
            SetUpRooms();
            string usertype = ChooseUserType();
            if (usertype == "Employee")
            {
                EmployeeUI newInterface = new EmployeeUI();
                newInterface.ChooseAction(this);
            }
            else if (usertype == "Adopter")
            {
                AdopterUI newInterface = new AdopterUI();
                newInterface.CreateNewProfile();
                newInterface.FindAPet(this);
            }
            //ShowRoomOccupation();
            //AddAnimal();
        }

        private void SetUpRooms()
        {
            foreach (string item in roomNames)
            {
                Room room = new Room();
                room.roomNumber = item;
                availableRooms.Add(room);
                roomList.Add(room);
            }
        }

        private void ShowAvilableRooms()
        {
            Console.WriteLine("Available Rooms:");
            foreach (Room item in availableRooms)
            {
                if (item.occupied == false)
                {
                    Console.WriteLine(item.roomNumber);
                }
            }
        }

        public void ShowCurrentAnimals(List<Animal> currentAnimals)
        {
            for (int i = 0; i < animalList.Count; i++)
            {
                Console.WriteLine("{0}) {1}, {2} ", i + 1, currentAnimals[i].type, currentAnimals[i].name);
            }
        }

        

        private string ChooseUserType()
        {
            Console.WriteLine("Are you an [1] Employee or [2] Adopter");
            string usertype = "";
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    usertype = "Employee";
                    break;
                case "2":
                    usertype = "Adopter";
                    break;
                default:
                    Console.WriteLine("Invalid entry.  Please enter '1' or '2'");
                    break;
            }
            return usertype;
        }

        public List<Animal> SortAnimalsByType()
        {
            string animalType = SelectAnimalType();
            List<Animal> animalTypeList = new List<Animal>();
            foreach(Animal animal in animalList) 
            {
                if (animalType == animal.type)
                {
                    animalTypeList.Add(animal);
                }
            }
            return animalTypeList;
        }

        public void DisplayAnimalTypeList(List<Animal> animalTypeList)
        {
            foreach(Animal animal in animalTypeList)
            {
                Console.WriteLine(animal.name + animal.breed);
            }
        }

        public string SelectAnimalType()
        {

            Console.WriteLine("What kind of pet are you looking for?");
            Console.WriteLine("[1] Cat\n[2] Dog");
            string userInput = Console.ReadLine();
            string animalType = "";
            switch (userInput)
            {
                case "1":
                    animalType = "Cat";
                    break;
                case "2":
                    animalType = "Dog";
                    break;
                default:
                    Console.WriteLine("Invalid entry.  Please enter '1' or '2'");
                    break;
            }
            return animalType;
        }





    }
}
