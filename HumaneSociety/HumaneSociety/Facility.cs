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
        public double adoptionFee;
        public double register = 0;
        private List<string> roomNames = new List<string> { "A1", "A2", "A3", "B1", "B2", "B3", "C1", "C2", "C3" };
        public List<Room> roomList = new List<Room>();
        public List<Room> availableRooms = new List<Room>();
        public List<Animal> animalList = new List<Animal>();
        public bool paymentReceived = false;

        //constructor
        public Facility()
        {

        }

        //member methods
        public void Run()
        {
            SetUpRooms();
            ShowAvilableRooms();
            ShowRoomOccupation();
            AddAnimal();
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

        private void ShowRoomOccupation()
        {
            foreach (Room room in roomList)
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
