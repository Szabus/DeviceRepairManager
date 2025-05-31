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
        }

        private void TecnicianDashboardForm_Load(object sender, EventArgs e)
        {
            LoadWorkOrders();
        }

        private void LoadWorkOrders()
        {
            // Itt betöltjük az összes munkalapot (vagy akár csak a technikus munkalapjait)
            var workOrders = _workOrderRepo.GetAllWorkOrders(); // ezt implementálni kell repo-ban
            dgvWorkOrders.DataSource = workOrders;

            // Kitöltjük a combo box-ot is a munkalapokkal (pl. work_order_id és esetleg egy rövid leírás)
            cmbSelectWorkOrder.DataSource = workOrders;
            cmbSelectWorkOrder.DisplayMember = "WorkOrderId"; // vagy pl "WorkOrderId és Status" egy property lehet a modelben
            cmbSelectWorkOrder.ValueMember = "WorkOrderId";
        }

        private void cmbSelectWorkOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSelectWorkOrder.SelectedValue == null)
                return;

            int selectedWorkOrderId = (int)cmbSelectWorkOrder.SelectedValue;
            LoadRepairsForWorkOrder(selectedWorkOrderId);

            // Betöltjük a részleteket a kiválasztott munkalapról
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
            if (cmbSelectWorkOrder.SelectedValue == null)
            {
                MessageBox.Show("Válassz ki egy munkalapot!");
                return;
            }

            int workOrderId = (int)cmbSelectWorkOrder.SelectedValue;

            var workOrder = _workOrderRepo.GetWorkOrderById(workOrderId);
            if (workOrder == null)
            {
                MessageBox.Show("Nem található a munkalap!");
                return;
            }

            workOrder.Status = cmbStatus.SelectedItem?.ToString() ?? "Új";
            workOrder.CompletionDate = dtpCompletionDate.Value;

            try
            {
                _workOrderRepo.UpdateWorkOrder(workOrder);
                MessageBox.Show("Státusz frissítve!");
                LoadWorkOrders(); // frissítjük az adatokat
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a frissítés során: " + ex.Message);
            }
        }

        private void btnAddNote_Click(object sender, EventArgs e)
        {
            if (cmbSelectWorkOrder.SelectedValue == null)
            {
                MessageBox.Show("Válassz ki egy munkalapot!");
                return;
            }

            int workOrderId = (int)cmbSelectWorkOrder.SelectedValue;

            var workOrder = _workOrderRepo.GetWorkOrderById(workOrderId);
            if (workOrder == null)
            {
                MessageBox.Show("Nem található a munkalap!");
                return;
            }

            // Ha már vannak megjegyzések, hozzáfűzzük az újat
            string newNote = txtNotes.Text.Trim();
            if (string.IsNullOrEmpty(newNote))
            {
                MessageBox.Show("Írj be egy megjegyzést!");
                return;
            }

            workOrder.Notes = string.IsNullOrEmpty(workOrder.Notes)
                ? newNote
                : workOrder.Notes + Environment.NewLine + newNote;

            try
            {
                _workOrderRepo.UpdateWorkOrder(workOrder);
                MessageBox.Show("Megjegyzés mentve!");
                LoadWorkOrders();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Hiba történt a megjegyzés mentésekor: " + ex.Message);
            }
        }
    }
}
