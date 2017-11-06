using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HumaneSociety
{
    class Database
    {

        SqlConnection()
        {

        }



        using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        // Do work here; connection closed on following line.
    }




    }
}
