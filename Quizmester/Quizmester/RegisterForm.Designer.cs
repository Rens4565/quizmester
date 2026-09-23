namespace Quizmester
{
    partial class RegisterForm
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
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txbNewPassword = new System.Windows.Forms.TextBox();
            this.txbNewUsername = new System.Windows.Forms.TextBox();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnGoToLogin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(392, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 20);
            this.label3.TabIndex = 10;
            this.label3.Text = "Password";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(385, 123);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 20);
            this.label2.TabIndex = 9;
            this.label2.Text = "UserName";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(385, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 20);
            this.label1.TabIndex = 8;
            this.label1.Text = "Register";
            // 
            // txbNewPassword
            // 
            this.txbNewPassword.Location = new System.Drawing.Point(389, 196);
            this.txbNewPassword.Name = "txbNewPassword";
            this.txbNewPassword.Size = new System.Drawing.Size(100, 26);
            this.txbNewPassword.TabIndex = 7;
            // 
            // txbNewUsername
            // 
            this.txbNewUsername.Location = new System.Drawing.Point(389, 146);
            this.txbNewUsername.Name = "txbNewUsername";
            this.txbNewUsername.Size = new System.Drawing.Size(100, 26);
            this.txbNewUsername.TabIndex = 6;
            // 
            // btnRegister
            // 
            this.btnRegister.Location = new System.Drawing.Point(389, 228);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(100, 37);
            this.btnRegister.TabIndex = 11;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = true;
            this.btnRegister.Click += new System.EventHandler(this.btnRegister_Click);
            // 
            // btnGoToLogin
            // 
            this.btnGoToLogin.Location = new System.Drawing.Point(388, 282);
            this.btnGoToLogin.Name = "btnGoToLogin";
            this.btnGoToLogin.Size = new System.Drawing.Size(82, 74);
            this.btnGoToLogin.TabIndex = 13;
            this.btnGoToLogin.Text = "already have an account";
            this.btnGoToLogin.UseVisualStyleBackColor = true;
            this.btnGoToLogin.Click += new System.EventHandler(this.btnGoToLogin_Click);
            // 
            // RegisterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnGoToLogin);
            this.Controls.Add(this.btnRegister);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txbNewPassword);
            this.Controls.Add(this.txbNewUsername);
            this.Name = "RegisterForm";
            this.Text = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txbNewPassword;
        private System.Windows.Forms.TextBox txbNewUsername;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.Button btnGoToLogin;
    }
}