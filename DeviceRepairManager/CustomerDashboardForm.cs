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
    public partial class CustomerDashboardForm : Form
    {
        private readonly int customerId;
        //public CustomerDashboardForm(int customerId)
        //{
        //    InitializeComponent();
        //    this.customerId = customerId;
        //    LoadCustomerData();
        //    LoadDevices();
        //}

        //private void LoadCustomerData()
        //{
        //    var db = new DatabaseService("adatbazis_nev.db");
        //    using var conn = db.GetConnection();
        //    using var cmd = new SQLiteCommand("SELECT Name, Email, PhoneNumber FROM Customers WHERE CustomerId = @id", conn);
        //    cmd.Parameters.AddWithValue("@id", customerId);

        //    using var reader = cmd.ExecuteReader();
        //    if (reader.Read())
        //    {
        //        lblWelcome.Text = $"Üdvözöljük, {reader["Name"]}!";
        //        txtName.Text = reader["Name"].ToString();
        //        txtEmail.Text = reader["Email"].ToString();
        //        txtPhone.Text = reader["PhoneNumber"].ToString();
        //    }
        //}

        //private void LoadDevices()
        //{
        //    var db = new DatabaseService("adatbazis_nev.db");
        //    using var conn = db.GetConnection();
        //    using var cmd = new SQLiteCommand("SELECT DeviceId, Brand, Model, SerialNumber, Condition FROM Devices WHERE CustomerId = @id", conn);
        //    cmd.Parameters.AddWithValue("@id", customerId);

        //    using var adapter = new SQLiteDataAdapter(cmd);
        //    var dt = new DataTable();
        //    adapter.Fill(dt);

        //    dgvDevices.DataSource = dt;
        //}
        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        //private void btnSubmitRepair_Click(object sender, EventArgs e)
        //{

        //    if (dgvDevices.CurrentRow == null)
        //    {
        //        MessageBox.Show("Válassz ki egy eszközt.");
        //        return;
        //    }

        //    int deviceId = Convert.ToInt32(dgvDevices.CurrentRow.Cells["DeviceId"].Value);

        //    var db = new DatabaseService("adatbazis_nev.db");
        //    using var conn = db.GetConnection();
        //    using var cmd = new SQLiteCommand(@"
        //INSERT INTO Repairs (DeviceId, CustomerId, StartDate, Status, Description, CustomerApproved, RepairCount, IsUnderRepair)
        //VALUES (@deviceId, @customerId, @startDate, 'Leadva', 'Felhasználói bejelentés alapján', 1, 0, 1)", conn);

        //    cmd.Parameters.AddWithValue("@deviceId", deviceId);
        //    cmd.Parameters.AddWithValue("@customerId", customerId);
        //    cmd.Parameters.AddWithValue("@startDate", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

        //    cmd.ExecuteNonQuery();

        //    MessageBox.Show("Szervizigény sikeresen leadva.");
        //}

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
