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
            label1.Location = new Point(54, 66);
            label1.Name = "label1";
            label1.Size = new Size(129, 32);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(54, 158);
            label2.Name = "label2";
            label2.Size = new Size(109, 32);
            label2.TabIndex = 1;
            label2.Text = "Surname";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(54, 253);
            label3.Name = "label3";
            label3.Size = new Size(71, 32);
            label3.TabIndex = 2;
            label3.Text = "Email";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label4.Location = new Point(54, 342);
            label4.Name = "label4";
            label4.Size = new Size(177, 32);
            label4.TabIndex = 3;
            label4.Text = "Phone Number";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label5.Location = new Point(54, 441);
            label5.Name = "label5";
            label5.Size = new Size(98, 32);
            label5.TabIndex = 4;
            label5.Text = "Address";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label6.Location = new Point(54, 550);
            label6.Name = "label6";
            label6.Size = new Size(111, 32);
            label6.TabIndex = 5;
            label6.Text = "Password";
            // 
            // Name_txt
            // 
            Name_txt.Location = new Point(411, 71);
            Name_txt.Name = "Name_txt";
            Name_txt.Size = new Size(304, 27);
            Name_txt.TabIndex = 6;
            // 
            // Surname_txt
            // 
            Surname_txt.Location = new Point(411, 158);
            Surname_txt.Name = "Surname_txt";
            Surname_txt.Size = new Size(304, 27);
            Surname_txt.TabIndex = 7;
            // 
            // Email_txt
            // 
            Email_txt.Location = new Point(411, 253);
            Email_txt.Name = "Email_txt";
            Email_txt.Size = new Size(304, 27);
            Email_txt.TabIndex = 8;
            // 
            // Phone_txt
            // 
            Phone_txt.Location = new Point(411, 342);
            Phone_txt.Name = "Phone_txt";
            Phone_txt.Size = new Size(304, 27);
            Phone_txt.TabIndex = 9;
            // 
            // Address_txt
            // 
            Address_txt.Location = new Point(411, 441);
            Address_txt.Name = "Address_txt";
            Address_txt.Size = new Size(304, 27);
            Address_txt.TabIndex = 10;
            // 
            // Password_txt
            // 
            Password_txt.Location = new Point(411, 555);
            Password_txt.Name = "Password_txt";
            Password_txt.Size = new Size(304, 27);
            Password_txt.TabIndex = 11;
            // 
            // signupForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 654);
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
            Name = "signupForm";
            Text = "signupForm";
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