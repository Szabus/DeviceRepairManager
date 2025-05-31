using DeviceRepairManager.Repositories;
using DeviceRepairManager.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Windows.Forms;

namespace DeviceRepairManager
{
    public partial class TechnicianDashboardForm : Form
    {
        private WorkOrderRepository _workOrderRepo;
        private RepairRepository _repairRepo;
        private SQLiteConnection _conn;

        public TechnicianDashboardForm(SQLiteConnection conn)
        {
            InitializeComponent();
            _conn = conn;
            _workOrderRepo = new WorkOrderRepository(conn);
            _repairRepo = new RepairRepository(conn);

            this.Load += TechnicianDashboardForm_Load;
            cmbSelectWorkOrder.SelectedIndexChanged += cmbSelectWorkOrder_SelectedIndexChanged;
        }

        private void TechnicianDashboardForm_Load(object sender, EventArgs e)
        {
            LoadWorkOrders();
            LoadStatusOptions();
        }

        private void LoadWorkOrders()
        {
            var workOrders = _workOrderRepo.GetAllWorkOrders();
            dgvWorkOrders.DataSource = workOrders;

            cmbSelectWorkOrder.DataSource = null;
            cmbSelectWorkOrder.DataSource = workOrders;
            cmbSelectWorkOrder.DisplayMember = "WorkOrderId";
            cmbSelectWorkOrder.ValueMember = "WorkOrderId";
        }

        private void LoadStatusOptions()
        {
            cmbStatus.Items.Clear();
            cmbStatus.Items.AddRange(new[] { "Új", "Folyamatban", "Készen", "Árajánlat", "Elutasítva" });
            cmbStatus.SelectedIndex = 0;
        }

        private void cmbSelectWorkOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectWorkOrder.SelectedValue == null || !(cmbSelectWorkOrder.SelectedValue is int))
                return;

            int selectedWorkOrderId = (int)cmbSelectWorkOrder.SelectedValue;
            LoadRepairsForWorkOrder(selectedWorkOrderId);
            LoadWorkOrderDetails(selectedWorkOrderId);
        }

        private void LoadRepairsForWorkOrder(int workOrderId)
        {
            var repairs = _repairRepo.GetRepairsByWorkOrderId(workOrderId);
            dgvRepairs.DataSource = repairs;
        }

        private void LoadWorkOrderDetails(int workOrderId)
        {
            var workOrder = _workOrderRepo.GetWorkOrderById(workOrderId);
            if (workOrder != null)
            {
                cmbStatus.SelectedItem = workOrder.Status ?? "Új";
                dtpCompletionDate.Value = workOrder.CompletionDate ?? DateTime.Now;
                txtNotes.Text = workOrder.Notes ?? "";
            }
        }

        private void btnUpdateStatus_Click(object sender, EventArgs e)
        {
            if (cmbSelectWorkOrder.SelectedValue == null || !(cmbSelectWorkOrder.SelectedValue is int))
            {
                MessageBox.Show("Válassz ki egy munkalapot!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int workOrderId = (int)cmbSelectWorkOrder.SelectedValue;
            var workOrder = _workOrderRepo.GetWorkOrderById(workOrderId);

            if (workOrder == null)
            {
                MessageBox.Show("Nem található a kiválasztott munkalap!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            workOrder.Status = cmbStatus.SelectedItem?.ToString() ?? "Új";
            workOrder.CompletionDate = dtpCompletionDate.Value;

            try
            {
                _workOrderRepo.UpdateWorkOrder(workOrder);
                MessageBox.Show("Státusz frissítve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWorkOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a frissítés során: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (cmbSelectWorkOrder.SelectedValue == null || !(cmbSelectWorkOrder.SelectedValue is int))
            {
                MessageBox.Show("Válassz ki egy munkalapot!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int workOrderId = (int)cmbSelectWorkOrder.SelectedValue;
            var workOrder = _workOrderRepo.GetWorkOrderById(workOrderId);

            if (workOrder == null)
            {
                MessageBox.Show("Nem található a munkalap!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string newNote = txtNotes.Text.Trim();
            if (string.IsNullOrEmpty(newNote))
            {
                MessageBox.Show("Írj be egy megjegyzést!", "Figyelmeztetés", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            workOrder.Notes = string.IsNullOrEmpty(workOrder.Notes)
                ? newNote
                : workOrder.Notes + Environment.NewLine + newNote;

            try
            {
                _workOrderRepo.UpdateWorkOrder(workOrder);
                MessageBox.Show("Megjegyzés mentve!", "Siker", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadWorkOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a megjegyzés mentésekor: " + ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
