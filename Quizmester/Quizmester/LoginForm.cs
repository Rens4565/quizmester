
using System;                    
using System.Data;                 
using System.Data.SqlClient;       
using System.Security.Cryptography; 
using System.Text;                 
using System.Windows.Forms;        


namespace Quizmester
{
   
    public partial class LoginForm : Form
    {
        
        string username = "";
        string password = "";

        
        public LoginForm()
        {
            
            InitializeComponent();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        
        public bool Login(string username, string password)
        {
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "SELECT COUNT(*) FROM [dbo].[Users] WHERE Username = @username AND Password = @password";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }
        }

       
        private void btnLogin_Click(object sender, EventArgs e)
        {
            
            username = txbUsername.Text;
            password = txbPassword.Text;

           
            if (Login(username, password))
            {
                
                MessageBox.Show("Login successful!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                
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