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

    public partial class ReservationForm : Form
    {
        private string connectionString = ConnectionClass.Customerconnection;

        private string email;
        public ReservationForm(string email)
        {
            InitializeComponent();
            this.email = email;
        }

        private void ReservationForm_Load(object sender, EventArgs e)
        {

        }

        private void sumbmit_BT_Click(object sender, EventArgs e)
        {
            int quantity;
            try
            {
                quantity = int.Parse(pepole_amount_txt.Text);
            } catch
            {
                   MessageBox.Show("Please enter a valid number of people");
                return;
            }
            DateTime date = DateTime.Parse(Date_date.Text + " " + Date_hours.Text);
     
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_MakeReservation", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add input parameters
                        cmd.Parameters.Add(new SqlParameter("@CustomerEmail", email));
                        cmd.Parameters.Add(new SqlParameter("@StartTime", date));
                        cmd.Parameters.Add(new SqlParameter("@NumberOfPeople", quantity));

                        // Add output parameter
                        SqlParameter outputMessageParam = new SqlParameter("@OutputMessage", SqlDbType.NVarChar, 255);
                        outputMessageParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outputMessageParam);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        // Get the output parameter value
                        string outputMessage = (string)cmd.Parameters["@OutputMessage"].Value;

                        // Print the output message
                        MessageBox.Show(outputMessage);
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show(ex.Message);
                }

            }
        }

        private void Num_pp_lb_Click(object sender, EventArgs e)
        {

        }
    }
}