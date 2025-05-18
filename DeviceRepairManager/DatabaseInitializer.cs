using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeviceRepairManager
{
    internal class DatabaseInitializer
    {
        public static void Initialize()
        {
            string dbPath = "Data/repairshop.db";
            if (!File.Exists(dbPath))
            {
                using var connection = new SqliteConnection($"Data Source={dbPath}");
                connection.Open();

                var command = connection.CreateCommand();

                command.CommandText = @"
                CREATE TABLE Customer (
                    CustomerId INTEGER PRIMARY KEY,
                    Name TEXT,
                    ContactInfo TEXT,
                    Address TEXT,
                    Email TEXT,
                    PhoneNumber TEXT,
                    PostalCode TEXT,
                    City TEXT,
                    RegistrationDate TEXT,
                    IsVIP INTEGER,
                    Notes TEXT
                );
            ";
                command.ExecuteNonQuery();
            }
        }
    }
}
