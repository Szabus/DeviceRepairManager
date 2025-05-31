using DeviceRepairManager.Data;
using System;
using System.Data.SQLite;
using System.Windows.Forms;

namespace DeviceRepairManager
{
    public partial class LoginForm : Form
    {
        private readonly SQLiteConnection _conn;

        public LoginForm(SQLiteConnection connection)
        {
            InitializeComponent();
            _conn = connection;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Kérlek, tölts ki minden mezőt.");
                return;
            }

            // --- ADMIN LOGIN ---
            using (var cmd = new SQLiteCommand("SELECT * FROM Admins WHERE Username = @u AND PasswordHash = @p", _conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    var adminForm = new AdminDashboardForm(_conn);
                    adminForm.Show();
                    this.Hide();
                    return;
                }
            }

            // --- CUSTOMER LOGIN ---
            using (var cmd = new SQLiteCommand("SELECT * FROM Customers WHERE Email = @u AND PasswordHash = @p", _conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int customerId = Convert.ToInt32(reader["CustomerId"]);
                    var customerForm = new CustomerDashboardForm(_conn, customerId); // customerId-t is át kell adni
                    customerForm.Show();
                    this.Hide();
                    return;
                }
            }

            // --- TECHNICIAN LOGIN ---
            using (var cmd = new SQLiteCommand("SELECT * FROM Technicians WHERE Email = @u AND PasswordHash = @p", _conn))
            {
                cmd.Parameters.AddWithValue("@u", username);
                cmd.Parameters.AddWithValue("@p", password);

                using var reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int technicianId = Convert.ToInt32(reader["TechnicianId"]);
                    var techForm = new TechnicianDashboardForm(_conn);
                    techForm.Show();
                    this.Hide();
                    return;
                }
            }

            // --- INVALID LOGIN ---
            MessageBox.Show("Hibás adatok, kérlek próbáld újra.");
        }
    }
}
