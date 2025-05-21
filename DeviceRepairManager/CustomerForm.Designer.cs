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
            label1 = new Label();
            label2 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            textBox2 = new TextBox();
            label4 = new Label();
            textBox3 = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AccessibleName = "lblName\t";
            label1.AutoSize = true;
            label1.Font = new Font("Copperplate Gothic Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(13, 62);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(42, 16);
            label1.TabIndex = 0;
            label1.Text = "Név:";
            label1.Click += label1_Click_1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Ink Free", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(44, 19);
            label2.Name = "label2";
            label2.Size = new Size(156, 19);
            label2.TabIndex = 1;
            label2.Text = " Ügyfélkezelő felület";
            label2.Click += label2_Click;
            // 
            // textBox1
            // 
            textBox1.AccessibleDescription = "";
            textBox1.AccessibleName = "txtName\t";
            textBox1.Font = new Font("Ink Free", 7.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(146, 54);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(179, 24);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AccessibleName = "lblEmail\t";
            label3.AutoSize = true;
            label3.Location = new Point(12, 104);
            label3.Name = "label3";
            label3.Size = new Size(60, 16);
            label3.TabIndex = 3;
            label3.Text = "E-Mail:";
            label3.Click += label3_Click;
            // 
            // textBox2
            // 
            textBox2.AccessibleName = "txtEmail";
            textBox2.Location = new Point(146, 96);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(179, 24);
            textBox2.TabIndex = 4;
            // 
            // label4
            // 
            label4.AccessibleName = "lblPhone";
            label4.AutoSize = true;
            label4.Location = new Point(12, 148);
            label4.Name = "label4";
            label4.Size = new Size(116, 16);
            label4.TabIndex = 5;
            label4.Text = "Telefonszám:";
            // 
            // textBox3
            // 
            textBox3.AccessibleName = "txtPhone";
            textBox3.Location = new Point(146, 140);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(179, 24);
            textBox3.TabIndex = 6;
            // 
            // CustomerForm
            // 
            AutoScaleDimensions = new SizeF(10F, 16F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 360);
            Controls.Add(textBox3);
            Controls.Add(label4);
            Controls.Add(textBox2);
            Controls.Add(label3);
            Controls.Add(textBox1);
            Controls.Add(label2);
            Controls.Add(label1);
            Font = new Font("Copperplate Gothic Light", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Margin = new Padding(4, 2, 4, 2);
            Name = "CustomerForm";
            Text = "CustomerForm";
            Load += CustomerForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox textBox1;
        private Label label3;
        private TextBox textBox2;
        private Label label4;
        private TextBox textBox3;
    }
}