using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quizmester
{
    // Allows administrators to manage users and quiz questions.
    public partial class AdminForm : Form
    {
        string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

        public AdminForm()
        {
            // Creates the controls and loads the current database contents.
            InitializeComponent();

            LoadUsers();
            LoadQuestions();
        }

        // ---------- show the data ----------

        // Loads usernames and roles into the users grid.
        private void LoadUsers()
        {
            string query = "SELECT Username, Role FROM Users ORDER BY Username";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvUsers.DataSource = table;
        }

        // Loads all questions into the questions grid.
        private void LoadQuestions()
        {
            string query = "SELECT Id, question, RightAwnser, WrongAwnser1, WrongAwnser2, WrongAwnser3, category FROM Questions ORDER BY Id";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvQuestions.DataSource = table;
        }

        // ---------- users ----------

        private void btnChangeRole_Click(object sender, EventArgs e)
        {
            // A user row and a new role must be selected before updating the database.
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            if (cmbRole.Text == "")
            {
                MessageBox.Show("Choose a role first.");
                return;
            }

            string username = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();

            // otherwise you could remove your own admin rights
            if (username == Program.CurrentUser)
            {
                MessageBox.Show("You can't change your own role.");
                return;
            }

            // Update the selected user's role in the database.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "UPDATE Users SET Role = @role WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@role", cmbRole.Text);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
            }

            MessageBox.Show(username + " is now: " + cmbRole.Text);
            LoadUsers();
        }

        private void btnDeleteUser_Click(object sender, EventArgs e)
        {
            // A selected row is required before a user can be deleted.
            if (dgvUsers.CurrentRow == null)
            {
                MessageBox.Show("Select a user first.");
                return;
            }

            string username = dgvUsers.CurrentRow.Cells["Username"].Value.ToString();

            // otherwise you could delete your own account
            if (username == Program.CurrentUser)
            {
                MessageBox.Show("You can't delete your own account.");
                return;
            }

            DialogResult answer = MessageBox.Show("Delete " + username + " and all of their scores?",
                                                  "Delete user", MessageBoxButtons.YesNo);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            // Delete the user's scores first, then delete the user account.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // first the scores of this user, then the user itself
                string query = "DELETE FROM Scores WHERE Username = @username; " +
                               "DELETE FROM Users WHERE Username = @username";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.ExecuteNonQuery();
            }

            LoadUsers();
        }

        // ---------- questions ----------

        private void btnAddQuestion_Click(object sender, EventArgs e)
        {
            // Every question field is required before a new row can be inserted.
            if (txbQuestion.Text.Trim() == "" ||
                txbCorrect.Text.Trim() == "" ||
                txbWrong1.Text.Trim() == "" ||
                txbWrong2.Text.Trim() == "" ||
                txbWrong3.Text.Trim() == "" ||
                cmbCategory.Text == "")
            {
                MessageBox.Show("Please fill in all the fields.");
                return;
            }

            // Insert the new question and all of its possible answers.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "INSERT INTO Questions (question, RightAwnser, WrongAwnser1, WrongAwnser2, WrongAwnser3, category) " +
                               "VALUES (@question, @correct, @wrong1, @wrong2, @wrong3, @category)";

                // If you get the error "Cannot insert the value NULL into column 'Id'",
                // the Id does not number itself. Use this query instead:
                // string query = "INSERT INTO Questions (Id, question, RightAwnser, WrongAwnser1, WrongAwnser2, WrongAwnser3, category) " +
                //                "VALUES ((SELECT ISNULL(MAX(Id), 0) + 1 FROM Questions), @question, @correct, @wrong1, @wrong2, @wrong3, @category)";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@question", txbQuestion.Text.Trim());
                cmd.Parameters.AddWithValue("@correct", txbCorrect.Text.Trim());
                cmd.Parameters.AddWithValue("@wrong1", txbWrong1.Text.Trim());
                cmd.Parameters.AddWithValue("@wrong2", txbWrong2.Text.Trim());
                cmd.Parameters.AddWithValue("@wrong3", txbWrong3.Text.Trim());
                cmd.Parameters.AddWithValue("@category", cmbCategory.Text);
                cmd.ExecuteNonQuery();
            }

            // Clear the input controls so another question can be entered.
            txbQuestion.Text = "";
            txbCorrect.Text = "";
            txbWrong1.Text = "";
            txbWrong2.Text = "";
            txbWrong3.Text = "";
            cmbCategory.SelectedIndex = -1;

            MessageBox.Show("Question added!");
            LoadQuestions();
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            // A selected question row is required before deletion.
            if (dgvQuestions.CurrentRow == null)
            {
                MessageBox.Show("Select a question first.");
                return;
            }

            int id = Convert.ToInt32(dgvQuestions.CurrentRow.Cells["Id"].Value);
            string questionText = dgvQuestions.CurrentRow.Cells["question"].Value.ToString();

            DialogResult answer = MessageBox.Show("Delete this question?\n\n" + questionText,
                                                  "Delete question", MessageBoxButtons.YesNo);
            if (answer != DialogResult.Yes)
            {
                return;
            }

            // Delete the selected question by its database identifier.
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = "DELETE FROM Questions WHERE Id = @id";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@id", id);
                cmd.ExecuteNonQuery();
            }

            LoadQuestions();
        }

       
    }
}