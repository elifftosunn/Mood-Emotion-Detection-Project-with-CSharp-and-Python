namespace designProject.Views
{
    partial class SignUpForm
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
            components = new System.ComponentModel.Container();
            labelCreateAnAccount = new Label();
            textBoxFName = new TextBox();
            textBoxLName = new TextBox();
            textBoxEmail = new TextBox();
            textBoxPhoneNumber = new TextBox();
            textBoxPassword = new TextBox();
            textBoxConfirmPassword = new TextBox();
            signUpBtn = new Button();
            label2 = new Label();
            btnLogin = new Button();
            errorProviderFName = new ErrorProvider(components);
            errorProviderLName = new ErrorProvider(components);
            errorProviderEmail = new ErrorProvider(components);
            errorProviderPhoneNumber = new ErrorProvider(components);
            errorProviderPassword = new ErrorProvider(components);
            errorProviderConfirmPassword = new ErrorProvider(components);
            ((System.ComponentModel.ISupportInitialize)errorProviderFName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderLName).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderEmail).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPhoneNumber).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPassword).BeginInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderConfirmPassword).BeginInit();
            SuspendLayout();
            // 
            // labelCreateAnAccount
            // 
            labelCreateAnAccount.AutoSize = true;
            labelCreateAnAccount.Font = new Font("Arial Narrow", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelCreateAnAccount.Location = new Point(123, 34);
            labelCreateAnAccount.Name = "labelCreateAnAccount";
            labelCreateAnAccount.Size = new Size(216, 33);
            labelCreateAnAccount.TabIndex = 1;
            labelCreateAnAccount.Text = "Create an account";
            labelCreateAnAccount.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBoxFName
            // 
            textBoxFName.BackColor = SystemColors.Window;
            textBoxFName.BorderStyle = BorderStyle.FixedSingle;
            textBoxFName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxFName.ForeColor = Color.DarkGray;
            textBoxFName.Location = new Point(69, 92);
            textBoxFName.MaxLength = 50;
            textBoxFName.Name = "textBoxFName";
            textBoxFName.Size = new Size(335, 30);
            textBoxFName.TabIndex = 2;
            textBoxFName.Text = "Enter your firstname";
            textBoxFName.Enter += textBoxFName_Enter;
            // 
            // textBoxLName
            // 
            textBoxLName.BackColor = SystemColors.Window;
            textBoxLName.BorderStyle = BorderStyle.FixedSingle;
            textBoxLName.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxLName.ForeColor = Color.DarkGray;
            textBoxLName.Location = new Point(69, 147);
            textBoxLName.Name = "textBoxLName";
            textBoxLName.Size = new Size(335, 30);
            textBoxLName.TabIndex = 3;
            textBoxLName.Text = "Enter your lastname";
            textBoxLName.Enter += textBoxLName_Enter;
            // 
            // textBoxEmail
            // 
            textBoxEmail.BorderStyle = BorderStyle.FixedSingle;
            textBoxEmail.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxEmail.ForeColor = Color.DarkGray;
            textBoxEmail.Location = new Point(69, 207);
            textBoxEmail.Name = "textBoxEmail";
            textBoxEmail.Size = new Size(335, 30);
            textBoxEmail.TabIndex = 4;
            textBoxEmail.Text = "Enter your email";
            textBoxEmail.Enter += textBoxEmail_Enter;
            // 
            // textBoxPhoneNumber
            // 
            textBoxPhoneNumber.BorderStyle = BorderStyle.FixedSingle;
            textBoxPhoneNumber.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxPhoneNumber.ForeColor = Color.DarkGray;
            textBoxPhoneNumber.Location = new Point(69, 262);
            textBoxPhoneNumber.Name = "textBoxPhoneNumber";
            textBoxPhoneNumber.Size = new Size(335, 30);
            textBoxPhoneNumber.TabIndex = 5;
            textBoxPhoneNumber.Text = "Enter your phone number";
            textBoxPhoneNumber.Enter += textBoxPhoneNumber_Enter;
            // 
            // textBoxPassword
            // 
            textBoxPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxPassword.ForeColor = Color.DarkGray;
            textBoxPassword.Location = new Point(69, 313);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(335, 30);
            textBoxPassword.TabIndex = 6;
            textBoxPassword.Text = "Enter your password";
            textBoxPassword.Enter += textBoxPassword_Enter;
            // 
            // textBoxConfirmPassword
            // 
            textBoxConfirmPassword.BorderStyle = BorderStyle.FixedSingle;
            textBoxConfirmPassword.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            textBoxConfirmPassword.ForeColor = Color.DarkGray;
            textBoxConfirmPassword.Location = new Point(69, 363);
            textBoxConfirmPassword.Name = "textBoxConfirmPassword";
            textBoxConfirmPassword.Size = new Size(335, 30);
            textBoxConfirmPassword.TabIndex = 7;
            textBoxConfirmPassword.Text = "Confirm password";
            textBoxConfirmPassword.Enter += textBoxConfirmPassword_Enter;
            // 
            // signUpBtn
            // 
            signUpBtn.BackColor = Color.White;
            signUpBtn.Font = new Font("Arial Narrow", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            signUpBtn.Location = new Point(69, 419);
            signUpBtn.Name = "signUpBtn";
            signUpBtn.Size = new Size(335, 41);
            signUpBtn.TabIndex = 8;
            signUpBtn.Text = "Sign Up";
            signUpBtn.UseVisualStyleBackColor = false;
            signUpBtn.Click += signUpBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Narrow", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            label2.Location = new Point(69, 483);
            label2.Name = "label2";
            label2.Size = new Size(174, 22);
            label2.TabIndex = 9;
            label2.Text = "Already have an account?";
            // 
            // btnLogin
            // 
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Arial Narrow", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(249, 480);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(71, 29);
            btnLogin.TabIndex = 10;
            btnLogin.Text = "Login";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // errorProviderFName
            // 
            errorProviderFName.ContainerControl = this;
            // 
            // errorProviderLName
            // 
            errorProviderLName.ContainerControl = this;
            // 
            // errorProviderEmail
            // 
            errorProviderEmail.ContainerControl = this;
            // 
            // errorProviderPhoneNumber
            // 
            errorProviderPhoneNumber.ContainerControl = this;
            // 
            // errorProviderPassword
            // 
            errorProviderPassword.ContainerControl = this;
            // 
            // errorProviderConfirmPassword
            // 
            errorProviderConfirmPassword.ContainerControl = this;
            // 
            // SignUpForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(202, 180, 133);
            ClientSize = new Size(476, 534);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(signUpBtn);
            Controls.Add(textBoxConfirmPassword);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxPhoneNumber);
            Controls.Add(textBoxEmail);
            Controls.Add(textBoxLName);
            Controls.Add(textBoxFName);
            Controls.Add(labelCreateAnAccount);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "SignUpForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SignUp";
            ((System.ComponentModel.ISupportInitialize)errorProviderFName).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderLName).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderEmail).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPhoneNumber).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderPassword).EndInit();
            ((System.ComponentModel.ISupportInitialize)errorProviderConfirmPassword).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label labelCreateAnAccount;
        private TextBox textBoxFName;
        private TextBox textBoxLName;
        private TextBox textBoxEmail;
        private TextBox textBoxPhoneNumber;
        private TextBox textBoxPassword;
        private TextBox textBoxConfirmPassword;
        private Button signUpBtn;
        private Label label2;
        private Button btnLogin;
        private ErrorProvider errorProviderFName;
        private ErrorProvider errorProviderLName;
        private ErrorProvider errorProviderEmail;
        private ErrorProvider errorProviderPhoneNumber;
        private ErrorProvider errorProviderPassword;
        private ErrorProvider errorProviderConfirmPassword;
    }
}