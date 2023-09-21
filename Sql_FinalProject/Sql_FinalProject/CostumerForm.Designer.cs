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
            makeReservation.Location = new Point(46, 113);
            makeReservation.Name = "makeReservation";
            makeReservation.Size = new Size(281, 83);
            makeReservation.TabIndex = 0;
            makeReservation.Text = "Make new reservation";
            makeReservation.UseVisualStyleBackColor = true;
            makeReservation.Click += makeReservation_Click;
            // 
            // ShowReservation
            // 
            ShowReservation.Font = new Font("Segoe UI", 14F, FontStyle.Regular, GraphicsUnit.Point);
            ShowReservation.Location = new Point(53, 355);
            ShowReservation.Name = "ShowReservation";
            ShowReservation.Size = new Size(281, 83);
            ShowReservation.TabIndex = 1;
            ShowReservation.Text = "show reservation";
            ShowReservation.UseVisualStyleBackColor = true;
            ShowReservation.Click += ShowReservation_Click;
            // 
            // Hellow_lb
            // 
            Hellow_lb.AutoSize = true;
            Hellow_lb.Font = new Font("Segoe UI", 20F, FontStyle.Regular, GraphicsUnit.Point);
            Hellow_lb.Location = new Point(242, 47);
            Hellow_lb.Name = "Hellow_lb";
            Hellow_lb.Size = new Size(343, 46);
            Hellow_lb.TabIndex = 3;
            Hellow_lb.Text = "hellow dear costumer";
            // 
            // Grid_reservetions
            // 
            Grid_reservetions.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_reservetions.Location = new Point(445, 141);
            Grid_reservetions.Name = "Grid_reservetions";
            Grid_reservetions.RowHeadersWidth = 51;
            Grid_reservetions.Size = new Size(299, 280);
            Grid_reservetions.TabIndex = 4;
            // 
            // Order_food_bt
            // 
            Order_food_bt.Font = new Font("Segoe UI", 17F, FontStyle.Regular, GraphicsUnit.Point);
            Order_food_bt.Location = new Point(47, 215);
            Order_food_bt.Name = "Order_food_bt";
            Order_food_bt.Size = new Size(286, 117);
            Order_food_bt.TabIndex = 5;
            Order_food_bt.Text = "Order Food";
            Order_food_bt.UseVisualStyleBackColor = true;
            Order_food_bt.Visible = false;
            Order_food_bt.Click += Order_food_bt_Click;
            // 
            // CostumerForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 451);
            Controls.Add(Order_food_bt);
            Controls.Add(Grid_reservetions);
            Controls.Add(Hellow_lb);
            Controls.Add(ShowReservation);
            Controls.Add(makeReservation);
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