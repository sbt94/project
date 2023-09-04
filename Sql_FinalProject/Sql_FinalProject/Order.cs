using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace Sql_FinalProject
{
    public partial class Order : Form
    {
        private string connectionString = ConnectionClass.Customerconnection;
        private int orderID;
        private string email;
        private Timer timer;
        public Order(string email)
        {
            InitializeComponent();
            Total_Amount_lb.Text = "0";
            this.email = email;

            // Initialize Timer
            timer = new Timer();
            timer.Interval = 1000; // 1 second
            timer.Tick += Timer_Tick;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_CreateNewOrder", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for email
                        cmd.Parameters.Add(new SqlParameter("@Email", email));

                        // Add output parameter for NewOrderID
                        SqlParameter newOrderIDParam = new SqlParameter("@NewOrderID", SqlDbType.Int);
                        newOrderIDParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(newOrderIDParam);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        // Get the output parameter value
                        if (newOrderIDParam.Value != DBNull.Value)
                        {
                            this.orderID = Convert.ToInt32(newOrderIDParam.Value);
                        }
                        else
                        {
                            // Handle the case where the order ID is not returned
                            MessageBox.Show("Could not create a new order.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show(ex.Message);
                }
            }
        }



        private void Order_Load(object sender, EventArgs e)
        {

        }

        private void Add_bt_Click(object sender, EventArgs e)
        {

        }

        
        private void Timer_Tick(object sender, EventArgs e)
        {
            // Check if DishForm is closed
            // You can implement this check based on your application's logic

            // Once confirmed that DishForm is closed
            timer.Stop(); // Stop the timer

            // Call the stored procedures to update the UI
            UpdateTotalAmount();
            LoadOrderDetailsIntoGrid();
        }
        private void UpdateTotalAmount()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetTotalPriceByOrderID", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@OrderID", orderID));

                        SqlParameter totalPriceParam = new SqlParameter("@TotalPrice", SqlDbType.Float);
                        totalPriceParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(totalPriceParam);

                        cmd.ExecuteNonQuery();

                        if (totalPriceParam.Value != DBNull.Value)
                        {
                            Total_Amount_lb.Text = totalPriceParam.Value.ToString();
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void LoadOrderDetailsIntoGrid()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand("sp_GetOrderDetails", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add(new SqlParameter("@OrderID", orderID));

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Add_item_bt_Click(object sender, EventArgs e)
        {
            DishForm dishForm = new DishForm(orderID);
            dishForm.ShowDialog();
            timer.Start(); // Start the timer to check if DishForm is closed
        }

    }


}



