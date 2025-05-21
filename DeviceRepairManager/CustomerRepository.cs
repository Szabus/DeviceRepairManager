using System;
using System.Collections.Generic;
using System.Data.SQLite;
using DeviceRepairManager.Models;

namespace DeviceRepairManager.Data
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly DatabaseService _db;

        public CustomerRepository(DatabaseService db) => _db = db;

        public void Add(Customer customer)
        {
            using var conn = _db.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Customers
                  (Name, ContactInfo, Address, Email, PhoneNumber, RegistrationDate, IsVIP)
                VALUES
                  (@Name, @ContactInfo, @Address, @Email, @PhoneNumber, @RegistrationDate, @IsVIP);
            ";
            cmd.Parameters.AddWithValue("@Name", customer.Name ?? "");
            cmd.Parameters.AddWithValue("@ContactInfo", customer.ContactInfo ?? "");
            cmd.Parameters.AddWithValue("@Address", customer.Address ?? "");
            cmd.Parameters.AddWithValue("@Email", customer.Email ?? "");
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber ?? "");
            cmd.Parameters.AddWithValue("@RegistrationDate", customer.RegistrationDate.ToString("o"));
            cmd.Parameters.AddWithValue("@IsVIP", customer.IsVIP ? 1 : 0);
            cmd.ExecuteNonQuery();
        }

        public List<Customer> GetAll()
        {
            var list = new List<Customer>();
            using var conn = _db.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "SELECT * FROM Customers";
            using var rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                list.Add(new Customer
                {
                    CustomerId = rdr.GetInt32(0),
                    Name = rdr.GetString(1),
                    ContactInfo = rdr.GetString(2),
                    Address = rdr.GetString(3),
                    Email = rdr.GetString(4),
                    PhoneNumber = rdr.GetString(5),
                    RegistrationDate = DateTime.Parse(rdr.GetString(6)),
                    IsVIP = rdr.GetInt32(7) == 1
                });
            }
            return list;
        }

        public void Update(Customer customer)
        {
            using var conn = _db.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                UPDATE Customers SET
                  Name = @Name,
                  ContactInfo = @ContactInfo,
                  Address = @Address,
                  Email = @Email,
                  PhoneNumber = @PhoneNumber,
                  IsVIP = @IsVIP
                WHERE CustomerId = @CustomerId;
            ";
            cmd.Parameters.AddWithValue("@Name", customer.Name ?? "");
            cmd.Parameters.AddWithValue("@ContactInfo", customer.ContactInfo ?? "");
            cmd.Parameters.AddWithValue("@Address", customer.Address ?? "");
            cmd.Parameters.AddWithValue("@Email", customer.Email ?? "");
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber ?? "");
            cmd.Parameters.AddWithValue("@IsVIP", customer.IsVIP ? 1 : 0);
            cmd.Parameters.AddWithValue("@CustomerId", customer.CustomerId);
            cmd.ExecuteNonQuery();
        }

        public void Delete(int customerId)
        {
            using var conn = _db.GetConnection();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            cmd.ExecuteNonQuery();
        }
    }
}
