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
    public partial class signupForm : Form
    {
        string connectionstring = ConnectionClass.Generelconnection;
        public signupForm()
        {
            InitializeComponent();
        }

        private void Salary_lb_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void Password_txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void salary_txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void Phone_txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void Email_txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void Surname_txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void Name_txt_TextChanged(object sender, EventArgs e)
        {
        }

        private void Phone_lb_Click(object sender, EventArgs e)
        {
        }

        private void Email_lbl_Click(object sender, EventArgs e)
        {
        }

        private void surname_lb_Click(object sender, EventArgs e)
        {
        }

        private void name_lb_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void signupForm_Load(object sender, EventArgs e)
        {
        
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = Name_txt.Text;
            string surname = Surname_txt.Text;
            string email = Email_txt.Text;
            string phone = Phone_txt.Text;
            string address = Address_txt.Text;
            string password = Password_txt.Text;
            int userType = 1; // Assuming userType is 1 for this example

            using (SqlConnection connection = new SqlConnection(connectionstring))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_CreateNewUser", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add parameters
                        cmd.Parameters.Add(new SqlParameter("@FirstName", name));
                        cmd.Parameters.Add(new SqlParameter("@LastName", surname));
                        cmd.Parameters.Add(new SqlParameter("@Email", email));
                        cmd.Parameters.Add(new SqlParameter("@PhoneNumber", phone));
                        cmd.Parameters.Add(new SqlParameter("@Address", address));
                        cmd.Parameters.Add(new SqlParameter("@Password", password));
                        cmd.Parameters.Add(new SqlParameter("@UserTypeID", userType));

                        // Execute the stored procedure and get the return value
                        int returnValue = (int)cmd.ExecuteScalar();

                        if (returnValue == 1)
                        {
                            MessageBox.Show("User created successfully.");
                            this.Close();  
                        }
                        else
                        {
                            MessageBox.Show("Failed to create user. Email might already exist.");
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
