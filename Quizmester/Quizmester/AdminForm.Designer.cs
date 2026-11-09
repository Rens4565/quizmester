namespace Quizmester
{
    partial class AdminForm
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
            this.cmbRole = new System.Windows.Forms.ComboBox();
            this.dgvUsers = new System.Windows.Forms.DataGridView();
            this.btnChangeRole = new System.Windows.Forms.Button();
            this.btnDeleteUser = new System.Windows.Forms.Button();
            this.dgvQuestions = new System.Windows.Forms.DataGridView();
            this.txbQuestion = new System.Windows.Forms.TextBox();
            this.txbCorrect = new System.Windows.Forms.TextBox();
            this.txbWrong1 = new System.Windows.Forms.TextBox();
            this.txbWrong2 = new System.Windows.Forms.TextBox();
            this.txbWrong3 = new System.Windows.Forms.TextBox();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAddQuestion = new System.Windows.Forms.Button();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).BeginInit();
            this.SuspendLayout();
            // 
            // cmbRole
            // 
            this.cmbRole.BackColor = System.Drawing.Color.White;
            this.cmbRole.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbRole.FormattingEnabled = true;
            this.cmbRole.Items.AddRange(new object[] {
            "Users",
            "admin"});
            this.cmbRole.Location = new System.Drawing.Point(30, 290);
            this.cmbRole.Name = "cmbRole";
            this.cmbRole.Size = new System.Drawing.Size(180, 36);
            this.cmbRole.TabIndex = 0;
            // 
            // dgvUsers
            // 
            this.dgvUsers.BackgroundColor = System.Drawing.Color.White;
            this.dgvUsers.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvUsers.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvUsers.Location = new System.Drawing.Point(30, 26);
            this.dgvUsers.Name = "dgvUsers";
            this.dgvUsers.RowHeadersWidth = 62;
            this.dgvUsers.Size = new System.Drawing.Size(400, 220);
            this.dgvUsers.TabIndex = 1;
            // 
            // btnChangeRole
            // 
            this.btnChangeRole.BackColor = System.Drawing.Color.SteelBlue;
            this.btnChangeRole.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChangeRole.ForeColor = System.Drawing.Color.White;
            this.btnChangeRole.Location = new System.Drawing.Point(230, 288);
            this.btnChangeRole.Name = "btnChangeRole";
            this.btnChangeRole.Size = new System.Drawing.Size(120, 35);
            this.btnChangeRole.TabIndex = 2;
            this.btnChangeRole.Text = "change role";
            this.btnChangeRole.UseVisualStyleBackColor = true;
            this.btnChangeRole.Click += new System.EventHandler(this.btnChangeRole_Click);
            // 
            // btnDeleteUser
            // 
            this.btnDeleteUser.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteUser.ForeColor = System.Drawing.Color.White;
            this.btnDeleteUser.Location = new System.Drawing.Point(230, 335);
            this.btnDeleteUser.Name = "btnDeleteUser";
            this.btnDeleteUser.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteUser.TabIndex = 3;
            this.btnDeleteUser.Text = "Delete user";
            this.btnDeleteUser.UseVisualStyleBackColor = true;
            this.btnDeleteUser.Click += new System.EventHandler(this.btnDeleteUser_Click);
            // 
            // dgvQuestions
            // 
            this.dgvQuestions.BackgroundColor = System.Drawing.Color.White;
            this.dgvQuestions.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuestions.Location = new System.Drawing.Point(489, 26);
            this.dgvQuestions.Name = "dgvQuestions";
            this.dgvQuestions.RowHeadersWidth = 62;
            this.dgvQuestions.Size = new System.Drawing.Size(450, 220);
            this.dgvQuestions.TabIndex = 4;
            // 
            // txbQuestion
            // 
            this.txbQuestion.BackColor = System.Drawing.Color.White;
            this.txbQuestion.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txbQuestion.Location = new System.Drawing.Point(500, 288);
            this.txbQuestion.Name = "txbQuestion";
            this.txbQuestion.Size = new System.Drawing.Size(450, 34);
            this.txbQuestion.TabIndex = 5;
            // 
            // txbCorrect
            // 
            this.txbCorrect.BackColor = System.Drawing.Color.White;
            this.txbCorrect.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txbCorrect.Location = new System.Drawing.Point(500, 349);
            this.txbCorrect.Name = "txbCorrect";
            this.txbCorrect.Size = new System.Drawing.Size(450, 34);
            this.txbCorrect.TabIndex = 6;
            // 
            // txbWrong1
            // 
            this.txbWrong1.BackColor = System.Drawing.Color.White;
            this.txbWrong1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txbWrong1.Location = new System.Drawing.Point(500, 400);
            this.txbWrong1.Name = "txbWrong1";
            this.txbWrong1.Size = new System.Drawing.Size(140, 34);
            this.txbWrong1.TabIndex = 7;
            // 
            // txbWrong2
            // 
            this.txbWrong2.BackColor = System.Drawing.Color.White;
            this.txbWrong2.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txbWrong2.Location = new System.Drawing.Point(646, 400);
            this.txbWrong2.Name = "txbWrong2";
            this.txbWrong2.Size = new System.Drawing.Size(140, 34);
            this.txbWrong2.TabIndex = 8;
            // 
            // txbWrong3
            // 
            this.txbWrong3.BackColor = System.Drawing.Color.White;
            this.txbWrong3.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txbWrong3.Location = new System.Drawing.Point(792, 400);
            this.txbWrong3.Name = "txbWrong3";
            this.txbWrong3.Size = new System.Drawing.Size(140, 34);
            this.txbWrong3.TabIndex = 9;
            // 
            // cmbCategory
            // 
            this.cmbCategory.BackColor = System.Drawing.Color.White;
            this.cmbCategory.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cmbCategory.FormattingEnabled = true;
            this.cmbCategory.Items.AddRange(new object[] {
            "History",
            "Science"});
            this.cmbCategory.Location = new System.Drawing.Point(500, 440);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(200, 36);
            this.cmbCategory.TabIndex = 10;
            // 
            // btnAddQuestion
            // 
            this.btnAddQuestion.BackColor = System.Drawing.Color.SteelBlue;
            this.btnAddQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddQuestion.ForeColor = System.Drawing.Color.White;
            this.btnAddQuestion.Location = new System.Drawing.Point(706, 440);
            this.btnAddQuestion.Name = "btnAddQuestion";
            this.btnAddQuestion.Size = new System.Drawing.Size(120, 35);
            this.btnAddQuestion.TabIndex = 11;
            this.btnAddQuestion.Text = "add question";
            this.btnAddQuestion.UseVisualStyleBackColor = true;
            this.btnAddQuestion.Click += new System.EventHandler(this.btnAddQuestion_Click);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.BackColor = System.Drawing.Color.IndianRed;
            this.btnDeleteQuestion.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeleteQuestion.ForeColor = System.Drawing.Color.White;
            this.btnDeleteQuestion.Location = new System.Drawing.Point(843, 440);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(120, 35);
            this.btnDeleteQuestion.TabIndex = 12;
            this.btnDeleteQuestion.Text = "delete question";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(504, 257);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 28);
            this.label1.TabIndex = 13;
            this.label1.Text = "question";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(504, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 28);
            this.label2.TabIndex = 14;
            this.label2.Text = "Correct answer";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(504, 386);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(146, 28);
            this.label3.TabIndex = 15;
            this.label3.Text = "Wrong answers";
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ClientSize = new System.Drawing.Size(1000, 500);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.btnAddQuestion);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.txbWrong3);
            this.Controls.Add(this.txbWrong2);
            this.Controls.Add(this.txbWrong1);
            this.Controls.Add(this.txbCorrect);
            this.Controls.Add(this.txbQuestion);
            this.Controls.Add(this.dgvQuestions);
            this.Controls.Add(this.btnDeleteUser);
            this.Controls.Add(this.btnChangeRole);
            this.Controls.Add(this.dgvUsers);
            this.Controls.Add(this.cmbRole);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.MidnightBlue;
            this.Name = "AdminForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AdminForm";
            ((System.ComponentModel.ISupportInitialize)(this.dgvUsers)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuestions)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbRole;
        private System.Windows.Forms.DataGridView dgvUsers;
        private System.Windows.Forms.Button btnChangeRole;
        private System.Windows.Forms.Button btnDeleteUser;
        private System.Windows.Forms.DataGridView dgvQuestions;
        private System.Windows.Forms.TextBox txbQuestion;
        private System.Windows.Forms.TextBox txbCorrect;
        private System.Windows.Forms.TextBox txbWrong1;
        private System.Windows.Forms.TextBox txbWrong2;
        private System.Windows.Forms.TextBox txbWrong3;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAddQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}