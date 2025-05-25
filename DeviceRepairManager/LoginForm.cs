using DeviceRepairManager.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Kérlek, tölts ki minden mezőt.");
                return;
            }

            using var cmd = new SQLiteCommand("SELECT * FROM Admins WHERE Username = @u AND PasswordHash = @p", _conn);
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password);

            using var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                // Admin belépés
                var adminForm = new AdminDashboardForm(_conn); 
                adminForm.Show();
                this.Hide();
                return;
            }
            cmd.CommandText = "SELECT * FROM Customers WHERE Email = @u AND PasswordHash = @p";
            //reader.Close();
            //reader.Dispose();
            cmd.Parameters.Clear();
            cmd.Parameters.AddWithValue("@u", username);
            cmd.Parameters.AddWithValue("@p", password); 

            using var custReader = cmd.ExecuteReader();

            //if (custReader.Read())
            //{
            //    int customerId = Convert.ToInt32(custReader["CustomerId"]);
            //    var customerForm = new CustomerDashboardForm(customerId);
            //    customerForm.Show();
            //    this.Hide();
            //    return;
            //}

            //// Ugyanez Technician-re
            //cmd.CommandText = "SELECT * FROM Technicians WHERE Email = @u AND PhoneNumber = @p";
            //custReader.Close();
            //cmd.Parameters.Clear();
            //cmd.Parameters.AddWithValue("@u", username);
            //cmd.Parameters.AddWithValue("@p", password);

            //using var techReader = cmd.ExecuteReader();
            //if (techReader.Read())
            //{
            //    int technicianId = Convert.ToInt32(techReader["TechnicianId"]);
            //    var techForm = new TechnicianDashboardForm(technicianId); 
            //    techForm.Show();
            //    this.Hide();
            //    return;
            //}

            MessageBox.Show("Hibás adatok, kérlek próbáld újra.");
        }

    }
}
