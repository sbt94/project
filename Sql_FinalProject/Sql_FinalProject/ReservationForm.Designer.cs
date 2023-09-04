namespace Sql_FinalProject
{
    partial class ReservationForm
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
            sumbmit_BT = new Button();
            Date_hours = new DateTimePicker();
            Date_date = new DateTimePicker();
            date_lbl = new Label();
            Hout_lb = new Label();
            Num_pp_lb = new Label();
            pepole_amount_txt = new TextBox();
            SuspendLayout();
            // 
            // sumbmit_BT
            // 
            sumbmit_BT.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            sumbmit_BT.Location = new Point(214, 212);
            sumbmit_BT.Margin = new Padding(3, 2, 3, 2);
            sumbmit_BT.Name = "sumbmit_BT";
            sumbmit_BT.Size = new Size(271, 91);
            sumbmit_BT.TabIndex = 0;
            sumbmit_BT.Text = "Submit Order";
            sumbmit_BT.UseVisualStyleBackColor = true;
            sumbmit_BT.Click += sumbmit_BT_Click;
            // 
            // Date_hours
            // 
            Date_hours.Format = DateTimePickerFormat.Time;
            Date_hours.Location = new Point(446, 67);
            Date_hours.Margin = new Padding(3, 2, 3, 2);
            Date_hours.Name = "Date_hours";
            Date_hours.Size = new Size(238, 23);
            Date_hours.TabIndex = 1;
            // 
            // Date_date
            // 
            Date_date.Location = new Point(446, 28);
            Date_date.Margin = new Padding(3, 2, 3, 2);
            Date_date.Name = "Date_date";
            Date_date.Size = new Size(238, 23);
            Date_date.TabIndex = 2;
            // 
            // date_lbl
            // 
            date_lbl.AutoSize = true;
            date_lbl.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            date_lbl.Location = new Point(164, 33);
            date_lbl.Name = "date_lbl";
            date_lbl.Size = new Size(93, 21);
            date_lbl.TabIndex = 3;
            date_lbl.Text = "choose date";
            // 
            // Hout_lb
            // 
            Hout_lb.AutoSize = true;
            Hout_lb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Hout_lb.Location = new Point(164, 72);
            Hout_lb.Name = "Hout_lb";
            Hout_lb.Size = new Size(101, 21);
            Hout_lb.TabIndex = 4;
            Hout_lb.Text = "Choose Hour";
            // 
            // Num_pp_lb
            // 
            Num_pp_lb.AutoSize = true;
            Num_pp_lb.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            Num_pp_lb.Location = new Point(164, 131);
            Num_pp_lb.Name = "Num_pp_lb";
            Num_pp_lb.Size = new Size(140, 21);
            Num_pp_lb.TabIndex = 5;
            Num_pp_lb.Text = "how may peapoles";
            // 
            // pepole_amount_txt
            // 
            pepole_amount_txt.Location = new Point(443, 134);
            pepole_amount_txt.Margin = new Padding(3, 2, 3, 2);
            pepole_amount_txt.Name = "pepole_amount_txt";
            pepole_amount_txt.Size = new Size(242, 23);
            pepole_amount_txt.TabIndex = 6;
            // 
            // ReservationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(pepole_amount_txt);
            Controls.Add(Num_pp_lb);
            Controls.Add(Hout_lb);
            Controls.Add(date_lbl);
            Controls.Add(Date_date);
            Controls.Add(Date_hours);
            Controls.Add(sumbmit_BT);
            Margin = new Padding(3, 2, 3, 2);
            Name = "ReservationForm";
            Text = "ReservationForm";
            Load += ReservationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button sumbmit_BT;
        private DateTimePicker Date_hours;
        private DateTimePicker Date_date;
        private Label date_lbl;
        private Label Hout_lb;
        private Label Num_pp_lb;
        private TextBox pepole_amount_txt;
    }
}