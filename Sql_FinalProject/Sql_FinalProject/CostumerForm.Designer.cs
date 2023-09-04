namespace Sql_FinalProject
{
    partial class CostumerForm
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
            makeReservation = new Button();
            ShowReservation = new Button();
            Hellow_lb = new Label();
            Grid_reservetions = new DataGridView();
            Order_food_bt = new Button();
            ((System.ComponentModel.ISupportInitialize)Grid_reservetions).BeginInit();
            SuspendLayout();
            // 
            // makeReservation
            // 
            makeReservation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            makeReservation.Location = new Point(40, 85);
            makeReservation.Margin = new Padding(3, 2, 3, 2);
            makeReservation.Name = "makeReservation";
            makeReservation.Size = new Size(246, 62);
            makeReservation.TabIndex = 0;
            makeReservation.Text = "Make new reservation";
            makeReservation.UseVisualStyleBackColor = true;
            makeReservation.Click += makeReservation_Click;
            // 
            // ShowReservation
            // 
            ShowReservation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ShowReservation.Location = new Point(46, 266);
            ShowReservation.Margin = new Padding(3, 2, 3, 2);
            ShowReservation.Name = "ShowReservation";
            ShowReservation.Size = new Size(246, 62);
            ShowReservation.TabIndex = 1;
            ShowReservation.Text = "show reservation";
            ShowReservation.UseVisualStyleBackColor = true;
            ShowReservation.Click += ShowReservation_Click;
            // 
            // Hellow_lb
            // 
            Hellow_lb.AutoSize = true;
            Hellow_lb.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Hellow_lb.Location = new Point(212, 35);
            Hellow_lb.Name = "Hellow_lb";
            Hellow_lb.Size = new Size(272, 37);
            Hellow_lb.TabIndex = 3;
            Hellow_lb.Text = "hellow dear costumer";
            // 
            // Grid_reservetions
            // 
            Grid_reservetions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_reservetions.Location = new Point(389, 106);
            Grid_reservetions.Margin = new Padding(3, 2, 3, 2);
            Grid_reservetions.Name = "Grid_reservetions";
            Grid_reservetions.RowHeadersWidth = 51;
            Grid_reservetions.Size = new Size(262, 210);
            Grid_reservetions.TabIndex = 4;
            // 
            // Order_food_bt
            // 
            Order_food_bt.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            Order_food_bt.Location = new Point(41, 161);
            Order_food_bt.Margin = new Padding(3, 2, 3, 2);
            Order_food_bt.Name = "Order_food_bt";
            Order_food_bt.Size = new Size(250, 88);
            Order_food_bt.TabIndex = 5;
            Order_food_bt.Text = "Order Food";
            Order_food_bt.UseVisualStyleBackColor = true;
            Order_food_bt.Click += Order_food_bt_Click;
            // 
            // CostumerForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(Order_food_bt);
            Controls.Add(Grid_reservetions);
            Controls.Add(Hellow_lb);
            Controls.Add(ShowReservation);
            Controls.Add(makeReservation);
            Margin = new Padding(3, 2, 3, 2);
            Name = "CostumerForm";
            Text = "CostumerForm";
            Load += CostumerForm_Load;
            ((System.ComponentModel.ISupportInitialize)Grid_reservetions).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button makeReservation;
        private Button ShowReservation;
        private Label Hellow_lb;
        private DataGridView Grid_reservetions;
        private Button Order_food_bt;
    }
}