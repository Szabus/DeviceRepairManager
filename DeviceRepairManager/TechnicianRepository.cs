using DeviceRepairManager.Models;
using System.Data.SQLite;

public class TechnicianRepository
{
    private readonly SQLiteConnection _conn;

    public TechnicianRepository(SQLiteConnection conn)
    {
        _conn = conn;
    }

    public List<Technician> GetAllTechnicians()
    {
        var list = new List<Technician>();
        using var cmd = new SQLiteCommand("SELECT * FROM Technicians", _conn);
        using var reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            list.Add(new Technician
            {
                TechnicianId = Convert.ToInt32(reader["TechnicianId"]),
                Name = reader["Name"].ToString(),
                Expertise = reader["Expertise"].ToString(),
                IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                Email = reader["Email"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                HireDate = DateTime.Parse(reader["HireDate"].ToString()),
                IsOnLeave = Convert.ToBoolean(reader["IsOnLeave"]),
                CompletedRepairs = Convert.ToInt32(reader["CompletedRepairs"]),
                Shift = reader["Shift"].ToString(),
                PasswordHash = reader["PasswordHash"].ToString(),
                TotalWorkHours = Convert.ToDouble(reader["TotalWorkHours"])
            });
        }
        return list;
    }

    public void AddTechnician(Technician tech)
    {
        using var cmd = new SQLiteCommand(@"
            INSERT INTO Technicians 
            (Name, Expertise, IsAvailable, TotalWorkHours, Email, PhoneNumber, HireDate, IsOnLeave, CompletedRepairs, Shift, PasswordHash) 
            VALUES 
            (@name, @expertise, @isAvailable, @totalHours, @email, @phone, @hireDate, @isOnLeave, @completedRepairs, @shift, @password)", _conn);

        cmd.Parameters.AddWithValue("@name", tech.Name);
        cmd.Parameters.AddWithValue("@expertise", tech.Expertise);
        cmd.Parameters.AddWithValue("@isAvailable", tech.IsAvailable ? 1 : 0);
        cmd.Parameters.AddWithValue("@totalHours", tech.TotalWorkHours);
        cmd.Parameters.AddWithValue("@email", tech.Email);
        cmd.Parameters.AddWithValue("@phone", tech.PhoneNumber);
        cmd.Parameters.AddWithValue("@hireDate", tech.HireDate.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.Parameters.AddWithValue("@isOnLeave", tech.IsOnLeave ? 1 : 0);
        cmd.Parameters.AddWithValue("@completedRepairs", tech.CompletedRepairs);
        cmd.Parameters.AddWithValue("@shift", tech.Shift);
        cmd.Parameters.AddWithValue("@password", tech.PasswordHash);

        cmd.ExecuteNonQuery();
    }

    public void UpdateTechnician(Technician tech)
    {
        using var cmd = new SQLiteCommand(@"
            UPDATE Technicians SET
            Name = @name,
            Expertise = @expertise,
            IsAvailable = @isAvailable,
            TotalWorkHours = @totalHours,
            Email = @email,
            PhoneNumber = @phone,
            HireDate = @hireDate,
            IsOnLeave = @isOnLeave,
            CompletedRepairs = @completedRepairs,
            Shift = @shift,
            PasswordHash = @password
            WHERE TechnicianId = @id", _conn);

        cmd.Parameters.AddWithValue("@name", tech.Name);
        cmd.Parameters.AddWithValue("@expertise", tech.Expertise);
        cmd.Parameters.AddWithValue("@isAvailable", tech.IsAvailable ? 1 : 0);
        cmd.Parameters.AddWithValue("@totalHours", tech.TotalWorkHours);
        cmd.Parameters.AddWithValue("@email", tech.Email);
        cmd.Parameters.AddWithValue("@phone", tech.PhoneNumber);
        cmd.Parameters.AddWithValue("@hireDate", tech.HireDate.ToString("yyyy-MM-dd HH:mm:ss"));
        cmd.Parameters.AddWithValue("@isOnLeave", tech.IsOnLeave ? 1 : 0);
        cmd.Parameters.AddWithValue("@completedRepairs", tech.CompletedRepairs);
        cmd.Parameters.AddWithValue("@shift", tech.Shift);
        cmd.Parameters.AddWithValue("@password", tech.PasswordHash);
        cmd.Parameters.AddWithValue("@id", tech.TechnicianId);

        cmd.ExecuteNonQuery();
    }

    public void DeleteTechnician(int technicianId)
    {
        using var cmd = new SQLiteCommand("DELETE FROM Technicians WHERE TechnicianId = @id", _conn);
        cmd.Parameters.AddWithValue("@id", technicianId);
        cmd.ExecuteNonQuery();
    }
}

