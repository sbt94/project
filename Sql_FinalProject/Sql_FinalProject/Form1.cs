using System.Data;
using System.Data.SqlClient;

namespace Sql_FinalProject
{
    public partial class Form1 : Form
    {
        private string connectionString;

        public Form1()
        {
            InitializeComponent();
            //Data Source=DESKTOP-TQ2RPAH;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False
            connectionString = ConnectionClass.Generelconnection;
        }

        private void label1_Click(object sender, EventArgs e)
        {


        }

        private void button2_Click(object sender, EventArgs e)
        {
            new signupForm().Show();
        }

        private void login_bt_Click(object sender, EventArgs e)
        {
            var email = Email_txt.Text;
            var password = Pass_txt.Text; // Note: You should handle passwords securely, this is just for demonstration

            // Connection string. Replace with your actual connection string

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    // Open the connection
                    connection.Open();

                    // Create a command for the stored procedure
                    using (SqlCommand cmd = new SqlCommand("sp_GetUserTypeByEmail", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // Add input parameter
                        cmd.Parameters.Add(new SqlParameter("@Email", email));
                        cmd.Parameters.Add(new SqlParameter("@Password", password));

                        // Add output parameter
                        SqlParameter userTypeParam = new SqlParameter("@UserType", SqlDbType.NVarChar, 50);
                        userTypeParam.Direction = ParameterDirection.Output;
                        cmd.Parameters.Add(userTypeParam);

                        // Execute the stored procedure
                        cmd.ExecuteNonQuery();

                        // Get the output parameter value
                        string userType = (string)cmd.Parameters["@UserType"].Value;

                        if (userType == "Not Found")
                        {
                            // User type found, proceed with your logic
                            MessageBox.Show($"one or more of the parameters ar wrong");
                            Email_txt.Text = "";
                            Pass_txt.Text = "";
                        }
                        else if (userType == "Manager" || userType == "Employee")
                        {
                            new EmployyeOrMennagerForm(userType).Show();
                            // User type found, proceed with your logic
                            MessageBox.Show($"User type is: {userType}");
                        }
                        else if (userType == "Customer")
                        {
                            new CostumerForm(email).Show();
                            // User type found, proceed with your logic
                            MessageBox.Show($"User type is: {userType}");

                        }
                        else
                        {
                            // User type not found, handle accordingly
                            MessageBox.Show("User not found.");
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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Pass_txt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}