namespace Sql_FinalProject
{
    partial class EmployyeOrMennagerForm
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
            Show_all_bt = new Button();
            Reservation_by_email_bt = new Button();
            label1 = new Label();
            Email_txt = new TextBox();
            monthCalendar1 = new MonthCalendar();
            dataGridView1 = new DataGridView();
            button1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Show_all_bt
            // 
            Show_all_bt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Show_all_bt.Location = new Point(506, 325);
            Show_all_bt.Name = "Show_all_bt";
            Show_all_bt.Size = new Size(283, 103);
            Show_all_bt.TabIndex = 0;
            Show_all_bt.Text = "Show all future reservations";
            Show_all_bt.UseVisualStyleBackColor = true;
            Show_all_bt.Click += Show_all_bt_Click;
            // 
            // Reservation_by_email_bt
            // 
            Reservation_by_email_bt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Reservation_by_email_bt.Location = new Point(10, 325);
            Reservation_by_email_bt.Name = "Reservation_by_email_bt";
            Reservation_by_email_bt.Size = new Size(283, 103);
            Reservation_by_email_bt.TabIndex = 1;
            Reservation_by_email_bt.Text = "Show Costumer reservations";
            Reservation_by_email_bt.UseVisualStyleBackColor = true;
            Reservation_by_email_bt.Click += Reservation_by_email_bt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(66, 41);
            label1.Name = "label1";
            label1.Size = new Size(91, 15);
            label1.TabIndex = 2;
            label1.Text = "Costumer Email";
            // 
            // Email_txt
            // 
            Email_txt.Location = new Point(66, 81);
            Email_txt.Name = "Email_txt";
            Email_txt.Size = new Size(185, 23);
            Email_txt.TabIndex = 3;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(66, 132);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(329, 16);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(460, 287);
            dataGridView1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Cursor = Cursors.No;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(299, 325);
            button1.Name = "button1";
            button1.Size = new Size(201, 103);
            button1.TabIndex = 6;
            button1.Text = "register new Employee";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // EmployyeOrMennagerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(monthCalendar1);
            Controls.Add(Email_txt);
            Controls.Add(label1);
            Controls.Add(Reservation_by_email_bt);
            Controls.Add(Show_all_bt);
            Name = "EmployyeOrMennagerForm";
            Text = "EmployyeOrMennagerForm";
            Load += EmployyeOrMennagerForm_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Show_all_bt;
        private Button Reservation_by_email_bt;
        private Label label1;
        private TextBox Email_txt;
        private MonthCalendar monthCalendar1;
        private DataGridView dataGridView1;
        private Button button1;
    }
}