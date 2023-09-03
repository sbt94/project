namespace Sql_FinalProject
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            login_bt = new Button();
            Sign_bt = new Button();
            Email_lb = new Label();
            Pass_lb = new Label();
            Enail_txt = new TextBox();
            Pass_txt = new TextBox();
            SuspendLayout();
            // 
            // login_bt
            // 
            login_bt.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            login_bt.Location = new Point(242, 246);
            login_bt.Name = "login_bt";
            login_bt.Size = new Size(187, 64);
            login_bt.TabIndex = 0;
            login_bt.Text = "log in";
            login_bt.UseVisualStyleBackColor = true;
            // 
            // Sign_bt
            // 
            Sign_bt.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Sign_bt.Location = new Point(504, 246);
            Sign_bt.Name = "Sign_bt";
            Sign_bt.Size = new Size(187, 64);
            Sign_bt.TabIndex = 1;
            Sign_bt.Text = "Sign up";
            Sign_bt.UseVisualStyleBackColor = true;
            Sign_bt.Click += button2_Click;
            // 
            // Email_lb
            // 
            Email_lb.AutoSize = true;
            Email_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Email_lb.Location = new Point(242, 73);
            Email_lb.Name = "Email_lb";
            Email_lb.Size = new Size(71, 32);
            Email_lb.TabIndex = 2;
            Email_lb.Text = "Email";
            Email_lb.Click += label1_Click;
            // 
            // Pass_lb
            // 
            Pass_lb.AutoSize = true;
            Pass_lb.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            Pass_lb.Location = new Point(242, 159);
            Pass_lb.Name = "Pass_lb";
            Pass_lb.Size = new Size(113, 32);
            Pass_lb.TabIndex = 3;
            Pass_lb.Text = "password";
            // 
            // Enail_txt
            // 
            Enail_txt.Location = new Point(449, 79);
            Enail_txt.Name = "Enail_txt";
            Enail_txt.Size = new Size(125, 27);
            Enail_txt.TabIndex = 4;
            // 
            // Pass_txt
            // 
            Pass_txt.Location = new Point(449, 164);
            Pass_txt.Name = "Pass_txt";
            Pass_txt.Size = new Size(125, 27);
            Pass_txt.TabIndex = 5;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1109, 533);
            Controls.Add(Pass_txt);
            Controls.Add(Enail_txt);
            Controls.Add(Pass_lb);
            Controls.Add(Email_lb);
            Controls.Add(Sign_bt);
            Controls.Add(login_bt);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login_bt;
        private Button Sign_bt;
        private Label Email_lb;
        private Label Pass_lb;
        private TextBox Enail_txt;
        private TextBox Pass_txt;
    }
}