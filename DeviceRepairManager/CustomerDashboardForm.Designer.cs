namespace DeviceRepairManager
{
    partial class CustomerDashboardForm
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
            dgvDevices = new DataGridView();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dgvWorkOrders = new DataGridView();
            label4 = new Label();
            label5 = new Label();
            txtDeviceType = new TextBox();
            label6 = new Label();
            txtBrand = new TextBox();
            label7 = new Label();
            txtModel = new TextBox();
            label8 = new Label();
            dtpPurchaseDate = new DateTimePicker();
            label9 = new Label();
            cmbWarrantyStatus = new ComboBox();
            label10 = new Label();
            txtLocation = new TextBox();
            label11 = new Label();
            txtColor = new TextBox();
            btnSave = new Button();
            btnDelete = new Button();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            cmbSelectDevice = new ComboBox();
            cmbPriority = new ComboBox();
            txtNotes = new TextBox();
            btnSave2 = new Button();
            label16 = new Label();
            txtSerialNumber = new TextBox();
            currentCustomerId = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvWorkOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvDevices
            // 
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Location = new Point(12, 74);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.RowHeadersWidth = 51;
            dgvDevices.Size = new Size(306, 197);
            dgvDevices.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(121, 42);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 1;
            label1.Text = "Eszközeim";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(532, 42);
            label2.Name = "label2";
            label2.Size = new Size(106, 20);
            label2.TabIndex = 2;
            label2.Text = "Szervizigények";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(298, 9);
            label3.Name = "label3";
            label3.Size = new Size(150, 28);
            label3.TabIndex = 3;
            label3.Text = "ÜDVÖZÖLJÜK!";
            // 
            // dgvWorkOrders
            // 
            dgvWorkOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvWorkOrders.Location = new Point(413, 74);
            dgvWorkOrders.Name = "dgvWorkOrders";
            dgvWorkOrders.RowHeadersWidth = 51;
            dgvWorkOrders.Size = new Size(306, 197);
            dgvWorkOrders.TabIndex = 4;
            dgvWorkOrders.CellContentClick += dgvWorkOrders_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(12, 292);
            label4.Name = "label4";
            label4.Size = new Size(163, 20);
            label4.TabIndex = 5;
            label4.Text = "[Új eszköz hozzáadása]";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(12, 326);
            label5.Name = "label5";
            label5.Size = new Size(100, 20);
            label5.TabIndex = 6;
            label5.Text = "Eszköz típusa:";
            // 
            // txtDeviceType
            // 
            txtDeviceType.Location = new Point(118, 319);
            txtDeviceType.Name = "txtDeviceType";
            txtDeviceType.Size = new Size(176, 27);
            txtDeviceType.TabIndex = 7;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(302, 326);
            label6.Name = "label6";
            label6.Size = new Size(53, 20);
            label6.TabIndex = 8;
            label6.Text = "Márka:";
            // 
            // txtBrand
            // 
            txtBrand.Location = new Point(374, 319);
            txtBrand.Name = "txtBrand";
            txtBrand.Size = new Size(161, 27);
            txtBrand.TabIndex = 9;
            txtBrand.TextChanged += txtBrand_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(541, 326);
            label7.Name = "label7";
            label7.Size = new Size(59, 20);
            label7.TabIndex = 10;
            label7.Text = "Modell:";
            // 
            // txtModel
            // 
            txtModel.Location = new Point(607, 319);
            txtModel.Name = "txtModel";
            txtModel.Size = new Size(125, 27);
            txtModel.TabIndex = 11;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(12, 359);
            label8.Name = "label8";
            label8.Size = new Size(120, 20);
            label8.TabIndex = 12;
            label8.Text = "Vásárlás dátuma:";
            // 
            // dtpPurchaseDate
            // 
            dtpPurchaseDate.Location = new Point(138, 352);
            dtpPurchaseDate.Name = "dtpPurchaseDate";
            dtpPurchaseDate.Size = new Size(156, 27);
            dtpPurchaseDate.TabIndex = 13;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(302, 359);
            label9.Name = "label9";
            label9.Size = new Size(70, 20);
            label9.TabIndex = 14;
            label9.Text = "Garancia:";
            // 
            // cmbWarrantyStatus
            // 
            cmbWarrantyStatus.FormattingEnabled = true;
            cmbWarrantyStatus.Items.AddRange(new object[] { "Érvényes", "Lejárt", "Nincs garancia" });
            cmbWarrantyStatus.Location = new Point(374, 354);
            cmbWarrantyStatus.Name = "cmbWarrantyStatus";
            cmbWarrantyStatus.Size = new Size(161, 28);
            cmbWarrantyStatus.TabIndex = 15;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(542, 362);
            label10.Name = "label10";
            label10.Size = new Size(67, 20);
            label10.TabIndex = 16;
            label10.Text = "Helyszín:";
            // 
            // txtLocation
            // 
            txtLocation.Location = new Point(607, 355);
            txtLocation.Name = "txtLocation";
            txtLocation.Size = new Size(125, 27);
            txtLocation.TabIndex = 17;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(12, 394);
            label11.Name = "label11";
            label11.Size = new Size(39, 20);
            label11.TabIndex = 18;
            label11.Text = "Szín:";
            // 
            // txtColor
            // 
            txtColor.Location = new Point(118, 387);
            txtColor.Name = "txtColor";
            txtColor.Size = new Size(176, 27);
            txtColor.TabIndex = 19;
            // 
            // btnSave
            // 
            btnSave.Location = new Point(261, 420);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(94, 29);
            btnSave.TabIndex = 20;
            btnSave.Text = "Mentés";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnAddDevice_Click;
            // 
            // btnCancel
            // 
            btnDelete.Location = new Point(374, 420);
            btnDelete.Name = "btnCancel";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Törlés";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDeleteDevice_Click;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(12, 460);
            label12.Name = "label12";
            label12.Size = new Size(161, 20);
            label12.TabIndex = 22;
            label12.Text = "[Javítási igény leadása]";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(21, 498);
            label13.Name = "label13";
            label13.Size = new Size(56, 20);
            label13.TabIndex = 23;
            label13.Text = "Eszköz:";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(21, 530);
            label14.Name = "label14";
            label14.Size = new Size(66, 20);
            label14.TabIndex = 24;
            label14.Text = "Prioritás:";
            label14.Click += label14_Click;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(21, 561);
            label15.Name = "label15";
            label15.Size = new Size(91, 20);
            label15.TabIndex = 25;
            label15.Text = "Megjegyzés:";
            // 
            // cmbSelectDevice
            // 
            cmbSelectDevice.FormattingEnabled = true;
            cmbSelectDevice.Location = new Point(138, 490);
            cmbSelectDevice.Name = "cmbSelectDevice";
            cmbSelectDevice.Size = new Size(151, 28);
            cmbSelectDevice.TabIndex = 26;
            // 
            // cmbPriority
            // 
            cmbPriority.FormattingEnabled = true;
            cmbPriority.Items.AddRange(new object[] { "Alacsony", "Közepes", "Magas" });
            cmbPriority.Location = new Point(138, 522);
            cmbPriority.Name = "cmbPriority";
            cmbPriority.Size = new Size(151, 28);
            cmbPriority.TabIndex = 27;
            cmbPriority.SelectedIndexChanged += cmbPriority_SelectedIndexChanged;
            // 
            // txtNotes
            // 
            txtNotes.Location = new Point(138, 556);
            txtNotes.Name = "txtNotes";
            txtNotes.Size = new Size(397, 27);
            txtNotes.TabIndex = 28;
            // 
            // btnSave2
            // 
            btnSave2.Location = new Point(261, 589);
            btnSave2.Name = "btnSave2";
            btnSave2.Size = new Size(192, 29);
            btnSave2.TabIndex = 29;
            btnSave2.Text = "Javítási igény leadása";
            btnSave2.UseVisualStyleBackColor = true;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(302, 390);
            label16.Name = "label16";
            label16.Size = new Size(86, 20);
            label16.TabIndex = 30;
            label16.Text = "Szériaszám:";
            // 
            // txtSerialNumber
            // 
            txtSerialNumber.Location = new Point(387, 387);
            txtSerialNumber.Name = "txtSerialNumber";
            txtSerialNumber.Size = new Size(215, 27);
            txtSerialNumber.TabIndex = 31;
            // 
            // currentCustomerId
            // 
            currentCustomerId.Location = new Point(387, 421);
            currentCustomerId.Name = "currentCustomerId";
            currentCustomerId.Size = new Size(10, 27);
            currentCustomerId.TabIndex = 32;
            currentCustomerId.TextChanged += currentCustomerId_TextChanged;
            // 
            // CustomerDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(744, 650);
            Controls.Add(txtSerialNumber);
            Controls.Add(label16);
            Controls.Add(btnSave2);
            Controls.Add(txtNotes);
            Controls.Add(cmbPriority);
            Controls.Add(cmbSelectDevice);
            Controls.Add(label15);
            Controls.Add(label14);
            Controls.Add(label13);
            Controls.Add(label12);
            Controls.Add(btnDelete);
            Controls.Add(btnSave);
            Controls.Add(txtColor);
            Controls.Add(label11);
            Controls.Add(txtLocation);
            Controls.Add(label10);
            Controls.Add(cmbWarrantyStatus);
            Controls.Add(label9);
            Controls.Add(dtpPurchaseDate);
            Controls.Add(label8);
            Controls.Add(txtModel);
            Controls.Add(label7);
            Controls.Add(txtBrand);
            Controls.Add(label6);
            Controls.Add(txtDeviceType);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvWorkOrders);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(dgvDevices);
            Controls.Add(currentCustomerId);
            Name = "CustomerDashboardForm";
            Text = "CustomerDashboardForm";
            Load += CustomerDashboardForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvWorkOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvDevices;
        private Label label1;
        private Label label2;
        private Label label3;
        private DataGridView dgvWorkOrders;
        private Label label4;
        private Label label5;
        private TextBox txtDeviceType;
        private Label label6;
        private TextBox txtBrand;
        private Label label7;
        private TextBox txtModel;
        private Label label8;
        private DateTimePicker dtpPurchaseDate;
        private Label label9;
        private ComboBox cmbWarrantyStatus;
        private Label label10;
        private TextBox txtLocation;
        private Label label11;
        private TextBox txtColor;
        private Button btnSave;
        private Button btnDelete;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private ComboBox cmbSelectDevice;
        private ComboBox cmbPriority;
        private TextBox txtNotes;
        private Button btnSave2;
        private Label label16;
        private TextBox txtSerialNumber;
        private TextBox currentCustomerId;
    }
}