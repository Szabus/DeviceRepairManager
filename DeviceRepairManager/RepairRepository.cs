using DeviceRepairManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace DeviceRepairManager.Repositories
{
    public class RepairRepository
    {
        private readonly SQLiteConnection _connection;

        public RepairRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public List<Repair> GetAllRepairs()
        {
            var repairs = new List<Repair>();

            using var cmd = new SQLiteCommand("SELECT * FROM Repairs", _connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                repairs.Add(ReadRepair(reader));
            }
            return repairs;
        }

        public Repair? GetRepairById(int id)
        {
            using var cmd = new SQLiteCommand("SELECT * FROM Repairs WHERE RepairId = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return ReadRepair(reader);
            }
            return null;
        }

        // Ez a metódus kell neked a formhoz: javítások lekérése munkalap alapján
        public List<Repair> GetRepairsByWorkOrderId(int workOrderId)
        {
            var repairs = new List<Repair>();

            // Feltételezem, hogy a Repair táblában van egy WorkOrderId oszlop (ha nincs, akkor a javításokat másképp kell lekérni)
            using var cmd = new SQLiteCommand("SELECT * FROM Repairs WHERE WorkOrderId = @workOrderId", _connection);
            cmd.Parameters.AddWithValue("@workOrderId", workOrderId);
            using var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                repairs.Add(ReadRepair(reader));
            }
            return repairs;
        }

        public void UpdateRepair(Repair repair)
        {
            using var cmd = new SQLiteCommand(@"
                UPDATE Repairs SET
                DeviceId = @DeviceId,
                TechnicianId = @TechnicianId,
                StartDate = @StartDate,
                EndDate = @EndDate,
                Status = @Status,
                Description = @Description
                WHERE RepairId = @RepairId", _connection);

            cmd.Parameters.AddWithValue("@RepairId", repair.RepairId);
            cmd.Parameters.AddWithValue("@DeviceId", repair.DeviceId);
            cmd.Parameters.AddWithValue("@TechnicianId", repair.TechnicianId);
            cmd.Parameters.AddWithValue("@StartDate", repair.StartDate);
            cmd.Parameters.AddWithValue("@EndDate", repair.EndDate.HasValue ? (object)repair.EndDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", repair.Status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Description", repair.Description ?? (object)DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        // Egyéb CRUD metódusok is hozzáadhatók, ha szükséges

        private Repair ReadRepair(SQLiteDataReader reader)
        {
            return new Repair
            {
                RepairId = Convert.ToInt32(reader["RepairId"]),
                DeviceId = Convert.ToInt32(reader["DeviceId"]),
                TechnicianId = Convert.ToInt32(reader["DeviceId"]),
                StartDate = Convert.ToDateTime(reader["StartDate"]),
                EndDate = reader["EndDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["EndDate"]),
                Status = reader["Status"]?.ToString(),
                Description = reader["Description"]?.ToString(),
            };
        }
    }
}
