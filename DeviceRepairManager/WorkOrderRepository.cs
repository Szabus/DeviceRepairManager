using System;
using System.Collections.Generic;
using System.Data.SQLite;
using DeviceRepairManager.Models;

namespace DeviceRepairManager.Repositories
{
    public class WorkOrderRepository
    {
        private readonly SQLiteConnection _connection;

        public WorkOrderRepository(SQLiteConnection connection)
        {
            _connection = connection;
        }

        public void AddWorkOrder(WorkOrder workOrder)
        {
            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = @"
                    INSERT INTO WorkOrders
                    (CreationDate, CompletionDate, Status, Priority, Notes, HoursWorked, RequiresApproval, CreatedBy)
                    VALUES 
                    (@CreationDate, @CompletionDate, @Status, @Priority, @Notes, @HoursWorked, @RequiresApproval, @CreatedBy);
                ";

               // cmd.Parameters.AddWithValue("@RepairId", workOrder.RepairId);
                cmd.Parameters.AddWithValue("@CreationDate", workOrder.CreationDate);
                cmd.Parameters.AddWithValue("@CompletionDate", (object?)workOrder.CompletionDate ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Status", workOrder.Status ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Priority", workOrder.Priority ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Notes", workOrder.Notes ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@HoursWorked", workOrder.HoursWorked);
                cmd.Parameters.AddWithValue("@RequiresApproval", workOrder.RequiresApproval ? 1 : 0);
                cmd.Parameters.AddWithValue("@CreatedBy", workOrder.CreatedBy ?? (object)DBNull.Value);

                cmd.ExecuteNonQuery();
            }
        }

        public WorkOrder? GetWorkOrderById(int id)
        {
            using var cmd = new SQLiteCommand("SELECT * FROM WorkOrders WHERE WorkOrderId = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                return ReadWorkOrder(reader);
            }
            return null;
        }

        public List<WorkOrder> GetAllWorkOrders()
        {
            var list = new List<WorkOrder>();

            using var cmd = new SQLiteCommand("SELECT * FROM WorkOrders", _connection);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                list.Add(ReadWorkOrder(reader));
            }
            return list;
        }

        public void UpdateWorkOrder(WorkOrder workOrder)
        {
            using var cmd = new SQLiteCommand(@"
                UPDATE WorkOrders SET
                    CreationDate = @CreationDate,
                    CompletionDate = @CompletionDate,
                    Status = @Status,
                    Priority = @Priority,
                    Notes = @Notes,
                    HoursWorked = @HoursWorked,
                    RequiresApproval = @RequiresApproval,
                    CreatedBy = @CreatedBy
                WHERE WorkOrderId = @WorkOrderId", _connection);

            cmd.Parameters.AddWithValue("@WorkOrderId", workOrder.WorkOrderId);
           // cmd.Parameters.AddWithValue("@RepairId", workOrder.RepairId);
            cmd.Parameters.AddWithValue("@CreationDate", workOrder.CreationDate);
            cmd.Parameters.AddWithValue("@CompletionDate", workOrder.CompletionDate.HasValue ? (object)workOrder.CompletionDate.Value : DBNull.Value);
            cmd.Parameters.AddWithValue("@Status", workOrder.Status ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Priority", workOrder.Priority ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@Notes", workOrder.Notes ?? (object)DBNull.Value);
            cmd.Parameters.AddWithValue("@HoursWorked", workOrder.HoursWorked);
            cmd.Parameters.AddWithValue("@RequiresApproval", workOrder.RequiresApproval);
            cmd.Parameters.AddWithValue("@CreatedBy", workOrder.CreatedBy ?? (object)DBNull.Value);

            cmd.ExecuteNonQuery();
        }

        private WorkOrder ReadWorkOrder(SQLiteDataReader reader)
        {
            return new WorkOrder
            {
                WorkOrderId = Convert.ToInt32(reader["WorkOrderId"]),
                CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                CompletionDate = reader["CompletionDate"] == DBNull.Value ? null : (DateTime?)Convert.ToDateTime(reader["CompletionDate"]),
                Status = reader["Status"]?.ToString(),
                Priority = reader["Priority"]?.ToString(),
                Notes = reader["Notes"]?.ToString(),
                HoursWorked = Convert.ToInt32(reader["HoursWorked"]),
                RequiresApproval = Convert.ToBoolean(reader["RequiresApproval"]),
                CreatedBy = reader["CreatedBy"]?.ToString(),
            };
        }

        public List<WorkOrder> GetWorkOrdersByCustomer(int customerId)
        {
            var result = new List<WorkOrder>();

            using (var cmd = _connection.CreateCommand())
            {
                cmd.CommandText = @"
                    SELECT w.*
                    FROM WorkOrders w
                    JOIN Devices d ON w.RepairId = d.DeviceId
                    WHERE d.CustomerId = @CustomerId;
                ";

                cmd.Parameters.AddWithValue("@CustomerId", customerId);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var order = new WorkOrder
                        {
                            WorkOrderId = reader.GetInt32(reader.GetOrdinal("WorkOrderId")),
                            CreationDate = reader.GetDateTime(reader.GetOrdinal("CreationDate")),
                            CompletionDate = reader.IsDBNull(reader.GetOrdinal("CompletionDate"))
                                             ? null
                                             : reader.GetDateTime(reader.GetOrdinal("CompletionDate")),
                            Status = reader["Status"]?.ToString(),
                            Priority = reader["Priority"]?.ToString(),
                            Notes = reader["Notes"]?.ToString(),
                            HoursWorked = reader.GetDouble(reader.GetOrdinal("HoursWorked")),
                            RequiresApproval = reader.GetInt32(reader.GetOrdinal("RequiresApproval")) == 1,
                            CreatedBy = reader["CreatedBy"]?.ToString()
                        };

                        result.Add(order);
                    }
                }
            }

            return result;
        }
    }
}
