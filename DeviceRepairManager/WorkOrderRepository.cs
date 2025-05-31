using System;
using System.Collections.Generic;
using System.Data.SQLite;
using DeviceRepairManager.Models;

namespace DeviceRepairManager.Repositories
{
    public class WorkOrderRepository
    {
        private readonly SQLiteConnection _connection;
        private readonly CustomerRepository _customerRepo;

        public WorkOrderRepository(SQLiteConnection connection)
        {
            _connection = connection;
            _customerRepo = new CustomerRepository(connection);
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

        public void DeleteWorkOrder(int id)
        {
            using var cmd = new SQLiteCommand("DELETE FROM WorkOrders WHERE WorkOrderId = @id", _connection);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
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
            var workOrders = new List<WorkOrder>();

            string customerName = _customerRepo.GetCustomerNameById(customerId); 
            string query = "SELECT * FROM WorkOrders WHERE CreatedBy = @createdBy";

            using (var cmd = new SQLiteCommand(query, _connection))
            {
                cmd.Parameters.AddWithValue("@createdBy", customerName);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var workOrder = new WorkOrder
                        {
                            WorkOrderId = Convert.ToInt32(reader["WorkOrderId"]),
                            CreatedBy = reader["CreatedBy"].ToString(),
                            CreationDate = Convert.ToDateTime(reader["CreationDate"]),
                            Priority = reader["Priority"]?.ToString(),
                            Status = reader["Status"]?.ToString(),
                            CompletionDate = reader["CompletionDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["CompletionDate"]),
                            Notes = reader["Notes"]?.ToString(),
                            HoursWorked = reader["HoursWorked"] != DBNull.Value ? Convert.ToInt32(reader["HoursWorked"]) : 0,
                            RequiresApproval = reader["RequiresApproval"] != DBNull.Value && Convert.ToBoolean(reader["RequiresApproval"])
                        };

                        workOrders.Add(workOrder);
                    }
                }
            }

            return workOrders;
        }
    }
}
