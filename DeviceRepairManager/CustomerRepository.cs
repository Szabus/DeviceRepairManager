using DeviceRepairManager.Models;
using System.Data.SQLite;

public class CustomerRepository
{
    private readonly SQLiteConnection _conn;

    public CustomerRepository(SQLiteConnection connection)
    {
        _conn = connection;
    }

    public void CreateRepairRequest(int customerId, int deviceId, string description)
    {
        using var cmd = new SQLiteCommand(@"
            INSERT INTO Repairs (DeviceId, CustomerId, StartDate, Status, Description, CustomerApproved, RepairCount, IsUnderRepair)
            VALUES (@deviceId, @customerId, datetime('now'), 'Requested', @description, 0, 1, 1)", _conn);

        cmd.Parameters.AddWithValue("@deviceId", deviceId);
        cmd.Parameters.AddWithValue("@customerId", customerId);
        cmd.Parameters.AddWithValue("@description", description);

        cmd.ExecuteNonQuery();
    }

    
    public List<Repair> GetRepairsByCustomer(int customerId)
    {
        var repairs = new List<Repair>();

        using var cmd = new SQLiteCommand("SELECT * FROM Repairs WHERE CustomerId = @customerId", _conn);
        cmd.Parameters.AddWithValue("@customerId", customerId);

        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            repairs.Add(new Repair
            {
                RepairId = Convert.ToInt32(reader["RepairId"]),
                DeviceId = Convert.ToInt32(reader["DeviceId"]),
                CustomerId = Convert.ToInt32(reader["CustomerId"]),
                StartDate = DateTime.Parse(reader["StartDate"].ToString()),
                Status = reader["Status"].ToString(),
                Description = reader["Description"].ToString(),
                CustomerApproved = Convert.ToBoolean(reader["CustomerApproved"]),
                RepairCount = Convert.ToInt32(reader["RepairCount"]),
                IsUnderRepair = Convert.ToBoolean(reader["IsUnderRepair"]),
            });
        }

        return repairs;
    }

    public string? GetCustomerNameById(int customerId)
    {
        string sql = "SELECT Name FROM Customers WHERE CustomerId = @CustomerId";

        using (var cmd = new SQLiteCommand(sql, _conn))
        {
            cmd.Parameters.AddWithValue("@CustomerId", customerId);
            var result = cmd.ExecuteScalar();
            return result?.ToString();
        }
    }
}
