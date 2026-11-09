using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quizmester
{
    // Displays the highest scores saved in the Scores database table.
    public partial class Leaderboard : Form
    {
        // Add this declaration if it does not exist in the designer file
        private DataGridView dgvScores;

        public Leaderboard()
        {
            // Creates the form controls defined in Leaderboard.Designer.cs.
            InitializeComponent();

            // The score grid is created here because it is not defined by the Designer.
            if (dgvScores == null)
            {
                dgvScores = new DataGridView
                {
                    Dock = DockStyle.Fill,
                    AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
                };
                Controls.Add(dgvScores);
            }
        }

        private void Leaderboard_Load(object sender, EventArgs e)
        {
            // Select the ten highest scores and sort them from highest to lowest.
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string query = "SELECT TOP 10 Username, Score FROM Scores ORDER BY Score DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);

            // Bind the database results to the grid shown on the form.
            dgvScores.DataSource = table;
        }
    }
}
