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
                    TechnicianId        INTEGER NOT NULL,   
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

            SeedInitialData(connection);
        }

        public SQLiteConnection GetConnection()
        {
            var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            return conn;
        }

        private void SeedInitialData(SQLiteConnection connection)
        {
            using var cmd = new SQLiteCommand(connection);

            // Insert Admin
            cmd.CommandText = @"
        INSERT INTO Admins (Username, PasswordHash, Name, Email)
        SELECT 'admin', 'admin123', 'Rendszergazda', 'admin@example.com'
        WHERE NOT EXISTS (SELECT 1 FROM Admins WHERE Username = 'admin');
    ";
            cmd.ExecuteNonQuery();

            // Insert Customers
            var customers = new (string Name, string ContactInfo, string Address, string Email, string PhoneNumber, string PasswordHash)[]
            {
        ("Kovács Péter", "06201234567", "Fő utca 1", "kovacs.peter@example.com", "06201234567", "peter123"),
        ("Nagy Anna", "06209876543", "Kossuth tér 2", "nagy.anna@example.com", "06209876543", "anna123"),
        ("Szabó László", "06203456789", "Ady Endre utca 5", "szabo.laszlo@example.com", "06203456789", "laszlo123"),
        ("Tóth Éva", "06205678901", "Petőfi utca 10", "toth.eva@example.com", "06205678901", "eva123"),
        ("Molnár Gábor", "06201239876", "Rákóczi út 8", "molnar.gabor@example.com", "06201239876", "gabor123"),
        ("Kiss Dóra", "06204445566", "Bartók Béla út 9", "kiss.dora@example.com", "06204445566", "dora123")
            };

            foreach (var c in customers)
            {
                cmd.CommandText = @"
            INSERT INTO Customers (Name, ContactInfo, Address, Email, PhoneNumber, RegistrationDate, IsVIP, PreferredContactMethod, LastInteractionDate, PasswordHash)
            SELECT @Name, @ContactInfo, @Address, @Email, @PhoneNumber, datetime('now'), 0, 'Email', datetime('now'), @PasswordHash
            WHERE NOT EXISTS (SELECT 1 FROM Customers WHERE Email = @Email);
        ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Name", c.Name);
                cmd.Parameters.AddWithValue("@ContactInfo", c.ContactInfo);
                cmd.Parameters.AddWithValue("@Address", c.Address);
                cmd.Parameters.AddWithValue("@Email", c.Email);
                cmd.Parameters.AddWithValue("@PhoneNumber", c.PhoneNumber);
                cmd.Parameters.AddWithValue("@PasswordHash", c.PasswordHash);
                cmd.ExecuteNonQuery();
            }

            // Insert Devices
            var devices = new (string Type, string Brand, string Model, string SerialNumber, int CustomerId, string PurchaseDate, string WarrantyStatus, string Location, string Color)[]
            {
        ("Laptop", "Dell", "XPS 13", "SN12345601", 1, "2022-01-15", "Érvényes", "Budapest", "Ezüst"),
        ("Telefon", "Samsung", "Galaxy S21", "SN12345602", 1, "2021-11-03", "Lejárt", "Pécs", "Fekete"),
        ("Tablet", "Apple", "iPad Air", "SN12345603", 2, "2023-03-01", "Érvényes", "Szeged", "Fehér"),
        ("Laptop", "HP", "EliteBook", "SN12345604", 2, "2021-07-22", "Lejárt", "Budapest", "Szürke"),
        ("Telefon", "Apple", "iPhone 13", "SN12345605", 3, "2022-12-10", "Érvényes", "Debrecen", "Fekete"),
        ("Tablet", "Samsung", "Galaxy Tab S7", "SN12345606", 3, "2023-01-05", "Érvényes", "Debrecen", "Kék"),
        ("Laptop", "Lenovo", "ThinkPad X1", "SN12345607", 4, "2020-05-18", "Lejárt", "Győr", "Fekete"),
        ("Telefon", "OnePlus", "9 Pro", "SN12345608", 4, "2022-09-30", "Érvényes", "Győr", "Fehér"),
        ("Laptop", "Asus", "ZenBook", "SN12345609", 5, "2023-02-20", "Érvényes", "Miskolc", "Kék"),
        ("Tablet", "Microsoft", "Surface Pro", "SN12345610", 5, "2021-08-14", "Lejárt", "Miskolc", "Ezüst"),
        ("Telefon", "Google", "Pixel 6", "SN12345611", 1, "2023-04-01", "Érvényes", "Budapest", "Fehér"),
        ("Laptop", "Acer", "Swift 3", "SN12345612", 3, "2022-06-30", "Érvényes", "Szeged", "Fekete"),
        ("Tablet", "Huawei", "MatePad", "SN12345613", 6, "2022-03-10", "Érvényes", "Szolnok", "Fehér"),
        ("Telefon", "Nokia", "G21", "SN12345614", 6, "2021-11-11", "Lejárt", "Szolnok", "Kék")
            };

            foreach (var d in devices)
            {
                cmd.CommandText = @"
            INSERT INTO Devices (Type, Brand, Model, SerialNumber, CustomerId, PurchaseDate, WarrantyStatus, Location, Color)
            SELECT @Type, @Brand, @Model, @SerialNumber, @CustomerId, @PurchaseDate, @WarrantyStatus, @Location, @Color
            WHERE NOT EXISTS (SELECT 1 FROM Devices WHERE SerialNumber = @SerialNumber);
        ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Type", d.Type);
                cmd.Parameters.AddWithValue("@Brand", d.Brand);
                cmd.Parameters.AddWithValue("@Model", d.Model);
                cmd.Parameters.AddWithValue("@SerialNumber", d.SerialNumber);
                cmd.Parameters.AddWithValue("@CustomerId", d.CustomerId);
                cmd.Parameters.AddWithValue("@PurchaseDate", d.PurchaseDate);
                cmd.Parameters.AddWithValue("@WarrantyStatus", d.WarrantyStatus);
                cmd.Parameters.AddWithValue("@Location", d.Location);
                cmd.Parameters.AddWithValue("@Color", d.Color);
                cmd.ExecuteNonQuery();
            }

            // Insert Technician
            cmd.CommandText = @"
        INSERT INTO Technicians (Name, Email, PhoneNumber, PasswordHash, HireDate)
        SELECT 'Szerelő Béla', 'tech1@example.com', '06201112222', 'tech123', DATE('now')
        WHERE NOT EXISTS (SELECT 1 FROM Technicians WHERE Email = 'tech1@example.com');
    ";
            cmd.ExecuteNonQuery();

            // Insert Repairs
            var repairs = new[]
            {
        (DeviceId: 1, CustomerId: 1, TechnicianId: 1, Status: "Folyamatban", Description: "Alaplap csere", RepairCount: 1),
        (DeviceId: 2, CustomerId: 1, TechnicianId: 1, Status: "Befejezve", Description: "Képernyő javítás", RepairCount: 2),
        (DeviceId: 3, CustomerId: 2, TechnicianId: 1, Status: "Folyamatban", Description: "Akkumulátor csere", RepairCount: 1),
        (DeviceId: 5, CustomerId: 3, TechnicianId: 1, Status: "Árajánlat", Description: "Töltési probléma", RepairCount: 1)
    };

            foreach (var r in repairs)
            {
                cmd.CommandText = @"
            INSERT INTO Repairs
            (DeviceId, CustomerId, TechnicianId, StartDate, Status, Description, CustomerApproved, EndDate, Notes, RepairCount, IsUnderRepair)
            SELECT @DeviceId, @CustomerId, @TechnicianId, DATE('now'), @Status, @Description, 1, NULL, '', @RepairCount, 1
            WHERE NOT EXISTS (
                SELECT 1 FROM Repairs WHERE DeviceId = @DeviceId AND CustomerId = @CustomerId
            );
        ";
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@DeviceId", r.DeviceId);
                cmd.Parameters.AddWithValue("@CustomerId", r.CustomerId);
                cmd.Parameters.AddWithValue("@TechnicianId", r.TechnicianId);
                cmd.Parameters.AddWithValue("@Status", r.Status);
                cmd.Parameters.AddWithValue("@Description", r.Description);
                cmd.Parameters.AddWithValue("@RepairCount", r.RepairCount);
                cmd.ExecuteNonQuery();
            }
        }
    }
}