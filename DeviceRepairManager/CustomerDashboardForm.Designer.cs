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
            lblWelcome = new Label();
            grpCustomerInfo = new GroupBox();
            txtName = new TextBox();
            txtEmail = new TextBox();
            txtPhone = new TextBox();
            dgvDevices = new DataGridView();
            btnSubmitRepair = new Button();
            grpCustomerInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).BeginInit();
            SuspendLayout();
            // 
            // lblWelcome
            // 
            lblWelcome.AccessibleName = "lblWelcome";
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblWelcome.Location = new Point(282, 25);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(176, 41);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Üdvözöljük!";
            // 
            // grpCustomerInfo
            // 
            grpCustomerInfo.AccessibleName = "grpCustomerInfo";
            grpCustomerInfo.Controls.Add(txtName);
            grpCustomerInfo.Controls.Add(txtEmail);
            grpCustomerInfo.Controls.Add(txtPhone);
            grpCustomerInfo.Location = new Point(139, 87);
            grpCustomerInfo.Name = "grpCustomerInfo";
            grpCustomerInfo.Size = new Size(258, 246);
            grpCustomerInfo.TabIndex = 1;
            grpCustomerInfo.TabStop = false;
            grpCustomerInfo.Text = "Ügyféladatok";
            grpCustomerInfo.Enter += groupBox1_Enter;
            // 
            // txtName
            // 
            txtName.AccessibleName = "txtName";
            txtName.Location = new Point(18, 36);
            txtName.Name = "txtName";
            txtName.ReadOnly = true;
            txtName.Size = new Size(225, 27);
            txtName.TabIndex = 2;
            txtName.TextChanged += txtName_TextChanged;
            // 
            // txtEmail
            // 
            txtEmail.AccessibleName = "txtEmail";
            txtEmail.Location = new Point(18, 100);
            txtEmail.Name = "txtEmail";
            txtEmail.ReadOnly = true;
            txtEmail.Size = new Size(225, 27);
            txtEmail.TabIndex = 3;
            // 
            // txtPhone
            // 
            txtPhone.AccessibleName = "txtPhone";
            txtPhone.Location = new Point(18, 161);
            txtPhone.Name = "txtPhone";
            txtPhone.ReadOnly = true;
            txtPhone.Size = new Size(225, 27);
            txtPhone.TabIndex = 4;
            // 
            // dgvDevices
            // 
            dgvDevices.AccessibleName = "dgvDevices";
            dgvDevices.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDevices.Location = new Point(432, 99);
            dgvDevices.Name = "dgvDevices";
            dgvDevices.RowHeadersWidth = 51;
            dgvDevices.Size = new Size(300, 188);
            dgvDevices.TabIndex = 5;
            // 
            // btnSubmitRepair
            // 
            btnSubmitRepair.AccessibleName = "btnSubmitRepair";
            btnSubmitRepair.Location = new Point(499, 303);
            btnSubmitRepair.Name = "btnSubmitRepair";
            btnSubmitRepair.Size = new Size(152, 51);
            btnSubmitRepair.TabIndex = 6;
            btnSubmitRepair.Text = "Szervizigény leadása\n\n";
            btnSubmitRepair.UseVisualStyleBackColor = true;
            btnSubmitRepair.Click += btnSubmitRepair_Click;
            // 
            // CustomerDashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(btnSubmitRepair);
            Controls.Add(dgvDevices);
            Controls.Add(grpCustomerInfo);
            Controls.Add(lblWelcome);
            Name = "CustomerDashboardForm";
            Text = "CustomerDashboardForm";
            Load += CustomerDashboardForm_Load;
            grpCustomerInfo.ResumeLayout(false);
            grpCustomerInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDevices).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblWelcome;
        private GroupBox grpCustomerInfo;
        private TextBox txtName;
        private TextBox txtEmail;
        private TextBox txtPhone;
        private DataGridView dgvDevices;
        private Button btnSubmitRepair;
    }
}