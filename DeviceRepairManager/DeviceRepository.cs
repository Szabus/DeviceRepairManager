using DeviceRepairManager.Models;
using Microsoft.Data.Sqlite;
using System.Collections.Generic;

namespace DeviceRepairManager.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly string _connectionString;

        public DeviceRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddDevice(Device device)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"INSERT INTO Devices 
                  (Type, Brand, Model, SerialNumber, CustomerId, PurchaseDate, WarrantyStatus, Location, Color)
                  VALUES (@Type, @Brand, @Model, @SerialNumber, @CustomerId, @PurchaseDate, @WarrantyStatus, @Location, @Color)";
            command.Parameters.AddWithValue("@Type", device.Type ?? "");
            command.Parameters.AddWithValue("@Brand", device.Brand ?? "");
            command.Parameters.AddWithValue("@Model", device.Model ?? "");
            command.Parameters.AddWithValue("@SerialNumber", device.SerialNumber ?? "");
            command.Parameters.AddWithValue("@CustomerId", device.CustomerId);
            command.Parameters.AddWithValue("@PurchaseDate", device.PurchaseDate);
            command.Parameters.AddWithValue("@WarrantyStatus", device.WarrantyStatus ?? "");
            command.Parameters.AddWithValue("@Location", device.Location ?? "");
            command.Parameters.AddWithValue("@Color", device.Color ?? "");

            command.ExecuteNonQuery();
        }

        public void UpdateDevice(Device device)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText =
                @"UPDATE Devices SET
                    Type = @Type,
                    Brand = @Brand,
                    Model = @Model,
                    SerialNumber = @SerialNumber,
                    CustomerId = @CustomerId,
                    PurchaseDate = @PurchaseDate,
                    WarrantyStatus = @WarrantyStatus,
                    Condition = @Condition,
                    Location = @Location,
                    Color = @Color
                  WHERE DeviceId = @DeviceId";

            command.Parameters.AddWithValue("@DeviceId", device.DeviceId);
            command.Parameters.AddWithValue("@Type", device.Type ?? "");
            command.Parameters.AddWithValue("@Brand", device.Brand ?? "");
            command.Parameters.AddWithValue("@Model", device.Model ?? "");
            command.Parameters.AddWithValue("@SerialNumber", device.SerialNumber ?? "");
            command.Parameters.AddWithValue("@CustomerId", device.CustomerId);
            command.Parameters.AddWithValue("@PurchaseDate", device.PurchaseDate);
            command.Parameters.AddWithValue("@WarrantyStatus", device.WarrantyStatus ?? "");
            command.Parameters.AddWithValue("@Location", device.Location ?? "");
            command.Parameters.AddWithValue("@Color", device.Color ?? "");

            command.ExecuteNonQuery();
        }

        public void DeleteDevice(int deviceId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"DELETE FROM Devices WHERE DeviceId = @DeviceId";
            command.Parameters.AddWithValue("@DeviceId", deviceId);

            command.ExecuteNonQuery();
        }

        public Device? GetDeviceById(int deviceId)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Devices WHERE DeviceId = @DeviceId";
            command.Parameters.AddWithValue("@DeviceId", deviceId);

            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return ReadDevice(reader);
            }

            return null;
        }

        public List<Device> GetAllDevices()
        {
            var devices = new List<Device>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Devices";

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                devices.Add(ReadDevice(reader));
            }

            return devices;
        }

        public List<Device> GetDevicesByCustomerId(int customerId)
        {
            var devices = new List<Device>();
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();

            var command = connection.CreateCommand();
            command.CommandText = @"SELECT * FROM Devices WHERE CustomerId = @CustomerId";
            command.Parameters.AddWithValue("@CustomerId", customerId);

            using var reader = command.ExecuteReader();
            while (reader.Read())
            {
                devices.Add(ReadDevice(reader));
            }

            return devices;
        }

        private Device ReadDevice(SqliteDataReader reader)
        {
            return new Device
            {
                DeviceId = reader.GetInt32(0),
                Type = reader.GetString(1),
                Brand = reader.GetString(2),
                Model = reader.GetString(3),
                SerialNumber = reader.GetString(4),
                CustomerId = reader.GetInt32(5),
                PurchaseDate = reader.GetDateTime(6),
                WarrantyStatus = reader.GetString(7),
                Location = reader.GetString(8),
                Color = reader.GetString(9)
            };
        }
    }
}
