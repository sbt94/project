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
            name_lb.Location = new Point(26, 67);
            name_lb.Name = "name_lb";
            name_lb.Size = new Size(74, 32);
            name_lb.TabIndex = 0;
            name_lb.Text = "name";
            // 
            // surname_lb
            // 
            surname_lb.AutoSize = true;
            surname_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            surname_lb.Location = new Point(26, 136);
            surname_lb.Name = "surname_lb";
            surname_lb.Size = new Size(106, 32);
            surname_lb.TabIndex = 1;
            surname_lb.Text = "surname";
            // 
            // Email_lbl
            // 
            Email_lbl.AutoSize = true;
            Email_lbl.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Email_lbl.Location = new Point(26, 209);
            Email_lbl.Name = "Email_lbl";
            Email_lbl.Size = new Size(71, 32);
            Email_lbl.TabIndex = 2;
            Email_lbl.Text = "Email";
            // 
            // Phone_lb
            // 
            Phone_lb.AutoSize = true;
            Phone_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Phone_lb.Location = new Point(26, 296);
            Phone_lb.Name = "Phone_lb";
            Phone_lb.Size = new Size(177, 32);
            Phone_lb.TabIndex = 3;
            Phone_lb.Text = "Phone Number";
            // 
            // Name_txt
            // 
            Name_txt.Location = new Point(341, 67);
            Name_txt.Name = "Name_txt";
            Name_txt.Size = new Size(298, 27);
            Name_txt.TabIndex = 5;
            // 
            // Surname_txt
            // 
            Surname_txt.Location = new Point(341, 129);
            Surname_txt.Name = "Surname_txt";
            Surname_txt.Size = new Size(298, 27);
            Surname_txt.TabIndex = 6;
            // 
            // Email_txt
            // 
            Email_txt.Location = new Point(341, 206);
            Email_txt.Name = "Email_txt";
            Email_txt.Size = new Size(298, 27);
            Email_txt.TabIndex = 7;
            // 
            // Phone_txt
            // 
            Phone_txt.Location = new Point(341, 289);
            Phone_txt.Name = "Phone_txt";
            Phone_txt.Size = new Size(298, 27);
            Phone_txt.TabIndex = 8;
            // 
            // salary_txt
            // 
            salary_txt.Location = new Point(341, 367);
            salary_txt.Name = "salary_txt";
            salary_txt.Size = new Size(298, 27);
            salary_txt.TabIndex = 9;
            // 
            // Salary_lb
            // 
            Salary_lb.AutoSize = true;
            Salary_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Salary_lb.Location = new Point(26, 361);
            Salary_lb.Name = "Salary_lb";
            Salary_lb.Size = new Size(77, 32);
            Salary_lb.TabIndex = 10;
            Salary_lb.Text = "Salary";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(26, 460);
            label2.Name = "label2";
            label2.Size = new Size(111, 32);
            label2.TabIndex = 11;
            label2.Text = "Password";
            // 
            // Password_txt
            // 
            Password_txt.Location = new Point(341, 460);
            Password_txt.Name = "Password_txt";
            Password_txt.Size = new Size(298, 27);
            Password_txt.TabIndex = 12;
            // 
            // Sumbit_btn
            // 
            Sumbit_btn.Cursor = Cursors.Hand;
            Sumbit_btn.Font = new Font("Segoe UI", 26F, FontStyle.Regular, GraphicsUnit.Point);
            Sumbit_btn.Location = new Point(200, 538);
            Sumbit_btn.Name = "Sumbit_btn";
            Sumbit_btn.Size = new Size(394, 167);
            Sumbit_btn.TabIndex = 13;
            Sumbit_btn.Text = "Submit";
            Sumbit_btn.UseVisualStyleBackColor = true;
            // 
            // NewEmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 747);
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