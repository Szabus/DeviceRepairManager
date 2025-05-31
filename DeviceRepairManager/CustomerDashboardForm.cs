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

namespace DeviceRepairManager
{
    public partial class CustomerDashboardForm : Form
    {
        private CustomerRepository _customerRepo;
        private WorkOrderRepository _workOrderRepo;
        private DeviceRepository _deviceRepo;
        private int _customerId;
        private SQLiteConnection _conn;

        public CustomerDashboardForm(SQLiteConnection conn, int customerId)
        {
            InitializeComponent();
            _customerRepo = new CustomerRepository(conn);
            _workOrderRepo = new WorkOrderRepository(conn);
            _deviceRepo = new DeviceRepository(conn);
            _customerId = customerId;
            _conn = conn;

            LoadDevicesForCustomer(_customerId);
            LoadWorkOrdersForCustomer(_customerId);
        }

        private void CustomerDashboardForm_Load(object sender, EventArgs e)
        {
            LoadDevicesToComboBox(_customerId);
            LoadWorkOrdersForCustomer(_customerId);
        }

        private void LoadWorkOrdersForCustomer(int customerId)
        {
            var workOrders = _workOrderRepo.GetWorkOrdersByCustomer(customerId);
            dgvWorkOrders.DataSource = workOrders;
        }

        private void LoadDevicesForCustomer(int customerId)
        {
            var devices = _deviceRepo.GetDevicesByCustomerId(customerId);
            dgvDevices.DataSource = devices;
        }

        private void ClearDeviceForm()
        {
            txtDeviceType.Clear();
            txtBrand.Clear();
            txtModel.Clear();
            txtSerialNumber.Clear();
            cmbWarrantyStatus.SelectedIndex = -1;
            dtpPurchaseDate.Value = DateTime.Today;
            txtLocation.Clear();
            txtColor.Clear();
        }

        private void btnAddDevice_Click(object sender, EventArgs e)
        {
            var device = new Device
            {
                Type = txtDeviceType.Text,
                Brand = txtBrand.Text,
                Model = txtModel.Text,
                SerialNumber = txtSerialNumber.Text,
                CustomerId = _customerId,
                PurchaseDate = dtpPurchaseDate.Value,
                WarrantyStatus = cmbWarrantyStatus.SelectedItem?.ToString(),
                Location = txtLocation.Text,
                Color = txtColor.Text
            };

            try
            {
                _deviceRepo.AddDevice(device);
                MessageBox.Show("Eszköz hozzáadva!");
                LoadDevicesForCustomer(_customerId);
                ClearDeviceForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt az eszköz hozzáadásakor: " + ex.Message);
            }
        }

        //private void btnAddWorkOrder_Click(object sender, EventArgs e)
        //{
        //    if (dgvDevices.SelectedRows.Count == 0)
        //    {
        //        MessageBox.Show("Válassz egy eszközt a listából!");
        //        return;
        //    }

        //    var selectedDevice = (Device)dgvDevices.SelectedRows[0].DataBoundItem;

        //    var workOrder = new WorkOrder
        //    {
        //        DeviceId = selectedDevice.Id,
        //        CustomerId = _customerId,
        //        Description = txtWorkOrderDescription.Text,
        //        CreatedAt = DateTime.Now,
        //        Status = "Új"
        //    };

        //    try
        //    {
        //        _workOrderRepo.AddWorkOrder(workOrder);
        //        MessageBox.Show("Szerviz bejegyzés hozzáadva!");
        //        LoadWorkOrdersForCustomer(_customerId);
        //        txtWorkOrderDescription.Clear();
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("Hiba történt a munkalap hozzáadásakor: " + ex.Message);
        //    }
        //}
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void cmbPriority_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {

        }

        private void currentCustomerId_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDeviceType_TextChanged(object sender, EventArgs e)
        {

        }

        private void dgvWorkOrders_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txtBrand_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnDeleteDevice_Click(object sender, EventArgs e)
        {
            if (dgvDevices.SelectedRows.Count == 0)
            {
                MessageBox.Show("Válassz ki egy eszközt a törléshez!");
                return;
            }

            var selectedDevice = (Device)dgvDevices.SelectedRows[0].DataBoundItem;

            var confirmResult = MessageBox.Show(
                $"Biztosan törölni szeretnéd az eszközt: {selectedDevice.Type} - {selectedDevice.SerialNumber}?",
                "Megerősítés",
                MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    _deviceRepo.DeleteDevice(selectedDevice.DeviceId);
                    LoadDevicesForCustomer(_customerId);
                    ClearDeviceForm();
                    MessageBox.Show("Eszköz törölve!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Hiba történt a törlés során: " + ex.Message);
                }
            }
        }

        private void cmbSelectDevice_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadDevicesToComboBox(int customerId)
        {
            var devices = _deviceRepo.GetDevicesByCustomerId(customerId);
            cmbSelectDevice.DataSource = devices;
            cmbSelectDevice.DisplayMember = "Model";
            cmbSelectDevice.ValueMember = "DeviceId";
        }

        private void btnSubmitWorkOrder_Click(object sender, EventArgs e)
        {

            try
            {
                var newOrder = new WorkOrder
                {
                    //RepairId = Convert.ToInt32(cmbSelectDevice.SelectedValue),
                    CreationDate = DateTime.Now,
                    CreatedBy = _customerRepo.GetCustomerNameById(_customerId),
                    Priority = cmbPriority.SelectedItem?.ToString() ?? "Nincs megadva",
                    Notes = txtNotes.Text,
                    Status = "Új",
                    CompletionDate = null,
                    HoursWorked = 0,
                    RequiresApproval = false
                };

                _workOrderRepo.AddWorkOrder(newOrder);

                MessageBox.Show("Szerviz leadva sikeresen!");

                LoadWorkOrdersForCustomer(_customerId);
                cmbPriority.SelectedIndex = -1;
                txtNotes.Clear();
                cmbSelectDevice.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt: " + ex.Message);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm loginForm = new LoginForm(_conn);
            loginForm.Show();
        }
    }
}
