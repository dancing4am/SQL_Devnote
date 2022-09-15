using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace SQL_Devnote
{
    internal sealed class DBManager
    {
        internal static readonly DBManager Instance = new DBManager();
        MySqlConnection connection;
        private DBManager()
        {
            string connectionStr = "server=localhost;database=devnote;uid=root;pwd=\"\";";
            connection = new MySqlConnection(connectionStr);
        }

        // https://www.c-sharpcorner.com/UploadFile/9582c9/insert-update-delete-display-data-in-mysql-using-C-Sharp/
        // https://zetcode.com/csharp/mysql/
        // http://localhost/phpmyadmin/index.php?route=/database/structure&db=devnote

        internal void Connect()
        {
            try
            {
                connection.Open();
                Console.WriteLine("     Database connected");
                Console.WriteLine($"        MySQL version : {connection.ServerVersion}");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        internal void Disconnect()
        {
            try
            {
                connection.Close();
                Console.WriteLine("     Database disconnected");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadKey();
            }
        }

        internal void CreateTable()
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "DROP TABLE IF EXISTS cars";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"CREATE TABLE cars(id INTEGER PRIMARY KEY AUTO_INCREMENT,
        name TEXT, price INT)";
            cmd.ExecuteNonQuery();
        }

        internal void InsertData()
        {
            using var cmd = new MySqlCommand();
            cmd.Connection = connection;

            cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',52642)";
            cmd.ExecuteNonQuery();
        }
    }
}
