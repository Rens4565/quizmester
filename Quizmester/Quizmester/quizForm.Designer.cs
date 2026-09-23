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
            this.SuspendLayout();
            // 
            // lblQuestion
            // 
            this.lblQuestion.AutoSize = true;
            this.lblQuestion.Location = new System.Drawing.Point(240, 93);
            this.lblQuestion.Name = "lblQuestion";
            this.lblQuestion.Size = new System.Drawing.Size(36, 20);
            this.lblQuestion.TabIndex = 0;
            this.lblQuestion.Text = "test";
            // 
            // btnAnswer1
            // 
            this.btnAnswer1.Location = new System.Drawing.Point(244, 199);
            this.btnAnswer1.Name = "btnAnswer1";
            this.btnAnswer1.Size = new System.Drawing.Size(167, 39);
            this.btnAnswer1.TabIndex = 1;
            this.btnAnswer1.Text = "button1";
            this.btnAnswer1.UseVisualStyleBackColor = true;
            this.btnAnswer1.Click += new System.EventHandler(this.btnAnswer1_Click);
            // 
            // btnAnswer2
            // 
            this.btnAnswer2.Location = new System.Drawing.Point(454, 199);
            this.btnAnswer2.Name = "btnAnswer2";
            this.btnAnswer2.Size = new System.Drawing.Size(164, 39);
            this.btnAnswer2.TabIndex = 2;
            this.btnAnswer2.Text = "button2";
            this.btnAnswer2.UseVisualStyleBackColor = true;
            this.btnAnswer2.Click += new System.EventHandler(this.btnAnswer2_Click);
            // 
            // btnAnswer3
            // 
            this.btnAnswer3.Location = new System.Drawing.Point(244, 294);
            this.btnAnswer3.Name = "btnAnswer3";
            this.btnAnswer3.Size = new System.Drawing.Size(167, 39);
            this.btnAnswer3.TabIndex = 3;
            this.btnAnswer3.Text = "button3";
            this.btnAnswer3.UseVisualStyleBackColor = true;
            this.btnAnswer3.Click += new System.EventHandler(this.btnAnswer3_Click);
            // 
            // btnAnswer4
            // 
            this.btnAnswer4.Location = new System.Drawing.Point(454, 294);
            this.btnAnswer4.Name = "btnAnswer4";
            this.btnAnswer4.Size = new System.Drawing.Size(164, 39);
            this.btnAnswer4.TabIndex = 4;
            this.btnAnswer4.Text = "button4";
            this.btnAnswer4.UseVisualStyleBackColor = true;
            this.btnAnswer4.Click += new System.EventHandler(this.btnAnswer4_Click);
            // 
            // btnGeneral
            // 
            this.btnGeneral.Location = new System.Drawing.Point(49, 71);
            this.btnGeneral.Name = "btnGeneral";
            this.btnGeneral.Size = new System.Drawing.Size(89, 42);
            this.btnGeneral.TabIndex = 5;
            this.btnGeneral.Text = "General";
            this.btnGeneral.UseVisualStyleBackColor = true;
            this.btnGeneral.Click += new System.EventHandler(this.btnGeneral_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Location = new System.Drawing.Point(49, 138);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(89, 42);
            this.btnHistory.TabIndex = 6;
            this.btnHistory.Text = "history";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnScience
            // 
            this.btnScience.Location = new System.Drawing.Point(49, 199);
            this.btnScience.Name = "btnScience";
            this.btnScience.Size = new System.Drawing.Size(89, 42);
            this.btnScience.TabIndex = 7;
            this.btnScience.Text = "Science";
            this.btnScience.UseVisualStyleBackColor = true;
            this.btnScience.Click += new System.EventHandler(this.btnScience_Click);
            // 
            // lblScore
            // 
            this.lblScore.AutoSize = true;
            this.lblScore.Location = new System.Drawing.Point(628, 391);
            this.lblScore.Name = "lblScore";
            this.lblScore.Size = new System.Drawing.Size(51, 20);
            this.lblScore.TabIndex = 8;
            this.lblScore.Text = "Score";
            // 
            // btnSkipQuestion
            // 
            this.btnSkipQuestion.Location = new System.Drawing.Point(479, 402);
            this.btnSkipQuestion.Name = "btnSkipQuestion";
            this.btnSkipQuestion.Size = new System.Drawing.Size(75, 28);
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
            this.lblQuizTime.Location = new System.Drawing.Point(140, 390);
            this.lblQuizTime.Name = "lblQuizTime";
            this.lblQuizTime.Size = new System.Drawing.Size(108, 30);
            this.lblQuizTime.TabIndex = 10;
            this.lblQuizTime.Text = "quiz time";
            // 
            // lblQuestionTime
            // 
            this.lblQuestionTime.AutoSize = true;
            this.lblQuestionTime.Location = new System.Drawing.Point(240, 391);
            this.lblQuestionTime.Name = "lblQuestionTime";
            this.lblQuestionTime.Size = new System.Drawing.Size(156, 30);
            this.lblQuestionTime.TabIndex = 11;
            this.lblQuestionTime.Text = "question time";
            // 
            // quizForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "quizForm";
            this.Text = "quizForm";
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
    }
}