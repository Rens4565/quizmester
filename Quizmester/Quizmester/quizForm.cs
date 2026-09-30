using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;

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

        private int questinTimeLimit = 6;
        private int quizTimeLimit = 60;
        private int questionTimeLeft;
        private int quizTimeLeft;

        private void LoadQuiz(string category)
        {
            GetQuestionsDB repo = new GetQuestionsDB();
            quizQuestions = repo.GetQuestions(category);
            quizQuestions = ShuffleQuestions(quizQuestions);


            currentQuestionIndex = 0;
            score = 0;
            skipUsed = false;


            quizTimeLeft = quizTimeLimit;
            lblQuizTime.Text = "Time Left: " + quizTimeLeft;

            ShowQuestions();
        }

        private void ShowQuestions()
        {
            if (currentQuestionIndex >= quizQuestions.Count)
            {
                EndQuiz();
                return;
            }

            Question currentQuestion = quizQuestions[currentQuestionIndex];
            lblQuestion.Text = currentQuestion.Text;

            List<string> shuffledAnswers = ShuffleAnswers(currentQuestion);
            
            btnAnswer1.Text = shuffledAnswers[0];
            btnAnswer2.Text = shuffledAnswers[1];
            btnAnswer3.Text = shuffledAnswers[2];
            btnAnswer4.Text = shuffledAnswers[3];


            questionTimeLeft = questinTimeLimit;
            lblQuestionTime.Text = "Question time:" + questionTimeLeft;

            QuizTimer.Start();


        }
        private void timerQuestion_Tick(object sender, EventArgs e)
        {
            // --- overall quiz clock ---
            quizTimeLeft--;
            lblQuizTime.Text = "Total time: " + quizTimeLeft;

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

        private void CheckAnswer(string chosenAnswer)
        {
            Question currentQuestion = quizQuestions[currentQuestionIndex];

            if (chosenAnswer == currentQuestion.CorrectAnswer)
            {
                score++;
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

        
    }
}
