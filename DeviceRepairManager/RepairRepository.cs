using DeviceRepairManager.Models;
using System.Data.SQLite;
using System;
using System.Collections.Generic;

namespace DeviceRepairManager.Repositories
{
    public class RepairRepository : IRepairRepository
    {
        private readonly string _connectionString;

        public RepairRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Repair> GetAllRepairs()
        {
            var repairs = new List<Repair>();

            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("SELECT * FROM Repairs", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                repairs.Add(ReadRepair(reader));
            }
            return repairs;
        }

        public Repair? GetRepairById(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("SELECT * FROM Repairs WHERE RepairId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return ReadRepair(reader);
            }
            return null;
        }

        public void AddRepair(Repair repair)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand(@"
                INSERT INTO Repairs
                (DeviceId, CustomerId, StartDate, Status, Description, CustomerApproved, EndDate, Notes, RepairCount, IsUnderRepair)
                VALUES
                (@DeviceId, @CustomerId, @StartDate, @Status, @Description, @CustomerApproved, @EndDate, @Notes, @RepairCount, @IsUnderRepair)", conn);

            AddParameters(cmd, repair);
            cmd.ExecuteNonQuery();
        }

        public void UpdateRepair(Repair repair)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand(@"
                UPDATE Repairs SET
                DeviceId = @DeviceId,
                CustomerId = @CustomerId,
                StartDate = @StartDate,
                Status = @Status,
                Description = @Description,
                CustomerApproved = @CustomerApproved,
                EndDate = @EndDate,
                Notes = @Notes,
                RepairCount = @RepairCount,
                IsUnderRepair = @IsUnderRepair
                WHERE RepairId = @RepairId", conn);

            cmd.Parameters.AddWithValue("@RepairId", repair.RepairId);
            AddParameters(cmd, repair);
            cmd.ExecuteNonQuery();
        }

        public void DeleteRepair(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("DELETE FROM Repairs WHERE RepairId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private void AddParameters(SQLiteCommand cmd, Repair repair)
        {
            cmd.Parameters.AddWithValue("@DeviceId", repair.DeviceId);
            cmd.Parameters.AddWithValue("@CustomerId", repair.CustomerId);
            cmd.Parameters.AddWithValue("@StartDate", repair.StartDate);
            cmd.Parameters.AddWithValue("@Status", repair.Status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", repair.Description ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@CustomerApproved", repair.CustomerApproved);
            cmd.Parameters.AddWithValue("@EndDate", repair.EndDate.HasValue ? (object)repair.EndDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Notes", repair.Notes ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@RepairCount", repair.RepairCount);
            cmd.Parameters.AddWithValue("@IsUnderRepair", repair.IsUnderRepair);
        }

        private Repair ReadRepair(SQLiteDataReader reader)
        {
            return new Repair
            {
                RepairId = Convert.ToInt32(reader["RepairId"]),
                DeviceId = Convert.ToInt32(reader["DeviceId"]),
                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                Status = reader["Status"]?.ToString(),
                Description = reader["Description"]?.ToString(),
                CustomerApproved = Convert.ToBoolean(reader["CustomerApproved"]),
                EndDate = reader["EndDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["EndDate"]),
                Notes = reader["Notes"]?.ToString(),
                RepairCount = Convert.ToInt32(reader["RepairCount"]),
                IsUnderRepair = Convert.ToBoolean(reader["IsUnderRepair"])
            };
        }
    }
}
