using System;
using System.Data.SQLite;

namespace DeviceRepairManager.Data
{
    internal class DatabaseService
    {
        private readonly string _connectionString;

        public DatabaseService(string databaseFilePath)
        {
            _connectionString = $"Data Source={databaseFilePath};Version=3;";
            InitializeDatabase();
        }

        private void InitializeDatabase()
        {
            using var connection = new SQLiteConnection(_connectionString);
            connection.Open();

            using var cmd = new SQLiteCommand(connection);

            
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Customers (
                    CustomerId           INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                 TEXT    NOT NULL,
                    ContactInfo          TEXT,
                    Address              TEXT,
                    Email                TEXT,
                    PhoneNumber          TEXT,
                    RegistrationDate     TEXT    NOT NULL,
                    IsVIP                INTEGER NOT NULL,
                    PreferredContactMethod TEXT,
                    LastInteractionDate  TEXT
                );
            ";
            cmd.ExecuteNonQuery();

           
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Devices (
                    DeviceId        INTEGER PRIMARY KEY AUTOINCREMENT,
                    Type            TEXT,
                    Brand           TEXT,
                    Model           TEXT,
                    SerialNumber    TEXT,
                    CustomerId      INTEGER NOT NULL,
                    PurchaseDate    TEXT    NOT NULL,
                    WarrantyStatus  TEXT,
                    Condition       TEXT,
                    Location        TEXT,
                    Color           TEXT,
                    FOREIGN KEY(CustomerId) REFERENCES Customers(CustomerId)
                );
            ";
            cmd.ExecuteNonQuery();

         
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Repairs (
                    RepairId            INTEGER PRIMARY KEY AUTOINCREMENT,
                    DeviceId            INTEGER NOT NULL,
                    CustomerId          INTEGER NOT NULL,
                    StartDate           TEXT    NOT NULL,
                    Status              TEXT,
                    Description         TEXT,
                    CustomerApproved    INTEGER NOT NULL,
                    EndDate             TEXT,
                    Notes               TEXT,
                    RepairCount         INTEGER NOT NULL,
                    IsUnderRepair       INTEGER NOT NULL,
                    ErrorCode           TEXT,
                    EstimatedCost       REAL,
                    FOREIGN KEY(DeviceId)   REFERENCES Devices(DeviceId),
                    FOREIGN KEY(CustomerId) REFERENCES Customers(CustomerId)
                );
            ";
            cmd.ExecuteNonQuery();

            
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS WorkOrders (
                    WorkOrderId         INTEGER PRIMARY KEY AUTOINCREMENT,
                    RepairId            INTEGER NOT NULL,
                    CreationDate        TEXT    NOT NULL,
                    CompletionDate      TEXT,
                    Status              TEXT,
                    Priority            TEXT,
                    Notes               TEXT,
                    HoursWorked         REAL    NOT NULL,
                    RequiresApproval    INTEGER NOT NULL,
                    CreatedBy           TEXT,
                    FOREIGN KEY(RepairId) REFERENCES Repairs(RepairId)
                );
            ";
            cmd.ExecuteNonQuery();

           
            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Technicians (
                    TechnicianId        INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name                TEXT    NOT NULL,
                    Expertise           TEXT,
                    IsAvailable         INTEGER NOT NULL,
                    TotalWorkHours      REAL    NOT NULL,
                    Email               TEXT,
                    PhoneNumber         TEXT,
                    HireDate            TEXT    NOT NULL,
                    IsOnLeave           INTEGER NOT NULL,
                    CompletedRepairs    INTEGER NOT NULL,
                    Shift               TEXT
                );
            ";
            cmd.ExecuteNonQuery();
        }

        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            return conn;
        }
    }
}
