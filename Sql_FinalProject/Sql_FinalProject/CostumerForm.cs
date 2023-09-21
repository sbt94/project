using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Sql_FinalProject
{
    public partial class CostumerForm : Form
    {
        private string email;
        private string connectionString;
        public CostumerForm(string email)
        {
            InitializeComponent();
            this.email = email;
            connectionString = ConnectionClass.Customerconnection;

        }

        private void CostumerForm_Load(object sender, EventArgs e)
        {

        }

        private void makeReservation_Click(object sender, EventArgs e)
        {
            new ReservationForm(email).Show();
            Order_food_bt.Visible = true;
            makeReservation.Visible = false;
        }

        private void Order_food_bt_Click(object sender, EventArgs e)
        {
            new Order(email).Show();//create new order form that will hold all of the dishes that the user will order 
        }

        private void ShowReservation_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_GetReservationsByEmail", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add input parameter for email
                        cmd.Parameters.Add(new SqlParameter("@Email", email));

                        // Use SqlDataAdapter to fetch the data
                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);

                        // Fill a DataTable with the results
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        Grid_reservetions.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
