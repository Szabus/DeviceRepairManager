using DeviceRepairManager.Data;
using DeviceRepairManager.Models;
using DeviceRepairManager.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;


namespace DeviceRepairManager
{
    public partial class CustomerForm : Form
    {
        private DatabaseService dbService;
        private CustomerRepository customerRepository;
        public CustomerForm()
        {
            dbService = new DatabaseService("adatbazis_nev.db");
            customerRepository = new CustomerRepository(dbService);
            InitializeComponent();
            LoadCustomers();
        }

        private void LoadCustomers()
        {
            if (customerRepository == null)
            {
                MessageBox.Show("Customer repository nem elérhető.");
                return;
            }
            var customers = customerRepository.GetAll();
            dgvCustomers.DataSource = customers;
        }

        private void ClearForm()
        {
            txtName.Text = "";
            txtContact.Text = "";
            txtAddress.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
            chkIsVIP.Checked = false;
            dtpRegistrationDate.Value = DateTime.Now;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var customer = new Customer
            {
                Name = txtName.Text,
                ContactInfo = txtContact.Text,
                Address = txtAddress.Text,
                Email = txtEmail.Text,
                PhoneNumber = txtPhone.Text,
                IsVIP = chkIsVIP.Checked,
                RegistrationDate = dtpRegistrationDate.Value
            };

            customerRepository.Add(customer);
            LoadCustomers();
            ClearForm();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer selectedCustomer)
            {
                selectedCustomer.Name = txtName.Text;
                selectedCustomer.ContactInfo = txtContact.Text;
                selectedCustomer.Address = txtAddress.Text;
                selectedCustomer.Email = txtEmail.Text;
                selectedCustomer.PhoneNumber = txtPhone.Text;
                selectedCustomer.IsVIP = chkIsVIP.Checked;
                selectedCustomer.RegistrationDate = dtpRegistrationDate.Value;

                customerRepository.Update(selectedCustomer);
                LoadCustomers();
                ClearForm();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer selectedCustomer)
            {
                customerRepository.Delete(selectedCustomer.CustomerId);
                LoadCustomers();
                ClearForm();
            }
        }

        private void dgvCustomers_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvCustomers.CurrentRow?.DataBoundItem is Customer selectedCustomer)
            {
                txtName.Text = selectedCustomer.Name;
                txtContact.Text = selectedCustomer.ContactInfo;
                txtAddress.Text = selectedCustomer.Address;
                txtEmail.Text = selectedCustomer.Email;
                txtPhone.Text = selectedCustomer.PhoneNumber;
                chkIsVIP.Checked = selectedCustomer.IsVIP;
                dtpRegistrationDate.Value = selectedCustomer.RegistrationDate;
            }
        }

        //private void btnSubmitRepair_Click(object sender, EventArgs e)
        //{
        //    if (dgvCustomers.CurrentRow?.DataBoundItem is Customer selectedCustomer)
        //    {
             
        //        Repair newRepair = selectedCustomer.SubmitRepairRequest(deviceId, problemDescription);

        //        repairRepository.Add(newRepair); 
        //    }
        //}
        private void CustomerForm_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
