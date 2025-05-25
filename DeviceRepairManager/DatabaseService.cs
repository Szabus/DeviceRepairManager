using System;
using System.Data.SQLite;

namespace DeviceRepairManager
{
    public class DatabaseService
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
,                   PasswordHash         TEXT NOT NULL
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
                    TechnicianId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT NOT NULL,
                    Expertise TEXT,
                    IsAvailable INTEGER NOT NULL DEFAULT 1,
                    TotalWorkHours REAL DEFAULT 0,
                    Email TEXT,
                    PhoneNumber TEXT,
                    HireDate TEXT NOT NULL,
                    IsOnLeave INTEGER NOT NULL DEFAULT 0,
                    CompletedRepairs INTEGER DEFAULT 0,
                    Shift TEXT,
                    PasswordHash TEXT
                );
            ";
            cmd.ExecuteNonQuery();

            cmd.CommandText = @"
                CREATE TABLE IF NOT EXISTS Admins (
                    AdminId INTEGER PRIMARY KEY AUTOINCREMENT,
                    Username TEXT NOT NULL,
                    PasswordHash TEXT NOT NULL,
                    Name TEXT NOT NULL,
                    Email TEXT NOT NULL
                );
            ";
            cmd.ExecuteNonQuery();

            SeedInitialUsers(connection);
        }

        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private void SeedInitialUsers(SQLiteConnection connection)
        {
            using var cmd = new SQLiteCommand(connection);

            
            cmd.CommandText = @"
        INSERT INTO Admins (Username, PasswordHash, Name, Email)
        SELECT 'admin', 'admin123', 'Rendszergazda', 'admin@example.com'
        WHERE NOT EXISTS (SELECT 1 FROM Admins WHERE Username = 'admin');
    ";
            cmd.ExecuteNonQuery();

            
            cmd.CommandText = @"
        INSERT INTO Customers (Name, ContactInfo, Address, Email, PhoneNumber, RegistrationDate, IsVIP, PreferredContactMethod, LastInteractionDate, PasswordHash)
        SELECT 'Teszt Ügyfél', '06201234567', 'Teszt utca 1', 'customer@example.com', '06201234567', datetime('now'), 0, 'Email', datetime('now'), 'customer123'
        WHERE NOT EXISTS (SELECT 1 FROM Customers WHERE Email = 'customer@example.com');
    ";
            cmd.ExecuteNonQuery();


            cmd.CommandText = @"
        INSERT INTO Technicians (Name, Expertise, IsAvailable, TotalWorkHours, Email, PhoneNumber, HireDate, IsOnLeave, CompletedRepairs, Shift, PasswordHash)
        SELECT 'Technikus Béla', 'Laptop javítás', 1, 0.0, 'tech@example.com', '06201112222', datetime('now'), 0, 0, 'Reggel', 'tech123'
        WHERE NOT EXISTS (SELECT 1 FROM Technicians WHERE Email = 'tech@example.com');
";
            cmd.ExecuteNonQuery();
        }
    }
}
