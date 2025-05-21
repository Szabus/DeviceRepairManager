using DeviceRepairManager.Models;
using System.Data.SQLite;

namespace DeviceRepairManager.Repositories
{
    public class TechnicianRepository : ITechnicianRepository
    {
        private readonly string _connectionString;

        public TechnicianRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Technician> GetAllTechnicians()
        {
            var technicians = new List<Technician>();
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("SELECT * FROM Technicians", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                technicians.Add(new Technician
                {
                    TechnicianId = Convert.ToInt32(reader["TechnicianId"]),
                    Name = reader["Name"].ToString(),
                    Expertise = reader["Expertise"].ToString(),
                    IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                    TotalWorkHours = Convert.ToDecimal(reader["TotalWorkHours"])
                });
            }

            return technicians;
        }

        public Technician? GetTechnicianById(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("SELECT * FROM Technicians WHERE TechnicianId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Technician
                {
                    TechnicianId = Convert.ToInt32(reader["TechnicianId"]),
                    Name = reader["Name"].ToString(),
                    Expertise = reader["Expertise"].ToString(),
                    IsAvailable = Convert.ToBoolean(reader["IsAvailable"]),
                    TotalWorkHours = Convert.ToDecimal(reader["TotalWorkHours"])
                };
            }

            return null;
        }

        public void AddTechnician(Technician technician)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand(@"
                INSERT INTO Technicians (Name, Expertise, IsAvailable, TotalWorkHours)
                VALUES (@Name, @Expertise, @IsAvailable, @TotalWorkHours)", conn);

            cmd.Parameters.AddWithValue("@Name", technician.Name);
            cmd.Parameters.AddWithValue("@Expertise", technician.Expertise);
            cmd.Parameters.AddWithValue("@IsAvailable", technician.IsAvailable);
            cmd.Parameters.AddWithValue("@TotalWorkHours", technician.TotalWorkHours);

            cmd.ExecuteNonQuery();
        }

        public void UpdateTechnician(Technician technician)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand(@"
                UPDATE Technicians
                SET Name = @Name,
                    Expertise = @Expertise,
                    IsAvailable = @IsAvailable,
                    TotalWorkHours = @TotalWorkHours
                WHERE TechnicianId = @TechnicianId", conn);

            cmd.Parameters.AddWithValue("@Name", technician.Name);
            cmd.Parameters.AddWithValue("@Expertise", technician.Expertise);
            cmd.Parameters.AddWithValue("@IsAvailable", technician.IsAvailable);
            cmd.Parameters.AddWithValue("@TotalWorkHours", technician.TotalWorkHours);
            cmd.Parameters.AddWithValue("@TechnicianId", technician.TechnicianId);

            cmd.ExecuteNonQuery();
        }

        public void DeleteTechnician(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();

            var cmd = new SQLiteCommand("DELETE FROM Technicians WHERE TechnicianId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
