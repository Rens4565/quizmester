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
    public partial class quizForm : Form
    {
        public quizForm()
        {
            InitializeComponent();
        }
        RegisterForm RegisterForm = new RegisterForm();

        private List<Question> quizQuestions;
        private int currentQuestionIndex = 0;
        public int score = 0;
        private bool skipUsed = false;
        private bool fiftyfiftyUsed = false;
        private int specialQuestionIndex = -1;

        private int questinTimeLimit = 6;
        private int quizTimeLimit = 60;
        private int questionTimeLeft;
        private int quizTimeLeft;
        private string currentCategory = "";

        private bool isSpeedQuiz = false;
        private int speedSeconds = 0;
        private int speedCorrect = 0;
        private int speedGoal = 10;   // how many correct answers you need

        // new line: isSpeedQuiz = false;
        private void LoadQuiz(string category)
        {
            isSpeedQuiz = false;

            GetQuestionsDB repo = new GetQuestionsDB();
            quizQuestions = repo.GetQuestions(category);
            quizQuestions = ShuffleQuestions(quizQuestions);
            currentCategory = category;

            // pick the special question: a random number from the first 20 questions
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

        // new: the speed quiz block at the top and the if/else around the question time label
        private void ShowQuestions()
        {
            // speed quiz: when all questions are used, shuffle and start again
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

            // special question: other color, extra text and a sound
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

            // after a 50/50 the next question needs all buttons back
            btnAnswer1.Enabled = true;
            btnAnswer2.Enabled = true;
            btnAnswer3.Enabled = true;
            btnAnswer4.Enabled = true;

            // the speed quiz has no time limit per question
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
            // the sound file is in the same folder as the .exe
            string soundPath = System.IO.Path.Combine(Application.StartupPath, "special.wav");

            System.Media.SoundPlayer player = new System.Media.SoundPlayer(soundPath);
            player.Play();   // plays in the background, so the quiz keeps running
        }
        // new: the speed quiz block at the top (the timer counts UP and nothing else happens)
        private void timerQuestion_Tick(object sender, EventArgs e)
        {
            if (isSpeedQuiz == true)
            {
                speedSeconds++;
                lblQuizTime.Text = "Time: " + speedSeconds;
                return;
            }

            // --- overall quiz clock ---
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

            // --- per-question clock ---
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



        private void btnTestForm_Click(object sender, EventArgs e)
        {
            RegisterForm.Show();
        }

        private void quizForm_Load(object sender, EventArgs e)
        {
            btnAdmin.Visible = Program.IsAdmin;
        }

        




        private List<string> ShuffleAnswers(Question q)
        {
            List<string> answers = new List<string>();
            answers.Add(q.CorrectAnswer);
            answers.Add(q.WrongAnswer1);
            answers.Add(q.WrongAnswer2);
            answers.Add(q.WrongAnswer3);

            Random rnd = new Random();

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

        // new: the speed quiz block at the top
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
            currentQuestionIndex++;
            skipUsed = true;

            ShowQuestions();

        }

        private void btnSkipQuestion_Click(object sender, EventArgs e)
        {
            if (skipUsed == false)
            {
                SkipQuestion();
               
            }
        }
        private void EndQuiz()
        {
            QuizTimer.Stop();
            this.BackColor = SystemColors.Control;

            int finalScore = score;
            int place = 0;
            string connectionString = "Data Source=localhost\\sqlexpress;Initial Catalog=Quizmester;Integrated Security=True;Encrypt=True;TrustServerCertificate=True";

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Score opslaan
                string saveQuery = "INSERT INTO Scores (Username, Score, Category) VALUES (@username, @score, @category)";
                SqlCommand saveCmd = new SqlCommand(saveQuery, conn);
                saveCmd.Parameters.AddWithValue("@username", Program.CurrentUser);
                saveCmd.Parameters.AddWithValue("@score", finalScore);
                saveCmd.Parameters.AddWithValue("@category", currentCategory);
                saveCmd.ExecuteNonQuery();

                // 2. Plek uitrekenen: hoeveel scores zijn hoger dan de mijne? Plus 1.
                string placeQuery = "SELECT COUNT(*) FROM Scores WHERE Score > @score";
                SqlCommand placeCmd = new SqlCommand(placeQuery, conn);
                placeCmd.Parameters.AddWithValue("@score", finalScore);
                place = (int)placeCmd.ExecuteScalar() + 1;
            }

            // 3. Eindscore tonen
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

            // 4. Resetten (zoals je al had)
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
            Leaderboard form = new Leaderboard();
            form.Show();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            AdminForm form = new AdminForm();
            form.Show();
            this.Close();
        }

        private void btn5050_Click(object sender, EventArgs e)
        {
            if (QuizTimer.Enabled == false || fiftyfiftyUsed == true)
            {
                return;
            }

            fiftyfiftyUsed = true;

            Question currentQuestion = quizQuestions[currentQuestionIndex];
            Button[] buttons = { btnAnswer1, btnAnswer2, btnAnswer3, btnAnswer4 };
            Random rnd = new Random();
            int disabledCount = 0;

            // disable 2 random WRONG answers
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
            LoadSpeedQuiz();
        }

        private void LoadSpeedQuiz()
        {
            isSpeedQuiz = true;

            GetQuestionsDB repo = new GetQuestionsDB();
            quizQuestions = repo.GetQuestions("General");   // "General" gives all questions
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

                // 1. get the fastest time so far (before saving mine)
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

                // 2. save my time
                string saveQuery = "INSERT INTO SpeedScores (Username, TimeSeconds) VALUES (@username, @time)";
                SqlCommand saveCmd = new SqlCommand(saveQuery, conn);
                saveCmd.Parameters.AddWithValue("@username", Program.CurrentUser);
                saveCmd.Parameters.AddWithValue("@time", myTime);
                saveCmd.ExecuteNonQuery();
            }

            // 3. show the result
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

            // 4. reset the screen
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

