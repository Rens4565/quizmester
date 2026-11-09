using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Quizmester
{
    // Main game form containing category quizzes, speed quiz mode, timers, and scoring.
    public partial class quizForm : Form
    {
        public quizForm()
        {
            // Creates the controls defined in quizForm.Designer.cs.
            InitializeComponent();
        }

        

        // The current set of questions and the position of the question being shown.
        private List<Question> quizQuestions;
        private int currentQuestionIndex = 0;
        // Score and one-use helpers for a normal category quiz.
        public int score = 0;
        private bool skipUsed = false;
        private bool fiftyfiftyUsed = false;
        private int specialQuestionIndex = -1;

        // Time limits for one question and for the entire normal quiz.
        private int questinTimeLimit = 6;
        private int quizTimeLimit = 60;
        private int questionTimeLeft;
        private int quizTimeLeft;
        private string currentCategory = "";

        // State and counters used by the speed quiz mode.
        private bool isSpeedQuiz = false;
        private int speedSeconds = 0;
        private int speedCorrect = 0;
        private int speedGoal = 10;   // how many correct answers you need

        // Loads and starts a normal quiz for the selected category.
        private void LoadQuiz(string category)
        {
            isSpeedQuiz = false;

            GetQuestionsDB repo = new GetQuestionsDB();
            quizQuestions = repo.GetQuestions(category);
            quizQuestions = ShuffleQuestions(quizQuestions);
            currentCategory = category;

            // Pick one special question from the first 20 questions.
            // (Math.Min makes sure it also works when there are less than 20 questions)
            Random rnd = new Random();
            specialQuestionIndex = rnd.Next(Math.Min(20, quizQuestions.Count));


            currentQuestionIndex = 0;
            score = 0;
            skipUsed = false;
            fiftyfiftyUsed = false;


            quizTimeLeft = quizTimeLimit;
            lblQuizTime.Text = "Time Left: " + quizTimeLeft;

            ShowQuestions();
        }

        // Displays the current question and prepares its answer buttons.
        private void ShowQuestions()
        {
            // Speed quiz mode reuses the question list when all questions have been shown.
            if (isSpeedQuiz == true && currentQuestionIndex >= quizQuestions.Count)
            {
                quizQuestions = ShuffleQuestions(quizQuestions);
                currentQuestionIndex = 0;
            }

            if (currentQuestionIndex >= quizQuestions.Count)
            {
                EndQuiz();
                return;
            }

            Question currentQuestion = quizQuestions[currentQuestionIndex];
            lblQuestion.Text = currentQuestion.Text;

            // A special question receives a different color, text, and sound.
            if (currentQuestionIndex == specialQuestionIndex)
            {
                this.BackColor = Color.Gold;
                lblQuestion.Text = "SPECIAL (3 points)! " + currentQuestion.Text;
                PlaySpecialSound();
            }
            else
            {
                this.BackColor = SystemColors.Control;
            }

            List<string> shuffledAnswers = ShuffleAnswers(currentQuestion);

            btnAnswer1.Text = shuffledAnswers[0];
            btnAnswer2.Text = shuffledAnswers[1];
            btnAnswer3.Text = shuffledAnswers[2];
            btnAnswer4.Text = shuffledAnswers[3];

            // Re-enable all answer buttons after a previous 50/50 action.
            btnAnswer1.Enabled = true;
            btnAnswer2.Enabled = true;
            btnAnswer3.Enabled = true;
            btnAnswer4.Enabled = true;

            // Speed quiz uses one overall counter instead of a per-question limit.
            if (isSpeedQuiz == true)
            {
                lblQuestionTime.Text = "No time limit per question";
            }
            else
            {
                questionTimeLeft = questinTimeLimit;
                lblQuestionTime.Text = "Question time:" + questionTimeLeft;
            }

            QuizTimer.Start();


        }

        private void PlaySpecialSound()
        {
            // The sound file is expected to be next to the executable.
            string soundPath = System.IO.Path.Combine(Application.StartupPath, "special.wav");

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath);
            player.Play();   // plays in the background, so the quiz keeps running
        }
        // Updates either the speed counter or the normal quiz timers once per second.
        private void timerQuestion_Tick(object sender, EventArgs e)
        {
            if (isSpeedQuiz == true)
            {
                speedSeconds++;
                lblQuizTime.Text = "Time: " + speedSeconds;
                return;
            }

            // ---------- overall quiz clock ----------
            quizTimeLeft--;
            lblQuizTime.Text = "Total time: " + quizTimeLeft;

            if (quizTimeLeft < 11)
            {
                lblQuizTime.BackColor = Color.Red;
            }

            if (quizTimeLeft <= 0)
            {
                QuizTimer.Stop();
                EndQuiz();          // whole quiz is over, ignore the question clock
                return;              // stop here, don't also touch the question clock below
            }

            // ---------- per-question clock ----------
            questionTimeLeft--;
            lblQuestionTime.Text = "Time left: " + questionTimeLeft;


            if (questionTimeLeft <= 0)
            {
                // question ran out, treat like wrong answer, move to next question
                // note: we do NOT stop the timer here, the quiz clock keeps running
                currentQuestionIndex++;
                ShowQuestions();
            }
        }



        

        private void quizForm_Load(object sender, EventArgs e)
        {
            // Only administrators should see the administration button.
            btnAdmin.Visible = Program.IsAdmin;
        }

        




        private List<string> ShuffleAnswers(Question q)
        {
            // Put the correct answer and the three wrong answers into one list.
            List<string> answers = new List<string>();
            answers.Add(q.CorrectAnswer);
            answers.Add(q.WrongAnswer1);
            answers.Add(q.WrongAnswer2);
            answers.Add(q.WrongAnswer3);

            Random rnd = new Random();

            // Swap random items to create a different answer order.
            for (int i = 0; i < answers.Count; i++)
            {
                int randomIndex = rnd.Next(answers.Count);
                string temp = answers[i];
                answers[i] = answers[randomIndex];
                answers[randomIndex] = temp;

            }

            return answers;
        }

        private List<Question> ShuffleQuestions(List<Question> questionsToShuffle)
        {
            // Randomly reorder the questions so each quiz has a different sequence.
            Random rnd = new Random();

            for (int i = 0; i < questionsToShuffle.Count; i++)
            {
                int randomIndex = rnd.Next(questionsToShuffle.Count);
                Question temp = questionsToShuffle[i];
                questionsToShuffle[i] = questionsToShuffle[randomIndex];
                questionsToShuffle[randomIndex] = temp;
            }

            return questionsToShuffle;
        }

        private void btnAnswer1_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnAnswer1.Text);
        }

        private void btnAnswer2_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnAnswer2.Text);
        }

        private void btnAnswer3_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnAnswer3.Text);
        }

        private void btnAnswer4_Click(object sender, EventArgs e)
        {
            CheckAnswer(btnAnswer4.Text);
        }

        // Checks a selected answer and routes it to the correct quiz mode.
        private void CheckAnswer(string chosenAnswer)
        {
            if (isSpeedQuiz == true)
            {
                CheckSpeedAnswer(chosenAnswer);
                return;
            }

            Question currentQuestion = quizQuestions[currentQuestionIndex];

            if (chosenAnswer == currentQuestion.CorrectAnswer)
            {
                // Special questions are worth three points instead of one.
                if (currentQuestionIndex == specialQuestionIndex)
                {
                    score = score + 3;   // special question: 3 points (change the 3 if you want)
                }
                else
                {
                    score++;
                }
                lblScore.Text = Convert.ToString("score:" + score);
            }
            else
            {
                quizTimeLeft -= 5;
            }


            currentQuestionIndex++;
            ShowQuestions();
        }

        private void SkipQuestion()
        {
            // Move to the next question and mark the one-time skip as used.
            currentQuestionIndex++;
            skipUsed = true;

            ShowQuestions();

        }

        private void btnSkipQuestion_Click(object sender, EventArgs e)
        {
            // The skip button can only be used once in a normal quiz.
            if (skipUsed == false)
            {
                SkipQuestion();
               
            }
        }
        private void EndQuiz()
        {
            // Stop the timer before saving the final normal-quiz score.
            QuizTimer.Stop();
            this.BackColor = SystemColors.Control;

            int finalScore = score;
            int place = 0;
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Save the final score and category.
                string saveQuery = "INSERT INTO Scores (Username, Score, Category) VALUES (@username, @score, @category)";
                SqlCommand saveCmd = new SqlCommand(saveQuery, conn);
                saveCmd.Parameters.AddWithValue("@username", Program.CurrentUser);
                saveCmd.Parameters.AddWithValue("@score", finalScore);
                saveCmd.Parameters.AddWithValue("@category", currentCategory);
                saveCmd.ExecuteNonQuery();

                // Calculate the player's ranking by counting higher scores.
                string placeQuery = "SELECT COUNT(*) FROM Scores WHERE Score > @score";
                SqlCommand placeCmd = new SqlCommand(placeQuery, conn);
                placeCmd.Parameters.AddWithValue("@score", finalScore);
                place = (int)placeCmd.ExecuteScalar() + 1;
            }

            // Show the final score and whether the player reached the top ten.
            string message = "Quiz afgelopen! Je score: " + finalScore;
            if (place <= 10 && finalScore > 0)
            {
                message = message + "\nJe staat op plek " + place + " in de top 10!";
            }
            else
            {
                message = message + "\nJe hebt de top 10 niet gehaald.";
            }
            MessageBox.Show(message);

            // Reset the controls so another quiz can be started.
            score = 0;
            currentQuestionIndex = 0;
            skipUsed = false;

            lblScore.Text = "score: 0";
            lblQuestion.Text = "Kies een categorie";
            lblQuestionTime.Text = "Question time: 0";
            lblQuizTime.Text = "Total time: 0";

            btnGeneral.Visible = true;
            btnHistory.Visible = true;
            btnScience.Visible = true;
        }

        private void btnGeneral_Click(object sender, EventArgs e)
        {
            LoadQuiz("General");
        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            LoadQuiz("History");
        }

        private void btnScience_Click(object sender, EventArgs e)
        {
            LoadQuiz("Science");
        }

        private void btnShowLeaderboard_Click(object sender, EventArgs e)
        {
            // Open the leaderboard without closing the quiz form.
            Leaderboard form = new Leaderboard();
            form.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // Open the administration screen for an administrator.
            AdminForm form = new AdminForm();
            form.Show();
            
        }

        private void btn5050_Click(object sender, EventArgs e)
        {
            // The 50/50 helper is available only while a quiz is active and only once.
            if (QuizTimer.Enabled == false || fiftyfiftyUsed == true)
            {
                return;
            }

            fiftyfiftyUsed = true;

            Question currentQuestion = quizQuestions[currentQuestionIndex];
            Button[] buttons = { btnAnswer1, btnAnswer2, btnAnswer3, btnAnswer4 };
            Random rnd = new Random();
            int disabledCount = 0;

            // Disable two randomly selected wrong answers.
            while (disabledCount < 2)
            {
                int i = rnd.Next(4);

                if (buttons[i].Text != currentQuestion.CorrectAnswer && buttons[i].Enabled == true)
                {
                    buttons[i].Enabled = false;
                    disabledCount++;
                }
            }
        }


        private void btnSpeedQuiz_Click(object sender, EventArgs e)
        {
            // Start the special speed quiz mode.
            LoadSpeedQuiz();
        }

        private void LoadSpeedQuiz()
        {
            // Speed quiz uses all questions, counts time upward, and tracks correct answers.
            isSpeedQuiz = true;

            GetQuestionsDB repo = new GetQuestionsDB();
            // "General" returns all questions in the current database implementation.
            quizQuestions = repo.GetQuestions("General");
            quizQuestions = ShuffleQuestions(quizQuestions);

            currentQuestionIndex = 0;
            specialQuestionIndex = -1;   // no special question in this quiz
            skipUsed = false;
            fiftyfiftyUsed = false;
            speedSeconds = 0;
            speedCorrect = 0;

            lblQuizTime.Text = "Time: 0";
            lblScore.Text = "Correct: 0 / " + speedGoal;

            ShowQuestions();
        }

        private void CheckSpeedAnswer(string chosenAnswer)
        {
            // Correct answers increase progress; wrong answers add five seconds.
            Question currentQuestion = quizQuestions[currentQuestionIndex];

            if (chosenAnswer == currentQuestion.CorrectAnswer)
            {
                speedCorrect++;
                lblScore.Text = "Correct: " + speedCorrect + " / " + speedGoal;

                if (speedCorrect >= speedGoal)
                {
                    EndSpeedQuiz();
                    return;
                }
            }
            else
            {
                speedSeconds += 5;   // wrong answer = 5 seconds extra
                lblQuizTime.Text = "Time: " + speedSeconds;
            }

            currentQuestionIndex++;
            ShowQuestions();
        }

        private void EndSpeedQuiz()
        {
            // Stop the timer and save the completed speed-quiz time.
            QuizTimer.Stop();
            isSpeedQuiz = false;

            int myTime = speedSeconds;
            bool recordExists = false;
            int bestTime = 0;
            string bestUser = "";
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Find the previous fastest result before saving the new result.
                string bestQuery = "SELECT TOP 1 Username, TimeSeconds FROM SpeedScores ORDER BY TimeSeconds ASC";
                SqlCommand bestCmd = new SqlCommand(bestQuery, conn);
                using (SqlDataReader reader = bestCmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        recordExists = true;
                        bestUser = reader["Username"].ToString();
                        bestTime = (int)reader["TimeSeconds"];
                    }
                }

                // Save the current user's completion time.
                string saveQuery = "INSERT INTO SpeedScores (Username, TimeSeconds) VALUES (@username, @time)";
                SqlCommand saveCmd = new SqlCommand(saveQuery, conn);
                saveCmd.Parameters.AddWithValue("@username", Program.CurrentUser);
                saveCmd.Parameters.AddWithValue("@time", myTime);
                saveCmd.ExecuteNonQuery();
            }

            // Tell the player their time and whether they set a new record.
            string message = "You answered " + speedGoal + " questions correctly!\nYour time: " + myTime + " seconds";

            if (recordExists == false || myTime < bestTime)
            {
                message = message + "\n\nNEW RECORD! You have the fastest time ever!";
            }
            else
            {
                message = message + "\nFastest time ever: " + bestTime + " seconds (by " + bestUser + ")";
            }
            MessageBox.Show(message);

            // Reset the screen for the next quiz.
            score = 0;
            currentQuestionIndex = 0;
            skipUsed = false;

            lblScore.Text = "score: 0";
            lblQuestion.Text = "Kies een categorie";
            lblQuestionTime.Text = "Question time: 0";
            lblQuizTime.Text = "Total time: 0";

            btnGeneral.Visible = true;
            btnHistory.Visible = true;
            btnScience.Visible = true;
        }

    }
}

