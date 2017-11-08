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
        //SqlCommand myCommand;//= new SqlCommand();

        public void AddAnimalToDatabase()
        {
            OpenConnection();

            SqlCommand myCommand = new SqlCommand("INSERT INTO Animals (Type, Name, Innoculated, Gender, AdoptionFee) " +
                                      "Values ('string', 1)");//, newConnection);

            myCommand.ExecuteNonQuery();
            CloseConnection();
        }

        public void AddAdopterToDatabase()
        {
            OpenConnection();

            //do stuff here  

            CloseConnection();
        }



        myCommand.Connection = myConnection;
//The connection string can also be specified both ways using the SqlCommand.
//CommandText property.Now lets look at our first SqlCommand. 
//To keep it simple it will be a simple INSERT command.

SqlCommand myCommand= new SqlCommand("INSERT INTO table (Column1, Column2) " +
                                     "Values ('string', 1)", myConnection);

    // - or - 

    myCommand.CommandText = "INSERT INTO table (Column1, Column2) " + 
                        "Values ('string', 1)";
//Now we will take a look at the values.table is simply the table within the database.
//Column1 and Column2 are merely the names of the columns.
//Within the values section I demonstrated how to insert a string type and an int type value.
//The string value is placed in single quotes and as you can see an integer is just passed as is. 
    //The final step is to execute the command with:
    












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
