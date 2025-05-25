using System.Data.SQLite;

public class TechnicianRepository
{
    private readonly SQLiteConnection _conn;

    public TechnicianRepository(SQLiteConnection connection)
    {
        _conn = connection;
    }

    // Javítás állapotának frissítése
    public void UpdateRepairStatus(int repairId, string newStatus, string notes = null, DateTime? completionDate = null)
    {
        using var cmd = new SQLiteCommand(_conn);

        var sql = "UPDATE Repairs SET Status = @status";

        if (notes != null)
            sql += ", Notes = @notes";

        if (completionDate.HasValue)
            sql += ", EndDate = @endDate";

        sql += " WHERE RepairId = @repairId";

        cmd.CommandText = sql;

        cmd.Parameters.AddWithValue("@status", newStatus);
        if (notes != null)
            cmd.Parameters.AddWithValue("@notes", notes);
        if (completionDate.HasValue)
            cmd.Parameters.AddWithValue("@endDate", completionDate.Value.ToString("yyyy-MM-dd HH:mm:ss"));

        cmd.Parameters.AddWithValue("@repairId", repairId);

        cmd.ExecuteNonQuery();
    }
}
