namespace Sql_FinalProject
{
    partial class DishForm
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
            Add_To_order_bt = new Button();
            Grid_dishes = new DataGridView();
            label1 = new Label();
            Quantity_txt = new TextBox();
            ((System.ComponentModel.ISupportInitialize)Grid_dishes).BeginInit();
            SuspendLayout();
            // 
            // Add_To_order_bt
            // 
            Add_To_order_bt.Font = new Font("Segoe UI", 19F, FontStyle.Regular, GraphicsUnit.Point);
            Add_To_order_bt.Location = new Point(227, 518);
            Add_To_order_bt.Name = "Add_To_order_bt";
            Add_To_order_bt.Size = new Size(298, 100);
            Add_To_order_bt.TabIndex = 0;
            Add_To_order_bt.Text = "Add to the order";
            Add_To_order_bt.UseVisualStyleBackColor = true;
            // 
            // Grid_dishes
            // 
            Grid_dishes.AllowUserToOrderColumns = true;
            Grid_dishes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Grid_dishes.Location = new Point(107, 27);
            Grid_dishes.Name = "Grid_dishes";
            Grid_dishes.RowHeadersWidth = 51;
            Grid_dishes.RowTemplate.Height = 29;
            Grid_dishes.Size = new Size(601, 337);
            Grid_dishes.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(166, 421);
            label1.Name = "label1";
            label1.Size = new Size(114, 35);
            label1.TabIndex = 2;
            label1.Text = "Quantity:";
            // 
            // Quantity_txt
            // 
            Quantity_txt.Location = new Point(383, 430);
            Quantity_txt.Name = "Quantity_txt";
            Quantity_txt.Size = new Size(205, 27);
            Quantity_txt.TabIndex = 3;
            // 
            // DishForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 640);
            Controls.Add(Quantity_txt);
            Controls.Add(label1);
            Controls.Add(Grid_dishes);
            Controls.Add(Add_To_order_bt);
            Name = "DishForm";
            Text = "DishForm";
            ((System.ComponentModel.ISupportInitialize)Grid_dishes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button Add_To_order_bt;
        private DataGridView Grid_dishes;
        private Label label1;
        private TextBox Quantity_txt;
    }
}