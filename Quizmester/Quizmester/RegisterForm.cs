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
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);
                int existingCount = (int)checkCmd.ExecuteScalar();
                if (existingCount > 0)
                {
                    MessageBox.Show("username already taken try again with a different username");
                    return false;
                }

                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@username, @password)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);
                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", password);
                int rowsAffected = insertCmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

       
       
        private void GotoQuiz()
        {
            quizForm quizForm = new quizForm();
            if (IsUserRegistered == true)
            {
                quizForm.Show();
            }


        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            username = txbNewUsername.Text;
            Password = txbNewPassword.Text;
            bool success = RegisterUser(username, Password);
            if (success == true)
            {
                IsUserRegistered =true;
                GotoQuiz();
            }
        }

        private void btnGoToLogin_Click(object sender, EventArgs e)
        {
            LoginForm Form1 = new LoginForm();

           
            Form1.Show();
            this.Hide();

        }
    }
}

