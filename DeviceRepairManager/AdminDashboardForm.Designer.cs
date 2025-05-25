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
            tabWorkdOrders = new TabPage();
            label1 = new Label();
            tabControl1.SuspendLayout();
            tabCustomers.SuspendLayout();
            groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
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
            tabTechnician.Location = new Point(4, 29);
            tabTechnician.Name = "tabTechnician";
            tabTechnician.Padding = new Padding(3);
            tabTechnician.Size = new Size(804, 541);
            tabTechnician.TabIndex = 1;
            tabTechnician.Text = "Szervizesek";
            tabTechnician.UseVisualStyleBackColor = true;
            tabTechnician.Click += tabPage2_Click;
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
    }
}