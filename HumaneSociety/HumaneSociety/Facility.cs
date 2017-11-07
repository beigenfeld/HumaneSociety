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
        List<string> roomNames = new List<string> { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
        List<Room> availableRooms = new List<Room>();
        List<Animal> animalList = new List<Animal>();

        //constructor
        public Facility()
        {

        }

        //member methods
        public void Run()
        {
            SetUpRooms();
            ShowAvilableRooms();
            //RegisterAnimals();
            //BeginAdoption();
        }

        private void SetUpRooms()
        {
            foreach (string item in roomNames)
            {
                Room room = new Room();
                room.roomNumber = item;
                availableRooms.Add(room);
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













    }
}
