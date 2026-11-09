using System;
using System.Data;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;


namespace Quizmester
{
    // Displays the login screen and checks credentials against the database.
    public partial class LoginForm : Form
    {

        string username = "";
        string password = "";


        public LoginForm()
        {
            // Creates the controls defined in LoginForm.Designer.cs.
            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }


        public bool Login(string username, string password)
        {
            // Reset the role before checking the new login attempt.
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            Program.IsAdmin = false;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Retrieve the role only when both the username and password match.
                string query = "SELECT Role FROM [dbo].[Users] WHERE Username = @username AND Password = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        return false;
                    }

                    // Store whether this user can open the administration form.
                    if (result.ToString().Trim().ToLower() == "admin")
                    {
                        Program.IsAdmin = true;
                    }

                    return true;
                }
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {
            // Read the credentials entered by the user.
            username = txbUsername.Text;
            password = txbPassword.Text;


            if (Login(username, password))
            {
                // A successful login opens the quiz and hides the login screen.
                MessageBox.Show("Login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Program.CurrentUser = username;
                quizForm quizForm = new quizForm();
                quizForm.Show();
                this.Hide();

            }
            else
            {

                MessageBox.Show("Incorrect username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}