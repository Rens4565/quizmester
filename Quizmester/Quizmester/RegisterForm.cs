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

                // Step 1: Check if the username already exists
                string checkQuery = "SELECT COUNT(*) FROM Users WHERE Username = @username";
                SqlCommand checkCmd = new SqlCommand(checkQuery, conn);
                checkCmd.Parameters.AddWithValue("@username", username);

                int existingCount = (int)checkCmd.ExecuteScalar();

                if (existingCount > 0)
                {
                    MessageBox.Show("username already taken try again with a different username");
                    return false;
                }

                // Step 2: Hash the password before storing it
                byte[] hashedPassword = CalculateSHA256(password);

                // Step 3: Insert the new user (no UserId — IDENTITY handles that now)
                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@username, @password)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, conn);

                insertCmd.Parameters.AddWithValue("@username", username);
                insertCmd.Parameters.AddWithValue("@password", hashedPassword);

                int rowsAffected = insertCmd.ExecuteNonQuery();
                return rowsAffected > 0;
               


            }

            
        }

        private byte[] CalculateSHA256(string password)
        {
            SHA256 sha256 = SHA256Managed.Create();
            byte[] hashValue;
            UTF8Encoding objUtf8 = new UTF8Encoding();
            hashValue = sha256.ComputeHash(objUtf8.GetBytes(password));

            return hashValue;
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
    }
}

