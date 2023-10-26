using System;
using System.Data.SqlClient;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            using (SqlConnection conn = new SqlConnection())
            {
                conn.ConnectionString = "Server=DILIP-PC;Database=School;Trusted_Connection=true";
                // using the code here...

                


            }

            Console.ReadLine();
        }
    }
}