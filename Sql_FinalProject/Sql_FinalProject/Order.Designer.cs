namespace Sql_FinalProject
{
    partial class Order
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
            dataGridView1 = new DataGridView();
            label1 = new Label();
            Total_Amount_lb = new Label();
            Add_item_bt = new Button();
            check = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(268, 20);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(422, 224);
            dataGridView1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(52, 278);
            label1.Name = "label1";
            label1.Size = new Size(118, 30);
            label1.TabIndex = 1;
            label1.Text = "Total price:";
            // 
            // Total_Amount_lb
            // 
            Total_Amount_lb.AutoSize = true;
            Total_Amount_lb.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Total_Amount_lb.Location = new Point(184, 278);
            Total_Amount_lb.Name = "Total_Amount_lb";
            Total_Amount_lb.Size = new Size(71, 30);
            Total_Amount_lb.TabIndex = 2;
            Total_Amount_lb.Text = "label2";
            // 
            // Add_item_bt
            // 
            Add_item_bt.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            Add_item_bt.Location = new Point(23, 34);
            Add_item_bt.Margin = new Padding(3, 2, 3, 2);
            Add_item_bt.Name = "Add_item_bt";
            Add_item_bt.Size = new Size(206, 62);
            Add_item_bt.TabIndex = 3;
            Add_item_bt.Text = "Order new dish";
            Add_item_bt.UseVisualStyleBackColor = true;
            Add_item_bt.Click += Add_item_bt_Click;
            // 
            // check
            // 
            check.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point);
            check.Location = new Point(346, 254);
            check.Margin = new Padding(3, 2, 3, 2);
            check.Name = "check";
            check.Size = new Size(293, 67);
            check.TabIndex = 4;
            check.Text = "Check";
            check.UseVisualStyleBackColor = true;
            check.Click += Add_bt_Click;
            // 
            // Order
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(700, 338);
            Controls.Add(check);
            Controls.Add(Add_item_bt);
            Controls.Add(Total_Amount_lb);
            Controls.Add(label1);
            Controls.Add(dataGridView1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Order";
            Text = "Order";
            Load += Order_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dataGridView1;
        private Label label1;
        private Label Total_Amount_lb;
        private Button Add_item_bt;
        private Button check;
    }
}