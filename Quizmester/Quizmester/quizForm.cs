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

        private void LoadQuiz(string category)
        {
            GetQuestionsDB repo = new GetQuestionsDB();
            quizQuestions = repo.GetQuestions(category);
            quizQuestions = ShuffleQuestions(quizQuestions);


            currentQuestionIndex = 0;
            score = 0;
            skipUsed = false;
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
            
            btnAnswer1.Text =shuffledAnswers[0];
            btnAnswer2.Text = shuffledAnswers[1];
            btnAnswer3.Text = shuffledAnswers[2];
            btnAnswer4.Text = shuffledAnswers[3];
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
                MessageBox.Show("correct");
                lblScore.Text = Convert.ToString(score);
            }
            else
            {
                MessageBox.Show("Fout! het juiste antwoord was:" + currentQuestion.CorrectAnswer);
            }

            currentQuestionIndex++;
            ShowQuestions();
        }
        private void EndQuiz()
        {
         
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
