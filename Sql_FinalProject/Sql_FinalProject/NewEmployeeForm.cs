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
    public partial class NewEmployeeForm : Form
    {
        string connectionString = ConnectionClass.Managerconnection;
        public NewEmployeeForm()
        {
            InitializeComponent();
        }

        private void Sumbit_btn_Click(object sender, EventArgs e)
        {
            int outPutVariable = 0;
            string name = Name_txt.Text;
            string surname = Surname_txt.Text;
            string email = Email_txt.Text;
            string phone = Phone_txt.Text;
            string salary = salary_txt.Text;
            DateTime dateTime = DateTime.Now;
            string password = Password_txt.Text;
            int userType =2; // Assuming userType is 1 for this example
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_CreateNewEmployee", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.Add(new SqlParameter("@FirstName", name));
                        cmd.Parameters.Add(new SqlParameter("@LastName", surname));
                        cmd.Parameters.Add(new SqlParameter("@Email", email));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", phone));
                        cmd.Parameters.Add(new SqlParameter("@Address", salary));
                        cmd.Parameters.Add(new SqlParameter("@Password", password));
                        cmd.Parameters.Add(new SqlParameter("@HireDate", dateTime));
                        cmd.Parameters.Add(new SqlParameter("@UserTypeID", userType));

                        // Add output parameter for NewOrderID
                        SqlParameter outvar = new SqlParameter("@outvar", SqlDbType.Int);
                        outvar.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(outvar);



                        cmd.ExecuteNonQuery();

                        if (outvar.Value != DBNull.Value)
                        {
                            outPutVariable = Convert.ToInt32(outvar.Value);
                            if (outPutVariable == 1)
                            {
                                MessageBox.Show("Employee created successfully.");
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Failed to create Employee. Employee might already exist.");
                            }

                        }
                        else
                        {
                            MessageBox.Show("Failed to create user. Employee might already exist.");
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
    }
}
