using DeviceRepairManager.Models;
using DeviceRepairManager.Repositories;
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
        private WorkOrderRepository _workOrderRepo;
        private SQLiteConnection _conn;
        public AdminDashboardForm(SQLiteConnection conn)
        {
            InitializeComponent();
            _adminRepo = new AdminRepository(conn);
            _workOrderRepo = new WorkOrderRepository(conn);
            LoadCustomers();
            LoadTechnicians();
            LoadWorkOrders();
            _conn = conn;
        }

        private void LoadCustomers()
        {
            var customers = _adminRepo.GetAllCustomers();
            dgvCustomers.DataSource = customers;
        }

        private void LoadWorkOrders()
        {
            var list = _workOrderRepo.GetAllWorkOrders();
            dgvWorkOrders.DataSource = null;
            dgvWorkOrders.DataSource = list;

            dgvWorkOrders.Columns["WorkOrderId"].ReadOnly = true;
        }

        private void DgvWorkOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvWorkOrders.CurrentRow == null) return;

            var workOrder = dgvWorkOrders.CurrentRow.DataBoundItem as WorkOrder;
            if (workOrder == null) return;

            txtWorkOrderId.Text = workOrder.WorkOrderId.ToString();
            dtpCreationDate.Value = workOrder.CreationDate;


            if (workOrder.CompletionDate.HasValue)
                dtpCompletionDate.Value = workOrder.CompletionDate.Value;
            else
                dtpCompletionDate.Checked = false;

            cmbStatus.SelectedItem = workOrder.Status ?? "";
            cmbPriority.SelectedItem = workOrder.Priority ?? "";
            txtNotes.Text = workOrder.Notes ?? "";
            numHoursWorked.Text = workOrder.HoursWorked.ToString();
            chkRequiresApproval.Checked = workOrder.RequiresApproval;
            txtCreatedBy.Text = workOrder.CreatedBy ?? "";
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

        private void BtnAddWorkOrder_Click(object sender, EventArgs e)
        {
            var workOrder = new WorkOrder
            {
                CreationDate = dtpCreationDate.Value,
                CompletionDate = dtpCompletionDate.Checked ? dtpCompletionDate.Value : (DateTime?)null,
                Status = cmbStatus.SelectedItem?.ToString(),
                Priority = cmbPriority.SelectedItem?.ToString(),
                Notes = txtNotes.Text,
                HoursWorked = double.TryParse(numHoursWorked.Text, out double hours) ? hours : 0,
                RequiresApproval = chkRequiresApproval.Checked,
                CreatedBy = txtCreatedBy.Text
            };

            try
            {
                _workOrderRepo.AddWorkOrder(workOrder);
                MessageBox.Show("Work order hozzáadva.");
                LoadWorkOrders();
                ClearWorkOrderForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a hozzáadás során: " + ex.Message);
            }
        }

        private void BtnUpdateWorkOrder_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtWorkOrderId.Text, out int id))
            {
                MessageBox.Show("Érvénytelen WorkOrder ID.");
                return;
            }

            var workOrder = new WorkOrder
            {
                WorkOrderId = id,
                CreationDate = dtpCreationDate.Value,
                CompletionDate = dtpCompletionDate.Checked ? dtpCompletionDate.Value : (DateTime?)null,
                Status = cmbStatus.SelectedItem?.ToString(),
                Priority = cmbPriority.SelectedItem?.ToString(),
                Notes = txtNotes.Text,
                HoursWorked = double.TryParse(numHoursWorked.Text, out double hours) ? hours : 0,
                RequiresApproval = chkRequiresApproval.Checked,
                CreatedBy = txtCreatedBy.Text
            };

            try
            {
                _workOrderRepo.UpdateWorkOrder(workOrder);
                MessageBox.Show("Work order frissítve.");
                LoadWorkOrders();
                ClearWorkOrderForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba a frissítés során: " + ex.Message);
            }
        }

        private void BtnDeleteWorkOrder_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtWorkOrderId.Text, out int id))
            {
                MessageBox.Show("Érvénytelen WorkOrder ID.");
                return;
            }

            var confirm = MessageBox.Show("Biztosan törölni akarod a work ordert?", "Megerősítés", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                try
                {
                    _workOrderRepo.DeleteWorkOrder(id);
                    MessageBox.Show("Work order törölve.");
                    LoadWorkOrders();
                    ClearWorkOrderForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba a törlés során: " + ex.Message);
                }
            }
        }

        private void ClearWorkOrderForm()
        {
            txtWorkOrderId.Text = "";
            dtpCreationDate.Value = DateTime.Now;
            dtpCompletionDate.Value = DateTime.Now;
            dtpCompletionDate.Checked = false;
            cmbStatus.SelectedIndex = -1;
            cmbPriority.SelectedIndex = -1;
            txtNotes.Text = "";
            numHoursWorked.Text = "";
            chkRequiresApproval.Checked = false;
            txtCreatedBy.Text = "";
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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void cmbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvWorkOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void numHoursWorked_ValueChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_3(object sender, EventArgs e)
        {

        }

        private void btnAddWorkOrder_Click_1(object sender, EventArgs e)
        {

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide(); 
            LoginForm loginForm = new LoginForm(_conn); 
            loginForm.Show();
        }
    }
}
