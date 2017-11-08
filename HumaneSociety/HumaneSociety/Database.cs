using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    public class Database
    {
        SqlConnection newConnection = new SqlConnection("Data Source=DESKTOP-0M194AG;Initial Catalog=HumaneSocietyDB;Integrated Security=True");

        public void AddAnimalToDatabase()
        {
            OpenConnection();
            string command = "INSERT INTO Animals";
            SqlCommand myCommand = new SqlCommand(command, newConnection);

            CloseConnection();
        }

        public void AddAdopterToDatabase()
        {
            OpenConnection();

            //do stuff here

            CloseConnection();
        }
            
        public void OpenConnection()
        {
            try
            {
                newConnection.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }

        public void CloseConnection()
        {
            try
            {
                newConnection.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }






    }
}
