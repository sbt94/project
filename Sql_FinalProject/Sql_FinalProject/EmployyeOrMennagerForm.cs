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
    public partial class EmployyeOrMennagerForm : Form
    {
        string ConnectionString;
        public EmployyeOrMennagerForm(string role)
        {
            InitializeComponent();
            if (role == "Employee")
            {
                ConnectionString = ConnectionClass.Employeeconnection;
                button1.Enabled = false;
            }
            else
            {
                ConnectionString = ConnectionClass.Managerconnection;
                button1.Enabled = true;
                button1.Visible = true;
            }
        }

        private void EmployyeOrMennagerForm_Load(object sender, EventArgs e)
        {
        }

        private void Show_all_bt_Click(object sender, EventArgs e)
        {
            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_GetUpcomingReservations", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Execute the stored procedure and get the results in a DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void Reservation_by_email_bt_Click(object sender, EventArgs e)
        {
            string email = Email_txt.Text;

            using (SqlConnection connection = new SqlConnection(ConnectionString))
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

                        // Execute the stored procedure and get the results in a DataTable
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        // Bind the DataTable to the DataGridView
                        dataGridView1.DataSource = dt;
                    }
                }
                catch (Exception ex)
                {
                    // Handle any errors that may have occurred
                    MessageBox.Show(ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            new NewEmployeeForm().ShowDialog();

        }
    }
}
