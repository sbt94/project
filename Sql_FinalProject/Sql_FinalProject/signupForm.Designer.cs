namespace Sql_FinalProject
{
    partial class signupForm
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
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            Name_txt = new TextBox();
            Surname_txt = new TextBox();
            Email_txt = new TextBox();
            Phone_txt = new TextBox();
            Address_txt = new TextBox();
            Password_txt = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(47, 50);
            label1.Name = "label1";
            label1.Size = new Size(102, 25);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(47, 118);
            label2.Name = "label2";
            label2.Size = new Size(87, 25);
            label2.TabIndex = 1;
            label2.Text = "Surname";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(47, 190);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(47, 256);
            label4.Name = "label4";
            label4.Size = new Size(140, 25);
            label4.TabIndex = 3;
            label4.Text = "Phone Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(47, 331);
            label5.Name = "label5";
            label5.Size = new Size(79, 25);
            label5.TabIndex = 4;
            label5.Text = "Address";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(47, 412);
            label6.Name = "label6";
            label6.Size = new Size(91, 25);
            label6.TabIndex = 5;
            label6.Text = "Password";
            // 
            // Name_txt
            // 
            Name_txt.Location = new Point(360, 53);
            Name_txt.Margin = new Padding(3, 2, 3, 2);
            Name_txt.Name = "Name_txt";
            Name_txt.Size = new Size(266, 23);
            Name_txt.TabIndex = 6;
            // 
            // Surname_txt
            // 
            Surname_txt.Location = new Point(360, 118);
            Surname_txt.Margin = new Padding(3, 2, 3, 2);
            Surname_txt.Name = "Surname_txt";
            Surname_txt.Size = new Size(266, 23);
            Surname_txt.TabIndex = 7;
            // 
            // Email_txt
            // 
            Email_txt.Location = new Point(360, 190);
            Email_txt.Margin = new Padding(3, 2, 3, 2);
            Email_txt.Name = "Email_txt";
            Email_txt.Size = new Size(266, 23);
            Email_txt.TabIndex = 8;
            // 
            // Phone_txt
            // 
            Phone_txt.Location = new Point(360, 256);
            Phone_txt.Margin = new Padding(3, 2, 3, 2);
            Phone_txt.Name = "Phone_txt";
            Phone_txt.Size = new Size(266, 23);
            Phone_txt.TabIndex = 9;
            // 
            // Address_txt
            // 
            Address_txt.Location = new Point(360, 331);
            Address_txt.Margin = new Padding(3, 2, 3, 2);
            Address_txt.Name = "Address_txt";
            Address_txt.Size = new Size(266, 23);
            Address_txt.TabIndex = 10;
            // 
            // Password_txt
            // 
            Password_txt.Location = new Point(360, 416);
            Password_txt.Margin = new Padding(3, 2, 3, 2);
            Password_txt.Name = "Password_txt";
            Password_txt.Size = new Size(266, 23);
            Password_txt.TabIndex = 11;
            // 
            // signupForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 490);
            Controls.Add(Password_txt);
            Controls.Add(Address_txt);
            Controls.Add(Phone_txt);
            Controls.Add(Email_txt);
            Controls.Add(Surname_txt);
            Controls.Add(Name_txt);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "signupForm";
            Text = "signupForm";
            Load += signupForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox Name_txt;
        private TextBox Surname_txt;
        private TextBox Email_txt;
        private TextBox Phone_txt;
        private TextBox Address_txt;
        private TextBox Password_txt;
    }
}