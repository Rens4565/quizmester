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
    public partial class Leaderboard : Form
    {
        // Add this declaration if it does not exist in the designer file
        private DataGridView dgvScores;

        public Leaderboard()
        {
            InitializeComponent();

            // Initialize dgvScores if not already done by designer
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
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";
            string query = "SELECT TOP 10 Username, Score FROM Scores ORDER BY Score DESC";

            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
            DataTable table = new DataTable();
            adapter.Fill(table);

            dgvScores.DataSource = table;
        }
    }
}
