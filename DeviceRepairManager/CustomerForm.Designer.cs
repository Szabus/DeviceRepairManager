namespace DeviceRepairManager
{
    partial class CustomerForm
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
            lblName = new Label();
            label2 = new Label();
            txtName = new TextBox();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblAddress = new Label();
            txtAddress = new TextBox();
            lblContact = new Label();
            txtContact = new TextBox();
            label7 = new Label();
            dtpRegistrationDate = new DateTimePicker();
            chkIsVIP = new CheckBox();
            btnAdd = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            btnLoad = new Button();
            dgvCustomers = new DataGridView();
            btnSubmitRepair = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SuspendLayout();
            // 
            // lblName
            // 
            lblName.AccessibleName = "lblName\t";
            lblName.AutoSize = true;
            lblName.Font = new Font("Courier New", 9F);
            lblName.Location = new Point(13, 94);
            lblName.Margin = new Padding(4, 0, 4, 0);
            lblName.Name = "lblName";
            lblName.Size = new Size(44, 17);
            lblName.TabIndex = 0;
            lblName.Text = "Név:";
            lblName.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Courier New", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(115, 21);
            label2.Name = "label2";
            label2.Size = new Size(262, 22);
            label2.TabIndex = 1;
            label2.Text = " Ügyfélkezelő felület";
            label2.Click += label2_Click;
            // 
            // txtName
            // 
            txtName.AccessibleDescription = "";
            txtName.AccessibleName = "txtName\t";
            txtName.Font = new Font("Ink Free", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtName.Location = new Point(212, 86);
            txtName.Name = "txtName";
            txtName.Size = new Size(263, 24);
            txtName.TabIndex = 2;
            txtName.TextChanged += textBox1_TextChanged;
            // 
            // lblEmail
            // 
            lblEmail.AccessibleName = "lblEmail\t";
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Courier New", 9F);
            lblEmail.Location = new Point(13, 131);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 17);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "E-Mail:";
            lblEmail.Click += label3_Click;
            // 
            // txtEmail
            // 
            txtEmail.AccessibleName = "txtEmail";
            txtEmail.Location = new Point(212, 128);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(263, 24);
            txtEmail.TabIndex = 4;
            // 
            // lblPhone
            // 
            lblPhone.AccessibleName = "lblPhone";
            lblPhone.AutoSize = true;
            lblPhone.Font = new Font("Courier New", 9F);
            lblPhone.Location = new Point(12, 180);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(116, 17);
            lblPhone.TabIndex = 5;
            lblPhone.Text = "Telefonszám:";
            // 
            // txtPhone
            // 
            txtPhone.AccessibleName = "txtPhone";
            txtPhone.Location = new Point(211, 172);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(264, 24);
            txtPhone.TabIndex = 6;
            // 
            // lblAddress
            // 
            lblAddress.AccessibleName = "lblAddress";
            lblAddress.AutoSize = true;
            lblAddress.Font = new Font("Courier New", 9F);
            lblAddress.Location = new Point(12, 224);
            lblAddress.Name = "lblAddress";
            lblAddress.Size = new Size(44, 17);
            lblAddress.TabIndex = 7;
            lblAddress.Text = "Cím:";
            // 
            // txtAddress
            // 
            txtAddress.AccessibleName = "txtAddress";
            txtAddress.Location = new Point(211, 216);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(264, 24);
            txtAddress.TabIndex = 8;
            // 
            // lblContact
            // 
            lblContact.AccessibleName = "lblContact";
            lblContact.AutoSize = true;
            lblContact.Font = new Font("Courier New", 9F);
            lblContact.Location = new Point(12, 263);
            lblContact.Name = "lblContact";
            lblContact.Size = new Size(170, 17);
            lblContact.TabIndex = 9;
            lblContact.Text = "Egyéb elérhetőség:";
            // 
            // txtContact
            // 
            txtContact.AccessibleName = "txtContact";
            txtContact.Location = new Point(212, 255);
            txtContact.Name = "txtContact";
            txtContact.Size = new Size(263, 24);
            txtContact.TabIndex = 10;
            // 
            // label7
            // 
            label7.AccessibleName = "lblRegDate";
            label7.AutoSize = true;
            label7.Font = new Font("Courier New", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(12, 309);
            label7.Name = "label7";
            label7.Size = new Size(188, 17);
            label7.TabIndex = 11;
            label7.Text = "Regisztráció dátuma:";
            // 
            // dtpRegistrationDate
            // 
            dtpRegistrationDate.AccessibleName = "dtpRegistrationDate";
            dtpRegistrationDate.Location = new Point(212, 302);
            dtpRegistrationDate.Name = "dtpRegistrationDate";
            dtpRegistrationDate.Size = new Size(263, 24);
            dtpRegistrationDate.TabIndex = 12;
            // 
            // chkIsVIP
            // 
            chkIsVIP.AccessibleName = "chkIsVIP";
            chkIsVIP.AutoSize = true;
            chkIsVIP.Location = new Point(14, 351);
            chkIsVIP.Name = "chkIsVIP";
            chkIsVIP.Size = new Size(114, 20);
            chkIsVIP.TabIndex = 13;
            chkIsVIP.Text = "VIP ügyfél";
            chkIsVIP.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            btnAdd.AccessibleName = "btnAdd";
            btnAdd.Location = new Point(84, 395);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 29);
            btnAdd.TabIndex = 14;
            btnAdd.Text = "Hozzáadás";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnUpdate
            // 
            btnUpdate.AccessibleName = "btnUpdate";
            btnUpdate.Location = new Point(211, 395);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(105, 29);
            btnUpdate.TabIndex = 15;
            btnUpdate.Text = "Módosítás";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            // 
            // btnDelete
            // 
            btnDelete.AccessibleName = "btnDelete";
            btnDelete.Location = new Point(332, 395);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(94, 29);
            btnDelete.TabIndex = 16;
            btnDelete.Text = "Törlés";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnLoad
            // 
            btnLoad.AccessibleName = "btnLoad";
            btnLoad.Location = new Point(177, 464);
            btnLoad.Name = "btnLoad";
            btnLoad.Size = new Size(121, 29);
            btnLoad.TabIndex = 17;
            btnLoad.Text = "Ügyféllista";
            btnLoad.UseVisualStyleBackColor = true;
            // 
            // dgvCustomers
            // 
            dgvCustomers.AccessibleDescription = "dgvCustomers";
            dgvCustomers.AccessibleName = "dgvCustomers";
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Location = new Point(84, 516);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(300, 188);
            dgvCustomers.TabIndex = 18;
            dgvCustomers.CellClick += dgvCustomers_CellClick;
            // 
            // button1
            // 
            btnSubmitRepair.AccessibleName = "btnSubmitRepair";
            btnSubmitRepair.Location = new Point(211, 337);
            btnSubmitRepair.Name = "button1";
            btnSubmitRepair.Size = new Size(105, 46);
            btnSubmitRepair.TabIndex = 19;
            btnSubmitRepair.Text = "javítási igény";
            btnSubmitRepair.UseVisualStyleBackColor = true;
           // btnDelete.Click += btnSubmitRepair_Click;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(514, 765);
            Controls.Add(btnSubmitRepair);
            Controls.Add(dgvCustomers);
            Controls.Add(btnLoad);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnAdd);
            Controls.Add(chkIsVIP);
            Controls.Add(dtpRegistrationDate);
            Controls.Add(label7);
            Controls.Add(txtContact);
            Controls.Add(lblContact);
            Controls.Add(txtAddress);
            Controls.Add(lblAddress);
            Controls.Add(txtPhone);
            Controls.Add(lblPhone);
            Controls.Add(txtEmail);
            Controls.Add(lblEmail);
            Controls.Add(txtName);
            Controls.Add(label2);
            Controls.Add(lblName);
            Font = new Font("Copperplate Gothic Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 2, 4, 2);
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblName;
        private Label label2;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblAddress;
        private TextBox txtAddress;
        private Label lblContact;
        private TextBox txtContact;
        private Label label7;
        private DateTimePicker dtpRegistrationDate;
        private CheckBox chkIsVIP;
        private Button btnAdd;
        private Button btnUpdate;
        private Button btnDelete;
        private Button btnLoad;
        private DataGridView dgvCustomers;
        private Button btnSubmitRepair;
    }
}