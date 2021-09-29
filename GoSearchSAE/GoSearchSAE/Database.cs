using System;
using Npgsql;

namespace DBPrj
{
    class Program
    {
        static void Main(string[] args)
        {
            bool boolfound = false;
            using (NpgsqlConnection conn = new NpgsqlConnection("Server=<localhost>; Port=5432; User Id=postgres; Password=passwort; Database=GoSearch"))
            {
                conn.Open();

                NpgsqlCommand cmd = new NpgsqlCommand("SELECT * FROM GoSearch", conn);
                NpgsqlDataReader dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    boolfound = true;
                    Console.WriteLine("connection established");
                }
                if (boolfound == false)
                {
                    Console.WriteLine("Data does not exist");
                }
                dr.Close();
            }
        }
    }
}
