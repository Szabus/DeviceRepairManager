using DeviceRepairManager.Models;
using System.Data.SQLite;

namespace DeviceRepairManager.Repositories
{
    public class AdminRepository : IAdminRepository
    {
        private readonly string _connectionString;

        public AdminRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Admin> GetAllAdmins()
        {
            var admins = new List<Admin>();
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            var cmd = new SQLiteCommand("SELECT * FROM Admins", conn);
            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                admins.Add(new Admin
                {
                    AdminId = Convert.ToInt32(reader["AdminId"]),
                    Username = reader["Username"].ToString(),
                    PasswordHash = reader["PasswordHash"].ToString(),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                });
            }
            return admins;
        }

        public Admin? GetAdminById(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            var cmd = new SQLiteCommand("SELECT * FROM Admins WHERE AdminId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            using var reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                return new Admin
                {
                    AdminId = Convert.ToInt32(reader["AdminId"]),
                    Username = reader["Username"].ToString(),
                    PasswordHash = reader["PasswordHash"].ToString(),
                    Name = reader["Name"].ToString(),
                    Email = reader["Email"].ToString()
                };
            }
            return null;
        }

        public void AddAdmin(Admin admin)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            var cmd = new SQLiteCommand(@"INSERT INTO Admins (Username, PasswordHash, Name, Email) 
                                          VALUES (@Username, @PasswordHash, @Name, @Email)", conn);
            cmd.Parameters.AddWithValue("@Username", admin.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", admin.PasswordHash);
            cmd.Parameters.AddWithValue("@Name", admin.Name);
            cmd.Parameters.AddWithValue("@Email", admin.Email);
            cmd.ExecuteNonQuery();
        }

        public void UpdateAdmin(Admin admin)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            var cmd = new SQLiteCommand(@"UPDATE Admins SET 
                                          Username = @Username, 
                                          PasswordHash = @PasswordHash, 
                                          Name = @Name, 
                                          Email = @Email 
                                          WHERE AdminId = @AdminId", conn);
            cmd.Parameters.AddWithValue("@Username", admin.Username);
            cmd.Parameters.AddWithValue("@PasswordHash", admin.PasswordHash);
            cmd.Parameters.AddWithValue("@Name", admin.Name);
            cmd.Parameters.AddWithValue("@Email", admin.Email);
            cmd.Parameters.AddWithValue("@AdminId", admin.AdminId);
            cmd.ExecuteNonQuery();
        }

        public void DeleteAdmin(int id)
        {
            using var conn = new SQLiteConnection(_connectionString);
            conn.Open();
            var cmd = new SQLiteCommand("DELETE FROM Admins WHERE AdminId = @id", conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
        }
    }
}
