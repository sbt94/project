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
            backup_bt = new Button();
            restore_bt = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // Show_all_bt
            // 
            Show_all_bt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Show_all_bt.Location = new Point(578, 433);
            Show_all_bt.Margin = new Padding(3, 4, 3, 4);
            Show_all_bt.Name = "Show_all_bt";
            Show_all_bt.Size = new Size(323, 137);
            Show_all_bt.TabIndex = 0;
            Show_all_bt.Text = "Show all future reservations";
            Show_all_bt.UseVisualStyleBackColor = true;
            Show_all_bt.Click += Show_all_bt_Click;
            // 
            // Reservation_by_email_bt
            // 
            Reservation_by_email_bt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            Reservation_by_email_bt.Location = new Point(11, 433);
            Reservation_by_email_bt.Margin = new Padding(3, 4, 3, 4);
            Reservation_by_email_bt.Name = "Reservation_by_email_bt";
            Reservation_by_email_bt.Size = new Size(323, 137);
            Reservation_by_email_bt.TabIndex = 1;
            Reservation_by_email_bt.Text = "Show Costumer reservations";
            Reservation_by_email_bt.UseVisualStyleBackColor = true;
            Reservation_by_email_bt.Click += Reservation_by_email_bt_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(75, 55);
            label1.Name = "label1";
            label1.Size = new Size(113, 20);
            label1.TabIndex = 2;
            label1.Text = "Costumer Email";
            // 
            // Email_txt
            // 
            Email_txt.Location = new Point(75, 108);
            Email_txt.Margin = new Padding(3, 4, 3, 4);
            Email_txt.Name = "Email_txt";
            Email_txt.Size = new Size(211, 27);
            Email_txt.TabIndex = 3;
            // 
            // monthCalendar1
            // 
            monthCalendar1.Location = new Point(75, 176);
            monthCalendar1.Margin = new Padding(10, 12, 10, 12);
            monthCalendar1.Name = "monthCalendar1";
            monthCalendar1.TabIndex = 4;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(376, 21);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(526, 383);
            dataGridView1.TabIndex = 5;
            // 
            // button1
            // 
            button1.Cursor = Cursors.No;
            button1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(342, 433);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(230, 137);
            button1.TabIndex = 6;
            button1.Text = "register new Employee";
            button1.UseVisualStyleBackColor = true;
            button1.Visible = false;
            button1.Click += button1_Click;
            // 
            // backup_bt
            // 
            backup_bt.Cursor = Cursors.No;
            backup_bt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            backup_bt.Location = new Point(29, 601);
            backup_bt.Margin = new Padding(3, 4, 3, 4);
            backup_bt.Name = "backup_bt";
            backup_bt.Size = new Size(230, 137);
            backup_bt.TabIndex = 7;
            backup_bt.Text = "backup";
            backup_bt.UseVisualStyleBackColor = true;
            backup_bt.Visible = false;
            backup_bt.Click += button2_Click;
            // 
            // restore_bt
            // 
            restore_bt.Cursor = Cursors.No;
            restore_bt.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            restore_bt.Location = new Point(286, 601);
            restore_bt.Margin = new Padding(3, 4, 3, 4);
            restore_bt.Name = "restore_bt";
            restore_bt.Size = new Size(230, 137);
            restore_bt.TabIndex = 8;
            restore_bt.Text = "restore";
            restore_bt.UseVisualStyleBackColor = true;
            restore_bt.Visible = false;
            // 
            // EmployyeOrMennagerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(914, 768);
            Controls.Add(restore_bt);
            Controls.Add(backup_bt);
            Controls.Add(button1);
            Controls.Add(dataGridView1);
            Controls.Add(monthCalendar1);
            Controls.Add(Email_txt);
            Controls.Add(label1);
            Controls.Add(Reservation_by_email_bt);
            Controls.Add(Show_all_bt);
            Margin = new Padding(3, 4, 3, 4);
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
        private Button backup_bt;
        private Button restore_bt;
    }
}