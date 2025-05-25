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
            txtPassword.Text = customer.PasswordHash; // figyelem, jelszó megjelenítés nem ajánlott!
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
                PasswordHash = txtPassword.Text // itt később jelszó hash-elés kell!
            };

            try
            {
                _adminRepo.AddCustomer(customer);
                MessageBox.Show("Ügyfél hozzáadva!");
                LoadCustomers();
                ClearForm();
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
                ClearForm();
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
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt: " + ex.Message);
                }
            }
        }

        private void ClearForm()
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
    }
}
