namespace designProject.Views
{
    partial class LoginForm
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
            labelLogin = new Label();
            textBoxEmail = new TextBox();
            textBoxPassword = new TextBox();
            loginBtn = new Button();
            btnLogin = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            btnTogglePassword = new Button();
            SuspendLayout();
            // 
            // labelLogin
            // 
            labelLogin.AutoSize = true;
            labelLogin.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelLogin.Location = new Point(194, 46);
            labelLogin.Name = "labelLogin";
            labelLogin.Size = new Size(77, 33);
            labelLogin.TabIndex = 2;
            labelLogin.Text = "Login";
            labelLogin.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxEmail.ForeColor = Color.DarkGray;
            textBoxEmail.Location = new Point(76, 115);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(335, 30);
            textBoxEmail.TabIndex = 5;
            textBoxEmail.Text = "Enter your email";
            textBoxEmail.Enter += textBoxEmail_Enter;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxPassword.ForeColor = Color.DarkGray;
            textBoxPassword.Location = new Point(76, 173);
            textBoxPassword.MaxLength = 50;
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.PasswordChar = '●';
            textBoxPassword.Size = new Size(335, 30);
            textBoxPassword.TabIndex = 7;
            textBoxPassword.Text = "Enter your password";
            textBoxPassword.Enter += textBoxPassword_Enter;
            // 
            // loginBtn
            // 
            loginBtn.BackColor = Color.White;
            loginBtn.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            loginBtn.Location = new Point(76, 261);
            loginBtn.Name = "loginBtn";
            loginBtn.Size = new Size(335, 41);
            loginBtn.TabIndex = 9;
            loginBtn.Text = "Login";
            loginBtn.UseVisualStyleBackColor = false;
            loginBtn.Click += loginBtn_Click;
            // 
            // btnLogin
            // 
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(76, 217);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(335, 29);
            btnLogin.TabIndex = 11;
            btnLogin.Text = "Şifrenizi mi unuttunuz?";
            btnLogin.TextAlign = ContentAlignment.MiddleLeft;
            btnLogin.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(202, 180, 133);
            panel1.Location = new Point(0, 356);
            panel1.Name = "panel1";
            panel1.Size = new Size(476, 138);
            panel1.TabIndex = 12;
            panel1.Paint += panel1_Paint;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 491);
            panel2.Name = "panel2";
            panel2.Size = new Size(476, 43);
            panel2.TabIndex = 13;
            // 
            // btnTogglePassword
            // 
            btnTogglePassword.BackColor = SystemColors.Window;
            btnTogglePassword.FlatStyle = FlatStyle.Flat;
            btnTogglePassword.Location = new Point(376, 173);
            btnTogglePassword.Name = "btnTogglePassword";
            btnTogglePassword.Size = new Size(35, 30);
            btnTogglePassword.TabIndex = 14;
            btnTogglePassword.Text = "👁️";
            btnTogglePassword.UseVisualStyleBackColor = false;
            btnTogglePassword.Click += btnTogglePassword_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(202, 180, 133);
            ClientSize = new Size(476, 534);
            Controls.Add(btnTogglePassword);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(btnLogin);
            Controls.Add(loginBtn);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxEmail);
            Controls.Add(labelLogin);
            Name = "LoginForm";
            Text = "LoginForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelLogin;
        private TextBox textBoxEmail;
        private TextBox textBoxPassword;
        private Button loginBtn;
        private Button btnLogin;
        private Panel panel1;
        private Panel panel2;
        private Button btnTogglePassword;
    }
}