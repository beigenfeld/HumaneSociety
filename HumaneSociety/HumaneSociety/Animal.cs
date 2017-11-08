using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Animal
    {
        //member variables
        public string type;
        public string breed;
        public string name;
        public int animalID = 0;
        public bool innoculated;
        public string gender;
        public double adoptionFee;
        public string assignedRoom;
        public bool adoptionStatus;
        public Adopter adoptedBy;

        //constructor
        public Animal()
        {
            adoptionStatus = false;
        }

        //member methods
        public virtual void Eat()
        {

        }









    }
}
