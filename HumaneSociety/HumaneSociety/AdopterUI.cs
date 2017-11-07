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
        private string name;

        //constructor
        public AdopterUI()
        {

        }

        //member methods
        private void CreateProfile()
        {

        }

        private void FindAPet(Facility facility, List<Animal> currentAnimals)
        {
            facility.ShowCurrentAnimals(currentAnimals);
        }







    }
}
