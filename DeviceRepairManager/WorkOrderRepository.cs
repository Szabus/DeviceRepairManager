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
                    (RepairId, CreationDate, CompletionDate, Status, Priority, Notes, HoursWorked, RequiresApproval, CreatedBy)
                    VALUES 
                    (@RepairId, @CreationDate, @CompletionDate, @Status, @Priority, @Notes, @HoursWorked, @RequiresApproval, @CreatedBy);
                ";

                cmd.Parameters.AddWithValue("@RepairId", workOrder.RepairId);
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
                            RepairId = reader.GetInt32(reader.GetOrdinal("RepairId")),
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
