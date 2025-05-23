namespace DeviceRepairManager
{
    partial class LoginForm
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
            lblUsername = new Label();
            txtUsername = new TextBox();
            lblPassword = new Label();
            txtPassword = new TextBox();
            btnLogin = new Button();
            label3 = new Label();
            SuspendLayout();
            // 
            // label1
            // 
            lblUsername.AccessibleName = "lblUsername";
            lblUsername.AutoSize = true;
            lblUsername.Location = new Point(128, 160);
            lblUsername.Name = "label1";
            lblUsername.Size = new Size(160, 20);
            lblUsername.TabIndex = 0;
            lblUsername.Text = "Felhasználónév / Email";
            lblUsername.Click += label1_Click;
            // 
            // textBox1
            // 
            txtUsername.AccessibleName = "txtUsername";
            txtUsername.Location = new Point(294, 157);
            txtUsername.Name = "textBox1";
            txtUsername.Size = new Size(190, 27);
            txtUsername.TabIndex = 1;
            txtUsername.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            lblPassword.AccessibleName = "lblPassword";
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(240, 212);
            lblPassword.Name = "label2";
            lblPassword.Size = new Size(48, 20);
            lblPassword.TabIndex = 2;
            lblPassword.Text = "Jelszó";
            lblPassword.Click += label2_Click;
            // 
            // textBox2
            // 
            txtPassword.Location = new Point(294, 209);
            txtPassword.Name = "textBox2";
            txtPassword.Size = new Size(190, 27);
            txtPassword.TabIndex = 3;
            // 
            // button1
            // 
            btnLogin.AccessibleName = "btnLogin";
            btnLogin.Location = new Point(322, 277);
            btnLogin.Name = "button1";
            btnLogin.Size = new Size(121, 46);
            btnLogin.TabIndex = 4;
            btnLogin.Text = "Belépés";
            btnLogin.UseVisualStyleBackColor = true;
            btnLogin.Click += btnLogin_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(312, 40);
            label3.Name = "label3";
            label3.Size = new Size(148, 28);
            label3.TabIndex = 5;
            label3.Text = "BEJELENTKEZÉS";
            label3.Click += label3_Click;
            // 
            // LoginForm
            // 
            AccessibleName = "txtPassword";
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label3);
            Controls.Add(btnLogin);
            Controls.Add(txtPassword);
            Controls.Add(lblPassword);
            Controls.Add(txtUsername);
            Controls.Add(lblUsername);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnLogin;
        private Label label3;
    }
}