using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

using MySql.Data;
using MySql.Data.MySqlClient;

public class Database
{
    public static void Main()
    {
        string connStr = "Server=https://remotemysql.com;Database=4aFmYHwu0U;Uid=root;Pwd=xCTX0SISaD;";

        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {
            Console.WriteLine("Connecting to MySQL...");
            conn.Open();

            Console.WriteLine("Connected to MySQL...");
            rdr.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        conn.Close();
        Console.WriteLine("Done.");
    }
}
