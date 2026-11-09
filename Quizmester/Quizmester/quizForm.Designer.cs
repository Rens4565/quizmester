namespace Quizmester
{
    partial class quizForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblQuestion = new System.Windows.Forms.Label();
            this.btnAnswer1 = new System.Windows.Forms.Button();
            this.btnAnswer2 = new System.Windows.Forms.Button();
            this.btnAnswer3 = new System.Windows.Forms.Button();
            this.btnAnswer4 = new System.Windows.Forms.Button();
            this.btnGeneral = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnScience = new System.Windows.Forms.Button();
            this.lblScore = new System.Windows.Forms.Label();
            this.btnSkipQuestion = new System.Windows.Forms.Button();
            this.QuizTimer = new System.Windows.Forms.Timer(this.components);
            this.lblQuizTime = new System.Windows.Forms.Label();
            this.lblQuestionTime = new System.Windows.Forms.Label();
            this.btnShowLeaderboard = new System.Windows.Forms.Button();
            this.btnAdmin = new System.Windows.Forms.Button();
            this.btn5050 = new System.Windows.Forms.Button();
            this.btnSpeedQuiz = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblQuestion.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblQuestion.Location = new System.Drawing.Point(180, 75);
            this.lblQuestion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(44, 25);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "test";
            // 
            // btnAnswer1
            // 
            this.btnAnswer1.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAnswer1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer1.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnswer1.ForeColor = System.Drawing.Color.White;
            this.btnAnswer1.Location = new System.Drawing.Point(180, 145);
            this.btnAnswer1.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnswer1.Name = "btnAnswer1";
            this.btnAnswer1.Size = new System.Drawing.Size(180, 36);
            this.btnAnswer1.TabIndex = 1;
            this.btnAnswer1.Text = "button1";
            this.btnAnswer1.UseVisualStyleBackColor = true;
            this.btnAnswer1.Click += new System.EventHandler(this.btnAnswer1_Click);
            // 
            // btnAnswer2
            // 
            this.btnAnswer2.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAnswer2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnswer2.ForeColor = System.Drawing.Color.White;
            this.btnAnswer2.Location = new System.Drawing.Point(380, 145);
            this.btnAnswer2.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnswer2.Name = "btnAnswer2";
            this.btnAnswer2.Size = new System.Drawing.Size(180, 36);
            this.btnAnswer2.TabIndex = 2;
            this.btnAnswer2.Text = "button2";
            this.btnAnswer2.UseVisualStyleBackColor = true;
            this.btnAnswer2.Click += new System.EventHandler(this.btnAnswer2_Click);
            // 
            // btnAnswer3
            // 
            this.btnAnswer3.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAnswer3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer3.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnswer3.ForeColor = System.Drawing.Color.White;
            this.btnAnswer3.Location = new System.Drawing.Point(180, 200);
            this.btnAnswer3.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnswer3.Name = "btnAnswer3";
            this.btnAnswer3.Size = new System.Drawing.Size(180, 36);
            this.btnAnswer3.TabIndex = 3;
            this.btnAnswer3.Text = "button3";
            this.btnAnswer3.UseVisualStyleBackColor = true;
            this.btnAnswer3.Click += new System.EventHandler(this.btnAnswer3_Click);
            // 
            // btnAnswer4
            // 
            this.btnAnswer4.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAnswer4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAnswer4.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnAnswer4.ForeColor = System.Drawing.Color.White;
            this.btnAnswer4.Location = new System.Drawing.Point(380, 200);
            this.btnAnswer4.Margin = new System.Windows.Forms.Padding(2);
            this.btnAnswer4.Name = "btnAnswer4";
            this.btnAnswer4.Size = new System.Drawing.Size(180, 36);
            this.btnAnswer4.TabIndex = 4;
            this.btnAnswer4.Text = "button4";
            this.btnAnswer4.UseVisualStyleBackColor = true;
            this.btnAnswer4.Click += new System.EventHandler(this.btnAnswer4_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGeneral.ForeColor = System.Drawing.Color.White;
            this.btnGeneral.Location = new System.Drawing.Point(30, 95);
            this.btnGeneral.Margin = new System.Windows.Forms.Padding(2);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(110, 35);
            this.btnGeneral.TabIndex = 5;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnHistory.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHistory.ForeColor = System.Drawing.Color.White;
            this.btnHistory.Location = new System.Drawing.Point(30, 145);
            this.btnHistory.Margin = new System.Windows.Forms.Padding(2);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(110, 35);
            this.btnHistory.TabIndex = 6;
            this.btnHistory.Text = "history";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnScience
            // 
            this.btnScience.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.btnScience.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnScience.ForeColor = System.Drawing.Color.White;
            this.btnScience.Location = new System.Drawing.Point(30, 195);
            this.btnScience.Margin = new System.Windows.Forms.Padding(2);
            this.btnScience.Name = "btnScience";
            this.btnScience.Size = new System.Drawing.Size(110, 35);
            this.btnScience.TabIndex = 7;
            this.btnScience.Text = "Science";
            this.btnScience.UseVisualStyleBackColor = true;
            this.btnScience.Click += new System.EventHandler(this.btnScience_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblScore.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblScore.Location = new System.Drawing.Point(526, 353);
            this.lblScore.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(47, 19);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Score";
            // 
            // btnSkipQuestion
            // 
            this.btnSkipQuestion.BackColor = System.Drawing.Color.SteelBlue;
            this.btnSkipQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSkipQuestion.ForeColor = System.Drawing.Color.White;
            this.btnSkipQuestion.Location = new System.Drawing.Point(390, 345);
            this.btnSkipQuestion.Margin = new System.Windows.Forms.Padding(2);
            this.btnSkipQuestion.Name = "btnSkipQuestion";
            this.btnSkipQuestion.Size = new System.Drawing.Size(120, 35);
            this.btnSkipQuestion.TabIndex = 9;
            this.btnSkipQuestion.Text = "skip question";
            this.btnSkipQuestion.UseVisualStyleBackColor = true;
            this.btnSkipQuestion.Click += new System.EventHandler(this.btnSkipQuestion_Click);
            // 
            // QuizTimer
            // 
            this.QuizTimer.Interval = 1000;
            this.QuizTimer.Tick += new System.EventHandler(this.timerQuestion_Tick);
            // 
            // lblQuizTime
            // 
            this.lblQuizTime.AutoSize = true;
            this.lblQuizTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuizTime.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblQuizTime.Location = new System.Drawing.Point(30, 350);
            this.lblQuizTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuizTime.Name = "lblQuizTime";
            this.lblQuizTime.Size = new System.Drawing.Size(56, 15);
            this.lblQuizTime.TabIndex = 10;
            this.lblQuizTime.Text = "quiz time";
            // 
            // lblQuestionTime
            // 
            this.lblQuestionTime.AutoSize = true;
            this.lblQuestionTime.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblQuestionTime.ForeColor = System.Drawing.Color.MidnightBlue;
            this.lblQuestionTime.Location = new System.Drawing.Point(160, 350);
            this.lblQuestionTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblQuestionTime.Name = "lblQuestionTime";
            this.lblQuestionTime.Size = new System.Drawing.Size(80, 15);
            this.lblQuestionTime.TabIndex = 11;
            this.lblQuestionTime.Text = "question time";
            // 
            // btnShowLeaderboard
            // 
            this.btnShowLeaderboard.BackColor = System.Drawing.Color.SteelBlue;
            this.btnShowLeaderboard.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnShowLeaderboard.ForeColor = System.Drawing.Color.White;
            this.btnShowLeaderboard.Location = new System.Drawing.Point(540, 25);
            this.btnShowLeaderboard.Margin = new System.Windows.Forms.Padding(2);
            this.btnShowLeaderboard.Name = "btnShowLeaderboard";
            this.btnShowLeaderboard.Size = new System.Drawing.Size(125, 40);
            this.btnShowLeaderboard.TabIndex = 12;
            this.btnShowLeaderboard.Text = "Show leaderboard";
            this.btnShowLeaderboard.UseVisualStyleBackColor = true;
            this.btnShowLeaderboard.Click += new System.EventHandler(this.btnShowLeaderboard_Click);
            // 
            // btnAdmin
            // 
            this.btnAdmin.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAdmin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdmin.ForeColor = System.Drawing.Color.White;
            this.btnAdmin.Location = new System.Drawing.Point(450, 25);
            this.btnAdmin.Name = "btnAdmin";
            this.btnAdmin.Size = new System.Drawing.Size(80, 40);
            this.btnAdmin.TabIndex = 13;
            this.btnAdmin.Text = "Admin Page";
            this.btnAdmin.UseVisualStyleBackColor = true;
            this.btnAdmin.Click += new System.EventHandler(this.btnAdmin_Click);
            // 
            // btn5050
            // 
            this.btn5050.BackColor = System.Drawing.Color.SteelBlue;
            this.btn5050.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn5050.ForeColor = System.Drawing.Color.White;
            this.btn5050.Location = new System.Drawing.Point(250, 345);
            this.btn5050.Margin = new System.Windows.Forms.Padding(2);
            this.btn5050.Name = "btn5050";
            this.btn5050.Size = new System.Drawing.Size(120, 35);
            this.btn5050.TabIndex = 14;
            this.btn5050.Text = "50/50";
            this.btn5050.UseVisualStyleBackColor = true;
            this.btn5050.Click += new System.EventHandler(this.btn5050_Click);
            // 
            // btnSpeedQuiz
            // 
            this.btnSpeedQuiz.Location = new System.Drawing.Point(30, 50);
            this.btnSpeedQuiz.Name = "btnSpeedQuiz";
            this.btnSpeedQuiz.Size = new System.Drawing.Size(110, 30);
            this.btnSpeedQuiz.TabIndex = 15;
            this.btnSpeedQuiz.Text = "special quiz";
            this.btnSpeedQuiz.UseVisualStyleBackColor = true;
            this.btnSpeedQuiz.Click += new System.EventHandler(this.btnSpeedQuiz_Click);
            // 
            // quizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(700, 430);
            this.Controls.Add(this.btnSpeedQuiz);
            this.Controls.Add(this.btn5050);
            this.Controls.Add(this.btnAdmin);
            this.Controls.Add(this.btnShowLeaderboard);
            this.Controls.Add(this.lblQuestionTime);
            this.Controls.Add(this.lblQuizTime);
            this.Controls.Add(this.btnSkipQuestion);
            this.Controls.Add(this.lblScore);
            this.Controls.Add(this.btnScience);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnGeneral);
            this.Controls.Add(this.btnAnswer4);
            this.Controls.Add(this.btnAnswer3);
            this.Controls.Add(this.btnAnswer2);
            this.Controls.Add(this.btnAnswer1);
            this.Controls.Add(this.lblQuestion);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "quizForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "+";
            this.Load += new System.EventHandler(this.quizForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblQuestion;
        private System.Windows.Forms.Button btnAnswer1;
        private System.Windows.Forms.Button btnAnswer2;
        private System.Windows.Forms.Button btnAnswer3;
        private System.Windows.Forms.Button btnAnswer4;
        private System.Windows.Forms.Button btnGeneral;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnScience;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.Button btnSkipQuestion;
        private System.Windows.Forms.Timer QuizTimer;
        private System.Windows.Forms.Label lblQuizTime;
        private System.Windows.Forms.Label lblQuestionTime;
        private System.Windows.Forms.Button btnShowLeaderboard;
        private System.Windows.Forms.Button btnAdmin;
        private System.Windows.Forms.Button btn5050;
        private System.Windows.Forms.Button btnSpeedQuiz;
    }
}