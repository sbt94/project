namespace Sql_FinalProject
{
    partial class NewEmployeeForm
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
            name_lb = new Label();
            surname_lb = new Label();
            Email_lbl = new Label();
            Phone_lb = new Label();
            Name_txt = new TextBox();
            Surname_txt = new TextBox();
            Email_txt = new TextBox();
            Phone_txt = new TextBox();
            salary_txt = new TextBox();
            Salary_lb = new Label();
            label2 = new Label();
            Password_txt = new TextBox();
            Sumbit_btn = new Button();
            SuspendLayout();
            // 
            // name_lb
            // 
            name_lb.AutoSize = true;
            name_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            name_lb.Location = new Point(23, 50);
            name_lb.Name = "name_lb";
            name_lb.Size = new Size(59, 25);
            name_lb.TabIndex = 0;
            name_lb.Text = "name";
            // 
            // surname_lb
            // 
            surname_lb.AutoSize = true;
            surname_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            surname_lb.Location = new Point(23, 102);
            surname_lb.Name = "surname_lb";
            surname_lb.Size = new Size(85, 25);
            surname_lb.TabIndex = 1;
            surname_lb.Text = "surname";
            // 
            // Email_lbl
            // 
            Email_lbl.AutoSize = true;
            Email_lbl.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Email_lbl.Location = new Point(23, 157);
            Email_lbl.Name = "Email_lbl";
            Email_lbl.Size = new Size(58, 25);
            Email_lbl.TabIndex = 2;
            Email_lbl.Text = "Email";
            // 
            // Phone_lb
            // 
            Phone_lb.AutoSize = true;
            Phone_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Phone_lb.Location = new Point(23, 222);
            Phone_lb.Name = "Phone_lb";
            Phone_lb.Size = new Size(140, 25);
            Phone_lb.TabIndex = 3;
            Phone_lb.Text = "Phone Number";
            // 
            // Name_txt
            // 
            Name_txt.Location = new Point(298, 50);
            Name_txt.Margin = new Padding(3, 2, 3, 2);
            Name_txt.Name = "Name_txt";
            Name_txt.Size = new Size(261, 23);
            Name_txt.TabIndex = 5;
            // 
            // Surname_txt
            // 
            Surname_txt.Location = new Point(298, 97);
            Surname_txt.Margin = new Padding(3, 2, 3, 2);
            Surname_txt.Name = "Surname_txt";
            Surname_txt.Size = new Size(261, 23);
            Surname_txt.TabIndex = 6;
            // 
            // Email_txt
            // 
            Email_txt.Location = new Point(298, 154);
            Email_txt.Margin = new Padding(3, 2, 3, 2);
            Email_txt.Name = "Email_txt";
            Email_txt.Size = new Size(261, 23);
            Email_txt.TabIndex = 7;
            // 
            // Phone_txt
            // 
            Phone_txt.Location = new Point(298, 217);
            Phone_txt.Margin = new Padding(3, 2, 3, 2);
            Phone_txt.Name = "Phone_txt";
            Phone_txt.Size = new Size(261, 23);
            Phone_txt.TabIndex = 8;
            // 
            // salary_txt
            // 
            salary_txt.Location = new Point(298, 275);
            salary_txt.Margin = new Padding(3, 2, 3, 2);
            salary_txt.Name = "salary_txt";
            salary_txt.Size = new Size(261, 23);
            salary_txt.TabIndex = 9;
            // 
            // Salary_lb
            // 
            Salary_lb.AutoSize = true;
            Salary_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Salary_lb.Location = new Point(23, 271);
            Salary_lb.Name = "Salary_lb";
            Salary_lb.Size = new Size(63, 25);
            Salary_lb.TabIndex = 10;
            Salary_lb.Text = "Salary";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(23, 345);
            label2.Name = "label2";
            label2.Size = new Size(91, 25);
            label2.TabIndex = 11;
            label2.Text = "Password";
            // 
            // Password_txt
            // 
            Password_txt.Location = new Point(298, 345);
            Password_txt.Margin = new Padding(3, 2, 3, 2);
            Password_txt.Name = "Password_txt";
            Password_txt.Size = new Size(261, 23);
            Password_txt.TabIndex = 12;
            // 
            // Sumbit_btn
            // 
            Sumbit_btn.Cursor = Cursors.Hand;
            Sumbit_btn.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            Sumbit_btn.Location = new Point(175, 404);
            Sumbit_btn.Margin = new Padding(3, 2, 3, 2);
            Sumbit_btn.Name = "Sumbit_btn";
            Sumbit_btn.Size = new Size(345, 125);
            Sumbit_btn.TabIndex = 13;
            Sumbit_btn.Text = "Submit";
            Sumbit_btn.UseVisualStyleBackColor = true;
            Sumbit_btn.Click += Sumbit_btn_Click;
            // 
            // NewEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 560);
            Controls.Add(Sumbit_btn);
            Controls.Add(Password_txt);
            Controls.Add(label2);
            Controls.Add(Salary_lb);
            Controls.Add(salary_txt);
            Controls.Add(Phone_txt);
            Controls.Add(Email_txt);
            Controls.Add(Surname_txt);
            Controls.Add(Name_txt);
            Controls.Add(Phone_lb);
            Controls.Add(Email_lbl);
            Controls.Add(surname_lb);
            Controls.Add(name_lb);
            Margin = new Padding(3, 2, 3, 2);
            Name = "NewEmployeeForm";
            Text = "NewEmployeeForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label name_lb;
        private Label surname_lb;
        private Label Email_lbl;
        private Label Phone_lb;
        private TextBox Name_txt;
        private TextBox Surname_txt;
        private TextBox Email_txt;
        private TextBox Phone_txt;
        private TextBox salary_txt;
        private Label Salary_lb;
        private Label label2;
        private TextBox Password_txt;
        private Button Sumbit_btn;
    }
}