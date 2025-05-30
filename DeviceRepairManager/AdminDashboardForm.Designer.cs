namespace DeviceRepairManager
{
    partial class AdminDashboardForm
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
            tabControl1 = new TabControl();
            tabCustomers = new TabPage();
            btnDeleteCustomer = new Button();
            btnUpdateCustomer = new Button();
            btnAddCustomer = new Button();
            groupBox1 = new GroupBox();
            txtCustomerId = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            chkIsVIP = new CheckBox();
            dtpRegistrationDate = new DateTimePicker();
            txtPassword = new TextBox();
            txtPhoneNumber = new TextBox();
            txtEmail = new TextBox();
            txtAddress = new TextBox();
            txtContactInfo = new TextBox();
            txtName = new TextBox();
            dgvCustomers = new DataGridView();
            tabTechnician = new TabPage();
            txtTechnicianId = new TextBox();
            btnDeleteTech = new Button();
            btnUpdateTech = new Button();
            btnAddTech = new Button();
            txtPassword2 = new TextBox();
            label16 = new Label();
            cmbShift = new ComboBox();
            label15 = new Label();
            numCompletedRepairs = new NumericUpDown();
            label14 = new Label();
            chkIsOnLeave = new CheckBox();
            lbIsOnLeave = new Label();
            dtpHireDate = new DateTimePicker();
            lblHireDate = new Label();
            label13 = new Label();
            txtPhone2 = new TextBox();
            txtEmail2 = new TextBox();
            label12 = new Label();
            numTotalWorkHours = new NumericUpDown();
            label11 = new Label();
            chkIsAvaliable = new CheckBox();
            label10 = new Label();
            txtExpertise = new TextBox();
            label9 = new Label();
            txtName2 = new TextBox();
            label8 = new Label();
            dgvTechnicians = new DataGridView();
            tabWorkdOrders = new TabPage();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabCustomers.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            tabTechnician.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)numCompletedRepairs).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numTotalWorkHours).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvTechnicians).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabCustomers);
            tabControl1.Controls.Add(tabTechnician);
            tabControl1.Controls.Add(tabWorkdOrders);
            tabControl1.Location = new Point(-1, 71);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(812, 574);
            tabControl1.TabIndex = 0;
            // 
            // tabCustomers
            // 
            tabCustomers.Controls.Add(btnDeleteCustomer);
            tabCustomers.Controls.Add(btnUpdateCustomer);
            tabCustomers.Controls.Add(btnAddCustomer);
            tabCustomers.Controls.Add(groupBox1);
            tabCustomers.Controls.Add(dgvCustomers);
            tabCustomers.Location = new Point(4, 29);
            tabCustomers.Name = "tabCustomers";
            tabCustomers.Padding = new Padding(3);
            tabCustomers.Size = new Size(804, 541);
            tabCustomers.TabIndex = 0;
            tabCustomers.Text = "Ügyfelek";
            tabCustomers.UseVisualStyleBackColor = true;
            tabCustomers.Click += tabCustomers_Click;
            // 
            // btnDeleteCustomer
            // 
            btnDeleteCustomer.Location = new Point(243, 500);
            btnDeleteCustomer.Name = "btnDeleteCustomer";
            btnDeleteCustomer.Size = new Size(94, 29);
            btnDeleteCustomer.TabIndex = 4;
            btnDeleteCustomer.Text = "Törlés";
            btnDeleteCustomer.UseVisualStyleBackColor = true;
            btnDeleteCustomer.Click += btnDeleteCustomer_Click;
            // 
            // btnUpdateCustomer
            // 
            btnUpdateCustomer.Location = new Point(124, 500);
            btnUpdateCustomer.Name = "btnUpdateCustomer";
            btnUpdateCustomer.Size = new Size(94, 29);
            btnUpdateCustomer.TabIndex = 3;
            btnUpdateCustomer.Text = "Módosítás";
            btnUpdateCustomer.UseVisualStyleBackColor = true;
            btnUpdateCustomer.Click += btnUpdateCustomer_Click;
            // 
            // btnAddCustomer
            // 
            btnAddCustomer.Location = new Point(9, 498);
            btnAddCustomer.Name = "btnAddCustomer";
            btnAddCustomer.Size = new Size(94, 32);
            btnAddCustomer.TabIndex = 2;
            btnAddCustomer.Text = "Hozzáadás";
            btnAddCustomer.UseVisualStyleBackColor = true;
            btnAddCustomer.Click += btnAddCustomer_Click;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(txtCustomerId);
            groupBox1.Controls.Add(label7);
            groupBox1.Controls.Add(label6);
            groupBox1.Controls.Add(label5);
            groupBox1.Controls.Add(label4);
            groupBox1.Controls.Add(label3);
            groupBox1.Controls.Add(label2);
            groupBox1.Controls.Add(chkIsVIP);
            groupBox1.Controls.Add(dtpRegistrationDate);
            groupBox1.Controls.Add(txtPassword);
            groupBox1.Controls.Add(txtPhoneNumber);
            groupBox1.Controls.Add(txtEmail);
            groupBox1.Controls.Add(txtAddress);
            groupBox1.Controls.Add(txtContactInfo);
            groupBox1.Controls.Add(txtName);
            groupBox1.Location = new Point(9, 181);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(481, 313);
            groupBox1.TabIndex = 1;
            groupBox1.TabStop = false;
            groupBox1.Text = "Részletek";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // txtCustomerId
            // 
            txtCustomerId.AccessibleName = "txtCustomerId";
            txtCustomerId.Location = new Point(142, 23);
            txtCustomerId.Name = "txtCustomerId";
            txtCustomerId.ReadOnly = true;
            txtCustomerId.Size = new Size(125, 27);
            txtCustomerId.TabIndex = 13;
            txtCustomerId.TextChanged += textBox7_TextChanged;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(6, 228);
            label7.Name = "label7";
            label7.Size = new Size(51, 20);
            label7.TabIndex = 12;
            label7.Text = "Jelszó:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(6, 195);
            label6.Name = "label6";
            label6.Size = new Size(95, 20);
            label6.TabIndex = 11;
            label6.Text = "Telefonszám:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 162);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 10;
            label5.Text = "Email:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 129);
            label4.Name = "label4";
            label4.Size = new Size(38, 20);
            label4.TabIndex = 9;
            label4.Text = "Cím:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 96);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 8;
            label3.Text = "Kapcsolati info:";
            label3.Click += label3_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 63);
            label2.Name = "label2";
            label2.Size = new Size(38, 20);
            label2.TabIndex = 7;
            label2.Text = "Név:";
            label2.Click += label2_Click;
            // 
            // chkIsVIP
            // 
            chkIsVIP.AutoSize = true;
            chkIsVIP.Location = new Point(142, 287);
            chkIsVIP.Name = "chkIsVIP";
            chkIsVIP.Size = new Size(52, 24);
            chkIsVIP.TabIndex = 6;
            chkIsVIP.Text = "VIP";
            chkIsVIP.UseVisualStyleBackColor = true;
            chkIsVIP.CheckedChanged += checkBox1_CheckedChanged;
            // 
            // dtpRegistrationDate
            // 
            dtpRegistrationDate.Location = new Point(142, 254);
            dtpRegistrationDate.Name = "dtpRegistrationDate";
            dtpRegistrationDate.Size = new Size(250, 27);
            dtpRegistrationDate.TabIndex = 5;
            dtpRegistrationDate.ValueChanged += dateTimePicker1_ValueChanged;
            // 
            // txtPassword
            // 
            txtPassword.Location = new Point(142, 221);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(321, 27);
            txtPassword.TabIndex = 2;
            txtPassword.TextChanged += txtPhoneNumber_TextChanged;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(142, 188);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(323, 27);
            txtPhoneNumber.TabIndex = 4;
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(142, 155);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(321, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtAddress
            // 
            txtAddress.Location = new Point(142, 122);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(321, 27);
            txtAddress.TabIndex = 2;
            txtAddress.TextChanged += textBox3_TextChanged;
            // 
            // txtContactInfo
            // 
            txtContactInfo.Location = new Point(142, 89);
            txtContactInfo.Name = "txtContactInfo";
            txtContactInfo.Size = new Size(321, 27);
            txtContactInfo.TabIndex = 1;
            txtContactInfo.TextChanged += textBox2_TextChanged;
            // 
            // txtName
            // 
            txtName.Location = new Point(142, 56);
            txtName.Name = "txtName";
            txtName.Size = new Size(321, 27);
            txtName.TabIndex = 0;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // dgvCustomers
            // 
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(9, 6);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(666, 156);
            dgvCustomers.TabIndex = 0;
            dgvCustomers.CellContentClick += dgvCustomers_SelectionChanged;
            // 
            // tabTechnician
            // 
            tabTechnician.Controls.Add(txtTechnicianId);
            tabTechnician.Controls.Add(btnDeleteTech);
            tabTechnician.Controls.Add(btnUpdateTech);
            tabTechnician.Controls.Add(btnAddTech);
            tabTechnician.Controls.Add(txtPassword2);
            tabTechnician.Controls.Add(label16);
            tabTechnician.Controls.Add(cmbShift);
            tabTechnician.Controls.Add(label15);
            tabTechnician.Controls.Add(numCompletedRepairs);
            tabTechnician.Controls.Add(label14);
            tabTechnician.Controls.Add(chkIsOnLeave);
            tabTechnician.Controls.Add(lbIsOnLeave);
            tabTechnician.Controls.Add(dtpHireDate);
            tabTechnician.Controls.Add(lblHireDate);
            tabTechnician.Controls.Add(label13);
            tabTechnician.Controls.Add(txtPhone2);
            tabTechnician.Controls.Add(txtEmail2);
            tabTechnician.Controls.Add(label12);
            tabTechnician.Controls.Add(numTotalWorkHours);
            tabTechnician.Controls.Add(label11);
            tabTechnician.Controls.Add(chkIsAvaliable);
            tabTechnician.Controls.Add(label10);
            tabTechnician.Controls.Add(txtExpertise);
            tabTechnician.Controls.Add(label9);
            tabTechnician.Controls.Add(txtName2);
            tabTechnician.Controls.Add(label8);
            tabTechnician.Controls.Add(dgvTechnicians);
            tabTechnician.Location = new Point(4, 29);
            tabTechnician.Name = "tabTechnician";
            tabTechnician.Padding = new Padding(3);
            tabTechnician.Size = new Size(804, 541);
            tabTechnician.TabIndex = 1;
            tabTechnician.Text = "Szervizesek";
            tabTechnician.UseVisualStyleBackColor = true;
            tabTechnician.Click += tabPage2_Click;
            // 
            // txtTechnicianId
            // 
            txtTechnicianId.Location = new Point(413, 165);
            txtTechnicianId.Name = "txtTechnicianId";
            txtTechnicianId.ReadOnly = true;
            txtTechnicianId.Size = new Size(52, 27);
            txtTechnicianId.TabIndex = 26;
            // 
            // btnDeleteTech
            // 
            btnDeleteTech.Location = new Point(637, 500);
            btnDeleteTech.Name = "btnDeleteTech";
            btnDeleteTech.Size = new Size(94, 29);
            btnDeleteTech.TabIndex = 25;
            btnDeleteTech.Text = "Törlés";
            btnDeleteTech.UseVisualStyleBackColor = true;
            btnDeleteTech.Click += btnDeleteTechnician_Click;
            // 
            // btnUpdateTech
            // 
            btnUpdateTech.Location = new Point(525, 500);
            btnUpdateTech.Name = "btnUpdateTech";
            btnUpdateTech.Size = new Size(94, 29);
            btnUpdateTech.TabIndex = 24;
            btnUpdateTech.Text = "Módosítás";
            btnUpdateTech.UseVisualStyleBackColor = true;
            btnUpdateTech.Click += btnEditTechnician_Click;
            // 
            // btnAddTech
            // 
            btnAddTech.Location = new Point(413, 500);
            btnAddTech.Name = "btnAddTech";
            btnAddTech.Size = new Size(95, 29);
            btnAddTech.TabIndex = 23;
            btnAddTech.Text = "Hozzáadás";
            btnAddTech.UseVisualStyleBackColor = true;
            btnAddTech.Click += btnAddTechnician_Click;
            // 
            // txtPassword2
            // 
            txtPassword2.Location = new Point(172, 502);
            txtPassword2.Name = "txtPassword2";
            txtPassword2.Size = new Size(189, 27);
            txtPassword2.TabIndex = 22;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(10, 504);
            label16.Name = "label16";
            label16.Size = new Size(51, 20);
            label16.TabIndex = 21;
            label16.Text = "Jelszó:";
            // 
            // cmbShift
            // 
            cmbShift.FormattingEnabled = true;
            cmbShift.Items.AddRange(new object[] { "Reggel", "Délután", "Éjszaka" });
            cmbShift.Location = new Point(172, 468);
            cmbShift.Name = "cmbShift";
            cmbShift.Size = new Size(151, 28);
            cmbShift.TabIndex = 20;
            cmbShift.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(10, 476);
            label15.Name = "label15";
            label15.Size = new Size(61, 20);
            label15.TabIndex = 19;
            label15.Text = "Műszak:";
            // 
            // numCompletedRepairs
            // 
            numCompletedRepairs.Location = new Point(172, 436);
            numCompletedRepairs.Name = "numCompletedRepairs";
            numCompletedRepairs.Size = new Size(51, 27);
            numCompletedRepairs.TabIndex = 18;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(10, 443);
            label14.Name = "label14";
            label14.Size = new Size(141, 20);
            label14.TabIndex = 17;
            label14.Text = "Befejezett javítások:";
            // 
            // chkIsOnLeave
            // 
            chkIsOnLeave.AutoSize = true;
            chkIsOnLeave.Location = new Point(172, 409);
            chkIsOnLeave.Name = "chkIsOnLeave";
            chkIsOnLeave.Size = new Size(18, 17);
            chkIsOnLeave.TabIndex = 16;
            chkIsOnLeave.UseVisualStyleBackColor = true;
            chkIsOnLeave.CheckedChanged += checkBox1_CheckedChanged_2;
            // 
            // lbIsOnLeave
            // 
            lbIsOnLeave.AutoSize = true;
            lbIsOnLeave.Location = new Point(10, 409);
            lbIsOnLeave.Name = "lbIsOnLeave";
            lbIsOnLeave.Size = new Size(105, 20);
            lbIsOnLeave.TabIndex = 15;
            lbIsOnLeave.Text = "Szabadságon?";
            // 
            // dtpHireDate
            // 
            dtpHireDate.Location = new Point(172, 367);
            dtpHireDate.Name = "dtpHireDate";
            dtpHireDate.Size = new Size(189, 27);
            dtpHireDate.TabIndex = 14;
            // 
            // lblHireDate
            // 
            lblHireDate.AutoSize = true;
            lblHireDate.Location = new Point(10, 374);
            lblHireDate.Name = "lblHireDate";
            lblHireDate.Size = new Size(118, 20);
            lblHireDate.TabIndex = 13;
            lblHireDate.Text = "Felvétel dátuma:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(10, 341);
            label13.Name = "label13";
            label13.Size = new Size(95, 20);
            label13.TabIndex = 12;
            label13.Text = "Telefonszám:";
            // 
            // txtPhone2
            // 
            txtPhone2.Location = new Point(172, 334);
            txtPhone2.Name = "txtPhone2";
            txtPhone2.Size = new Size(189, 27);
            txtPhone2.TabIndex = 11;
            txtPhone2.TextChanged += textBox2_TextChanged_1;
            // 
            // txtEmail2
            // 
            txtEmail2.Location = new Point(172, 301);
            txtEmail2.Name = "txtEmail2";
            txtEmail2.Size = new Size(189, 27);
            txtEmail2.TabIndex = 10;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(9, 308);
            label12.Name = "label12";
            label12.Size = new Size(49, 20);
            label12.TabIndex = 9;
            label12.Text = "Email:";
            // 
            // numTotalWorkHours
            // 
            numTotalWorkHours.Location = new Point(172, 265);
            numTotalWorkHours.Name = "numTotalWorkHours";
            numTotalWorkHours.Size = new Size(52, 27);
            numTotalWorkHours.TabIndex = 8;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(9, 272);
            label11.Name = "label11";
            label11.Size = new Size(119, 20);
            label11.TabIndex = 7;
            label11.Text = "Teljes munkaóra:";
            // 
            // chkIsAvaliable
            // 
            chkIsAvaliable.AutoSize = true;
            chkIsAvaliable.Location = new Point(172, 240);
            chkIsAvaliable.Name = "chkIsAvaliable";
            chkIsAvaliable.Size = new Size(18, 17);
            chkIsAvaliable.TabIndex = 6;
            chkIsAvaliable.UseVisualStyleBackColor = true;
            chkIsAvaliable.CheckedChanged += checkBox1_CheckedChanged_1;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 240);
            label10.Name = "label10";
            label10.Size = new Size(71, 20);
            label10.TabIndex = 5;
            label10.Text = "Elérhető?";
            // 
            // txtExpertise
            // 
            txtExpertise.Location = new Point(172, 198);
            txtExpertise.Name = "txtExpertise";
            txtExpertise.Size = new Size(189, 27);
            txtExpertise.TabIndex = 4;
            txtExpertise.TextChanged += textBox1_TextChanged_2;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(6, 205);
            label9.Name = "label9";
            label9.Size = new Size(85, 20);
            label9.TabIndex = 3;
            label9.Text = "Szakterület:";
            // 
            // txtName2
            // 
            txtName2.Location = new Point(172, 165);
            txtName2.Name = "txtName2";
            txtName2.Size = new Size(189, 27);
            txtName2.TabIndex = 2;
            txtName2.TextChanged += textBox1_TextChanged_1;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(9, 172);
            label8.Name = "label8";
            label8.Size = new Size(38, 20);
            label8.TabIndex = 1;
            label8.Text = "Név:";
            // 
            // dgvTechnicians
            // 
            dgvTechnicians.AccessibleName = "dgvTechnicians";
            dgvTechnicians.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvTechnicians.Location = new Point(6, 6);
            dgvTechnicians.Name = "dgvTechnicians";
            dgvTechnicians.RowHeadersWidth = 51;
            dgvTechnicians.Size = new Size(674, 148);
            dgvTechnicians.TabIndex = 0;
            dgvTechnicians.SelectionChanged += dgvTechnicians_SelectionChanged;
            // 
            // tabWorkdOrders
            // 
            tabWorkdOrders.Location = new Point(4, 29);
            tabWorkdOrders.Name = "tabWorkdOrders";
            tabWorkdOrders.Padding = new Padding(3);
            tabWorkdOrders.Size = new Size(804, 541);
            tabWorkdOrders.TabIndex = 2;
            tabWorkdOrders.Text = "Munkalapok";
            tabWorkdOrders.UseVisualStyleBackColor = true;
            tabWorkdOrders.Click += tabWorkdOrders_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(296, 18);
            label1.Name = "label1";
            label1.Size = new Size(152, 31);
            label1.TabIndex = 1;
            label1.Text = "Admin felület";
            // 
            // AdminDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 642);
            Controls.Add(label1);
            Controls.Add(tabControl1);
            Name = "AdminDashboardForm";
            Text = "AdminDashboardForm";
            tabControl1.ResumeLayout(false);
            tabCustomers.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            tabTechnician.ResumeLayout(false);
            tabTechnician.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)numCompletedRepairs).EndInit();
            ((System.ComponentModel.ISupportInitialize)numTotalWorkHours).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvTechnicians).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabCustomers;
        private TabPage tabTechnician;
        private TabPage tabWorkdOrders;
        private Label label1;
        private DataGridView dgvCustomers;
        private GroupBox groupBox1;
        private TextBox txtName;
        private TextBox txtAddress;
        private TextBox txtContactInfo;
        private TextBox txtEmail;
        private TextBox txtPassword;
        private TextBox txtPhoneNumber;
        private CheckBox chkIsVIP;
        private DateTimePicker dtpRegistrationDate;
        private Label label2;
        private Label label3;
        private Label label6;
        private Label label5;
        private Label label4;
        private Button btnAddCustomer;
        private Label label7;
        private Button button4;
        private Button btnDeleteCustomer;
        private Button btnUpdateCustomer;
        private TextBox txtCustomerId;
        private DataGridView dgvTechnicians;
        private TextBox txtName2;
        private Label label8;
        private TextBox txtExpertise;
        private Label label9;
        private Label label10;
        private CheckBox chkIsAvaliable;
        private Label label13;
        private TextBox txtPhone2;
        private TextBox txtEmail2;
        private Label label12;
        private NumericUpDown numTotalWorkHours;
        private Label label11;
        private Label lblHireDate;
        private Label lbIsOnLeave;
        private DateTimePicker dtpHireDate;
        private CheckBox chkIsOnLeave;
        private ComboBox cmbShift;
        private Label label15;
        private NumericUpDown numCompletedRepairs;
        private Label label14;
        private TextBox txtPassword2;
        private Label label16;
        private Button btnDeleteTech;
        private Button btnUpdateTech;
        private Button btnAddTech;
        private TextBox txtTechnicianId;
    }
}