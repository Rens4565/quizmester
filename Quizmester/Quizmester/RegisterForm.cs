using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net.Configuration;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;

namespace Quizmester
{
    // Displays the registration screen and creates new user accounts.
    public partial class RegisterForm : Form
    {

        string username = "";
        string Password = "";
        bool IsUserRegistered = false;
        public RegisterForm()
        {
            
            InitializeComponent();
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }


        public bool RegisterUser(string username, string password)
        {
            // Open a database connection so the username can be checked and inserted.
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Prevent two accounts from using the same username.
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                int existingCount = (int)checkCmd.ExecuteScalar();
                if (existingCount > 0)
                {
                    MessageBox.Show("username already taken try again with a different username");
                    return false;
                }

                // New registrations always start with the regular user role.
                string insertQuery = "INSERT INTO Users (Username, Password, Role) VALUES (@username, @password, 'user')";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password);
                int rowsAffected = insertCmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

       
       
        private void GotoQuiz()
        {
            // Open the quiz form after a successful registration.
            quizForm quizForm = new quizForm();
            if (IsUserRegistered == true)
            {
                quizForm.Show();
            }


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            // Read the values entered in the registration controls.
            username = txbNewUsername.Text;
            Password = txbNewPassword.Text;
            bool success = RegisterUser(username, Password);
            if (success == true)
            {
                // Store the logged-in username for the other forms to use.
                Program.CurrentUser = username;
                IsUserRegistered =true;
                GotoQuiz();
            }
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            // Users who already have an account can switch to the login form.
            LoginForm Form1 = new LoginForm();

           
            Form1.Show();
            this.Hide();

        }
    }
}

