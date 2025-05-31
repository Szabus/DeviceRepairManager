using DeviceRepairManager.Models;
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
using System.Xml.Linq;

namespace DeviceRepairManager
{
    public partial class AdminDashboardForm : Form
    {
        private AdminRepository _adminRepo;
        public AdminDashboardForm(SQLiteConnection conn)
        {
            InitializeComponent();
            _adminRepo = new AdminRepository(conn);
            LoadCustomers();
            LoadTechnicians();
        }

        private void LoadCustomers()
        {
            var customers = _adminRepo.GetAllCustomers();
            dgvCustomers.DataSource = customers;
        }

        private void dgvCustomers_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow == null) return;

            var customer = dgvCustomers.CurrentRow.DataBoundItem as Customer;
            if (customer == null) return;

            txtCustomerId.Text = customer.CustomerId.ToString();
            txtName.Text = customer.Name;
            txtContactInfo.Text = customer.ContactInfo;
            txtEmail.Text = customer.Address;
            txtPhoneNumber.Text = customer.Email;
            txtPassword.Text = customer.PhoneNumber;
            dtpRegistrationDate.Value = customer.RegistrationDate;
            chkIsVIP.Checked = customer.IsVIP;
            txtPassword.Text = customer.PasswordHash;
        }

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            var customer = new Customer()
            {
                Name = txtName.Text,
                ContactInfo = txtContactInfo.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                RegistrationDate = dtpRegistrationDate.Value,
                IsVIP = chkIsVIP.Checked,
                PasswordHash = txtPassword.Text
            };

            try
            {
                _adminRepo.AddCustomer(customer);
                MessageBox.Show("Ügyfél hozzáadva!");
                LoadCustomers();
                ClearCustomerForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void btnUpdateCustomer_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("Érvénytelen ügyfél ID.");
                return;
            }

            var customer = new Customer()
            {
                CustomerId = customerId,
                Name = txtName.Text,
                ContactInfo = txtContactInfo.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhoneNumber.Text,
                RegistrationDate = dtpRegistrationDate.Value,
                IsVIP = chkIsVIP.Checked,
                PasswordHash = txtPassword.Text
            };

            try
            {
                _adminRepo.UpdateCustomer(customer);
                MessageBox.Show("Ügyfél frissítve!");
                LoadCustomers();
                ClearCustomerForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void btnDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtCustomerId.Text, out int customerId))
            {
                MessageBox.Show("Érvénytelen ügyfél ID.");
                return;
            }

            var confirm = MessageBox.Show("Biztos törölni akarod az ügyfelet?", "Megerősítés", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _adminRepo.DeleteCustomer(customerId);
                    MessageBox.Show("Ügyfél törölve!");
                    LoadCustomers();
                    ClearCustomerForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt: " + ex.Message);
                }
            }
        }

        private void ClearCustomerForm()
        {
            txtCustomerId.Text = "";
            txtName.Text = "";
            txtContactInfo.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhoneNumber.Text = "";
            dtpRegistrationDate.Value = DateTime.Now;
            chkIsVIP.Checked = false;
            txtPassword.Text = "";
        }

        private void LoadTechnicians()
        {
            var technicians = _adminRepo.GetAllTechnicians();
            dgvTechnicians.DataSource = technicians;
        }
        private void btnAddTechnician_Click(object sender, EventArgs e)
        {
            Technician tech = new Technician
            {
                Name = txtName2.Text,
                Expertise = txtExpertise.Text,
                IsAvailable = chkIsAvaliable.Checked,
                TotalWorkHours = 0,
                Email = txtEmail2.Text,
                PhoneNumber = txtPhone2.Text,
                HireDate = DateTime.Now,
                IsOnLeave = chkIsOnLeave.Checked,
                CompletedRepairs = 0,
                Shift = cmbShift.Text,
                PasswordHash = txtPassword2.Text
            };

            _adminRepo.AddTechnician(tech);
            MessageBox.Show("Technikus hozzáadva.");
            LoadTechnicians();
            ClearTechnicianForm();
        }

        private void btnDeleteTechnician_Click(object sender, EventArgs e)
        {
            if (dgvTechnicians.SelectedRows.Count == 0)
            {
                MessageBox.Show("Válassz ki egy technikust.");
                return;
            }

            int id = Convert.ToInt32(dgvTechnicians.SelectedRows[0].Cells["TechnicianId"].Value);
            _adminRepo.DeleteTechnician(id);
            MessageBox.Show("Technikus törölve.");
            LoadTechnicians();
            ClearTechnicianForm();
        }

        private void btnEditTechnician_Click(object sender, EventArgs e)
        {

            if (dgvTechnicians.SelectedRows.Count == 0)
            {
                MessageBox.Show("Válassz ki egy technikust.");
                return;
            }

            int id = Convert.ToInt32(dgvTechnicians.SelectedRows[0].Cells["TechnicianId"].Value);

            Technician updatedTech = new Technician
            {
                TechnicianId = id,
                Name = txtName2.Text,
                Expertise = txtExpertise.Text,
                IsAvailable = chkIsAvaliable.Checked,
                Email = txtEmail.Text,
                PhoneNumber = txtPhone2.Text,
                HireDate = DateTime.Now,
                IsOnLeave = chkIsOnLeave.Checked,
                Shift = cmbShift.Text,
                PasswordHash = txtPassword.Text
            };

            _adminRepo.UpdateTechnician(updatedTech);
            MessageBox.Show("Technikus módosítva.");
            LoadTechnicians();
            ClearTechnicianForm();
        }

        private void ClearTechnicianForm()
        {
            txtName2.Text = "";
            txtExpertise.Text = "";
            chkIsAvaliable.Checked = false;
            txtEmail2.Text = "";
            txtPhone2.Text = "";
            chkIsOnLeave.Checked = false;
            cmbShift.SelectedIndex = -1;
            txtPassword2.Text = "";
        }
        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void tabCustomers_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPhoneNumber_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dgvTechnicians_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvTechnicians.SelectedRows.Count == 0 || dgvTechnicians.CurrentRow == null)
                return;

            var row = dgvTechnicians.SelectedRows[0];

            if (row.IsNewRow) return;

            txtName2.Text = row.Cells["Name"].Value?.ToString();
            txtExpertise.Text = row.Cells["Expertise"].Value?.ToString();
            chkIsAvaliable.Checked = Convert.ToBoolean(row.Cells["IsAvailable"].Value);
            txtEmail2.Text = row.Cells["Email"].Value?.ToString();
            txtPhone2.Text = row.Cells["PhoneNumber"].Value?.ToString();
            chkIsOnLeave.Checked = Convert.ToBoolean(row.Cells["IsOnLeave"].Value);
            cmbShift.Text = row.Cells["Shift"].Value?.ToString();
            txtPassword2.Text = row.Cells["PasswordHash"].Value?.ToString();
        }


        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_2(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_3(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_2(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_4(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tabWorkdOrders_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
