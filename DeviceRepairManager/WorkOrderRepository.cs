using DeviceRepairManager.Models;
using System.Data.SQLite;
using System;
using System.Collections.Generic;

namespace DeviceRepairManager.Repositories
{
    public class WorkOrderRepository : IWorkOrderRepository
    {
        private readonly string _connectionString;

        public WorkOrderRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<WorkOrder> GetAllWorkOrders()
        {
            var list = new List<WorkOrder>();
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("SELECT * FROM WorkOrders", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadWorkOrder(reader));
            }
            return list;
        }

        public WorkOrder? GetWorkOrderById(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("SELECT * FROM WorkOrders WHERE WorkOrderId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);

            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return ReadWorkOrder(reader);
            }
            return null;
        }

        public void AddWorkOrder(WorkOrder workOrder)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand(@"
                INSERT INTO WorkOrders 
                (RepairId, CreationDate, CompletionDate, Status, Priority, Notes, HoursWorked) 
                VALUES 
                (@RepairId, @CreationDate, @CompletionDate, @Status, @Priority, @Notes, @HoursWorked)", conn);

            AddParameters(cmd, workOrder);
            cmd.ExecuteNonQuery();
        }

        public void UpdateWorkOrder(WorkOrder workOrder)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand(@"
                UPDATE WorkOrders SET
                RepairId = @RepairId,
                CreationDate = @CreationDate,
                CompletionDate = @CompletionDate,
                Status = @Status,
                Priority = @Priority,
                Notes = @Notes,
                HoursWorked = @HoursWorked
                WHERE WorkOrderId = @WorkOrderId", conn);

            cmd.Parameters.AddWithValue("@WorkOrderId", workOrder.WorkOrderId);
            AddParameters(cmd, workOrder);
            cmd.ExecuteNonQuery();
        }

        public void DeleteWorkOrder(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("DELETE FROM WorkOrders WHERE WorkOrderId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }

        private void AddParameters(SQLiteCommand cmd, WorkOrder workOrder)
        {
            cmd.Parameters.AddWithValue("@RepairId", workOrder.RepairId);
            cmd.Parameters.AddWithValue("@CreationDate", workOrder.CreationDate);
            cmd.Parameters.AddWithValue("@CompletionDate", workOrder.CompletionDate.HasValue ? (object)workOrder.CompletionDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", workOrder.Status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Priority", workOrder.Priority ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Notes", workOrder.Notes ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@HoursWorked", workOrder.HoursWorked);
        }

        private WorkOrder ReadWorkOrder(SQLiteDataReader reader)
        {
            return new WorkOrder
            {
                WorkOrderId = Convert.ToInt32(reader["WorkOrderId"]),
                RepairId = Convert.ToInt32(reader["RepairId"]),
                CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                CompletionDate = reader["CompletionDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["CompletionDate"]),
                Status = reader["Status"]?.ToString(),
                Priority = reader["Priority"]?.ToString(),
                Notes = reader["Notes"]?.ToString(),
                HoursWorked = Convert.ToDouble(reader["HoursWorked"])
            };
        }
    }
}
