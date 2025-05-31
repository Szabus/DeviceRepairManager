namespace DeviceRepairManager
{
    partial class TechnicianDashboardForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            dgvWorkOrders = new DataGridView();
            dgvRepairs = new DataGridView();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            grpDetails = new GroupBox();
            label7 = new Label();
            label6 = new Label();
            btnAddNote = new Button();
            btnUpdateStatus = new Button();
            label5 = new Label();
            txtNotes = new TextBox();
            dtpCompletionDate = new DateTimePicker();
            cmbStatus = new ComboBox();
            cmbSelectWorkOrder = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvWorkOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvRepairs).BeginInit();
            grpDetails.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F);
            label1.Location = new Point(238, 20);
            label1.Name = "label1";
            label1.Size = new Size(189, 31);
            label1.TabIndex = 0;
            label1.Text = "Technikusi felület";
            // 
            // dgvWorkOrders
            // 
            dgvWorkOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWorkOrders.Location = new Point(12, 97);
            dgvWorkOrders.Name = "dgvWorkOrders";
            dgvWorkOrders.RowHeadersWidth = 51;
            dgvWorkOrders.Size = new Size(204, 188);
            dgvWorkOrders.TabIndex = 1;
           // dgvWorkOrders.CellContentClick += this.dgvWorkOrders_CellContentClick_1;
            // 
            // dgvRepairs
            // 
            dgvRepairs.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvRepairs.Location = new Point(254, 97);
            dgvRepairs.Name = "dgvRepairs";
            dgvRepairs.RowHeadersWidth = 51;
            dgvRepairs.Size = new Size(201, 188);
            dgvRepairs.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(71, 64);
            label2.Name = "label2";
            label2.Size = new Size(90, 20);
            label2.TabIndex = 3;
            label2.Text = "Munkalapok";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(325, 64);
            label3.Name = "label3";
            label3.Size = new Size(68, 20);
            label3.TabIndex = 4;
            label3.Text = "Javítások";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(604, 64);
            label4.Name = "label4";
            label4.Size = new Size(71, 20);
            label4.TabIndex = 5;
            label4.Text = "Részletek";
            // 
            // grpDetails
            // 
            grpDetails.Controls.Add(label7);
            grpDetails.Controls.Add(label6);
            grpDetails.Controls.Add(btnAddNote);
            grpDetails.Controls.Add(btnUpdateStatus);
            grpDetails.Controls.Add(label5);
            grpDetails.Controls.Add(txtNotes);
            grpDetails.Controls.Add(dtpCompletionDate);
            grpDetails.Controls.Add(cmbStatus);
            grpDetails.Controls.Add(cmbSelectWorkOrder);
            grpDetails.Location = new Point(486, 97);
            grpDetails.Name = "grpDetails";
            grpDetails.Size = new Size(302, 327);
            grpDetails.TabIndex = 6;
            grpDetails.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(19, 84);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 8;
            label7.Text = "Státusz:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(19, 44);
            label6.Name = "label6";
            label6.Size = new Size(77, 20);
            label6.TabIndex = 7;
            label6.Text = "Munkalap:";
            // 
            // btnAddNote
            // 
            btnAddNote.Location = new Point(169, 234);
            btnAddNote.Name = "btnAddNote";
            btnAddNote.Size = new Size(112, 50);
            btnAddNote.TabIndex = 6;
            btnAddNote.Text = "Megjegyzés mentése";
            btnAddNote.UseVisualStyleBackColor = true;
            btnAddNote.Click += btnAddNote_Click;
            // 
            // btnUpdateStatus
            // 
            btnUpdateStatus.Location = new Point(19, 234);
            btnUpdateStatus.Name = "btnUpdateStatus";
            btnUpdateStatus.Size = new Size(118, 50);
            btnUpdateStatus.TabIndex = 5;
            btnUpdateStatus.Text = "Státusz frissítés";
            btnUpdateStatus.UseVisualStyleBackColor = true;
            btnUpdateStatus.Click += btnUpdateStatus_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(19, 164);
            label5.Name = "label5";
            label5.Size = new Size(106, 20);
            label5.TabIndex = 4;
            label5.Text = "Megjegyzések:";
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(131, 161);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(165, 27);
            txtNotes.TabIndex = 3;
            // 
            // dtpCompletionDate
            // 
            dtpCompletionDate.Location = new Point(19, 115);
            dtpCompletionDate.Name = "dtpCompletionDate";
            dtpCompletionDate.Size = new Size(176, 27);
            dtpCompletionDate.TabIndex = 2;
            // 
            // cmbStatus
            // 
            cmbStatus.FormattingEnabled = true;
            cmbStatus.Items.AddRange(new object[] { "Új", "Folyamatban", "Kész" });
            cmbStatus.Location = new Point(118, 76);
            cmbStatus.Name = "cmbStatus";
            cmbStatus.Size = new Size(131, 28);
            cmbStatus.TabIndex = 1;
           // cmbStatus.SelectedIndexChanged += this.cmbStatus_SelectedIndexChanged;
            // 
            // cmbSelectWorkOrder
            // 
            cmbSelectWorkOrder.FormattingEnabled = true;
            cmbSelectWorkOrder.Location = new Point(118, 36);
            cmbSelectWorkOrder.Name = "cmbSelectWorkOrder";
            cmbSelectWorkOrder.Size = new Size(131, 28);
            cmbSelectWorkOrder.TabIndex = 0;
            // 
            // TechnicianDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(grpDetails);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(dgvRepairs);
            Controls.Add(dgvWorkOrders);
            Controls.Add(label1);
            Name = "TechnicianDashboardForm";
            Text = "TechnicianDashboardForm";
            Load += TechnicianDashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvWorkOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvRepairs).EndInit();
            grpDetails.ResumeLayout(false);
            grpDetails.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvWorkOrders;
        private DataGridView dgvRepairs;
        private Label label2;
        private Label label3;
        private Label label4;
        private GroupBox grpDetails;
        private ComboBox cmbSelectWorkOrder;
        private Button btnAddNote;
        private Button btnUpdateStatus;
        private Label label5;
        private TextBox txtNotes;
        private DateTimePicker dtpCompletionDate;
        private ComboBox cmbStatus;
        private Label label7;
        private Label label6;
    }
}