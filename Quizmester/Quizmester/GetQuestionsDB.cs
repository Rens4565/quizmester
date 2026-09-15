using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quizmester
{
    internal class GetQuestionsDB
    {

        public List<Question> GetQuestions(string category)
        {
            List<Question> questions = new List<Question>();

            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            string query = "SELECT Id, question, RightAwnser, WrongAwnser1, WrongAwnser2, WrongAwnser3, category FROM Questions";

            if (category != "General")
            {
                query = query + " WHERE category = @category";
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(query, conn);


                if (category != "General")
                {
                    cmd.Parameters.AddWithValue("@category", category);
                }

                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Question q = new Question();
                    q.Id = (int)reader["Id"];
                    q.Text = reader["Question"].ToString();
                    q.CorrectAnswer = reader["RightAwnser"].ToString();
                    q.WrongAnswer1 = reader["WrongAwnser1"].ToString();
                    q.WrongAnswer2 = reader["WrongAwnser2"].ToString();
                    q.WrongAnswer3 = reader["WrongAwnser3"].ToString();
                    q.Category = reader["category"].ToString();

                    questions.Add(q);

                }

            }
            return questions;
        }
    }
}
