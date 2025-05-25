using DeviceRepairManager.Models;
using System.Data.SQLite;

public class WorkOrderRepository
{
    private readonly SQLiteConnection _conn;

    public WorkOrderRepository(SQLiteConnection conn)
    {
        _conn = conn;
    }

    public List<WorkOrder> GetAllWorkOrders()
    {
        var list = new List<WorkOrder>();
        using var cmd = new SQLiteCommand("SELECT * FROM WorkOrders", _conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new WorkOrder
            {
                WorkOrderId = Convert.ToInt32(reader["WorkOrderId"]),
                RepairId = Convert.ToInt32(reader["RepairId"]),
                CreationDate = DateTime.Parse(reader["CreationDate"].ToString()),
                CompletionDate = reader["CompletionDate"] == DBNull.Value ? (DateTime?)null : DateTime.Parse(reader["CompletionDate"].ToString()),
                Status = reader["Status"].ToString(),
                Priority = reader["Priority"].ToString(),
                Notes = reader["Notes"].ToString(),
                HoursWorked = Convert.ToDouble(reader["HoursWorked"]),
                
            });
        }
        return list;
    }

    public void AddWorkOrder(WorkOrder order)
    {
        using var cmd = new SQLiteCommand(@"
            INSERT INTO WorkOrders 
            (RepairId, CreationDate, CompletionDate, Status, Priority, Notes, HoursWorked)
            VALUES 
            (@repairId, @creationDate, @completionDate, @status, @priority, @notes, @hoursWorked)", _conn);

        cmd.Parameters.AddWithValue("@repairId", order.RepairId);
        cmd.Parameters.AddWithValue("@creationDate", order.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
        if (order.CompletionDate.HasValue)
            cmd.Parameters.AddWithValue("@completionDate", order.CompletionDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        else
            cmd.Parameters.AddWithValue("@completionDate", DBNull.Value);
        cmd.Parameters.AddWithValue("@status", order.Status);
        cmd.Parameters.AddWithValue("@priority", order.Priority);
        cmd.Parameters.AddWithValue("@notes", order.Notes);
        cmd.Parameters.AddWithValue("@hoursWorked", order.HoursWorked);
        

        cmd.ExecuteNonQuery();
    }

    public void UpdateWorkOrder(WorkOrder order)
    {
        using var cmd = new SQLiteCommand(@"
            UPDATE WorkOrders SET
            RepairId = @repairId,
            CreationDate = @creationDate,
            CompletionDate = @completionDate,
            Status = @status,
            Priority = @priority,
            Notes = @notes,
            HoursWorked = @hoursWorked,
            WHERE WorkOrderId = @id", _conn);

        cmd.Parameters.AddWithValue("@repairId", order.RepairId);
        cmd.Parameters.AddWithValue("@creationDate", order.CreationDate.ToString("yyyy-MM-dd HH:mm:ss"));
        if (order.CompletionDate.HasValue)
            cmd.Parameters.AddWithValue("@completionDate", order.CompletionDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));
        else
            cmd.Parameters.AddWithValue("@completionDate", DBNull.Value);
        cmd.Parameters.AddWithValue("@status", order.Status);
        cmd.Parameters.AddWithValue("@priority", order.Priority);
        cmd.Parameters.AddWithValue("@notes", order.Notes);
        cmd.Parameters.AddWithValue("@hoursWorked", order.HoursWorked);
        cmd.Parameters.AddWithValue("@id", order.WorkOrderId);

        cmd.ExecuteNonQuery();
    }

    public void DeleteWorkOrder(int workOrderId)
    {
        using var cmd = new SQLiteCommand("DELETE FROM WorkOrders WHERE WorkOrderId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", workOrderId);
        cmd.ExecuteNonQuery();
    }
}
