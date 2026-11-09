using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmester
{
    // This class is responsible for retrieving questions from SQL Server.
    internal class GetQuestionsDB
    {
        // Returns all questions, or only questions from the requested category.
        public List<Question> GetQuestions(string category)
        {
            List<Question> questions = new List<Question>();

            // Connection details for the local Quizmester SQL Server database.
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            // The category filter is added only when a specific category is requested.
            string query = "SELECT Id, question, RightAwnser, WrongAwnser1, WrongAwnser2, WrongAwnser3, category FROM Questions";

            if (category != "General")
            {
                query = query + " WHERE category = @category";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                // Open the connection and execute the query against SQL Server.
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);


                if (category != "General")
                {
                    cmd.Parameters.AddWithValue("@category", category);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    // Convert the current database row into a Question object.
                    Question q = new Question();
                    q.Id = (int)reader["Id"];
                    q.Text = reader["Question"].ToString();
                    q.CorrectAnswer = reader["RightAwnser"].ToString();
                    q.WrongAnswer1 = reader["WrongAwnser1"].ToString();
                    q.WrongAnswer2 = reader["WrongAwnser2"].ToString();
                    q.WrongAnswer3 = reader["WrongAwnser3"].ToString();
                    q.Category = reader["category"].ToString();

                    // Add the converted question to the list returned to the quiz form.
                    questions.Add(q);

                }

            }
            return questions;
        }
    }
}
