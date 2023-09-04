using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Sql_FinalProject
{
    public partial class DishForm : Form
    {
        string connectionString = ConnectionClass.Customerconnection;
        public int SelectedDishID { get; private set; } // To store the selected MenuItemID
        public int orderID { get; set; } // Assuming you have orderID as a property or variable


        public DishForm(int orderID)
        {
            InitializeComponent();
            this.orderID = orderID;
            Grid_dishes.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Set selection mode to full row select
            Grid_dishes.SelectionChanged += Grid_dishes_SelectionChanged; // Subscribe to the SelectionChanged event


            LoadDishesIntoGrid();
        }

        private void LoadDishesIntoGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetAllMenuItems", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        Grid_dishes.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Grid_dishes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = Grid_dishes.Rows[e.RowIndex];
                SelectedDishID = Convert.ToInt32(row.Cells["MenuItemID"].Value); // Assuming the column name in the grid is "MenuItemID"
            }
        }


        private void DishForm_Load(object sender, EventArgs e)
        {
            // You can add additional code here if needed
        }

        private void Add_To_order_bt_Click(object sender, EventArgs e)
        {
            Grid_dishes.CellClick += new DataGridViewCellEventHandler(Grid_dishes_CellClick);

            int quantity = int.Parse(Quantity_txt.Text); // Assuming you have a TextBox named Quantity_txt

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_InsertOrderProduct", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.Add(new SqlParameter("@OrderID", orderID));
                        cmd.Parameters.Add(new SqlParameter("@MenuItemID", SelectedDishID));
                        cmd.Parameters.Add(new SqlParameter("@Quantity", quantity));

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Order Product inserted successfully.");
                        this.Close();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
        private void Grid_dishes_SelectionChanged(object sender, EventArgs e)
        {
            if (Grid_dishes.SelectedRows.Count > 0)
            {
                DataGridViewRow row = Grid_dishes.SelectedRows[0];
                SelectedDishID = Convert.ToInt32(row.Cells["MenuItemID"].Value); // Assuming the column name in the grid is "MenuItemID"
            }
        }

    }

}
