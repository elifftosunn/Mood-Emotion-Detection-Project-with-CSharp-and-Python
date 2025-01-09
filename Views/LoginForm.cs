using designProject.Models;
using Microsoft.VisualBasic.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace designProject.Views
{
    public partial class LoginForm : Form
    {
        private int userID;
        private string email, password;
        private bool isPasswordVisible = false;
        private User user;
        private bool userCheck;
        private int remainingPassword = 3;
        private string query;
        private DBConnection connection;
        private SqlDataReader reader;
        public string loginTime;
        private DetectImageForm detectImageForm;
        public SignUpForm signUpForm;
        public LoginForm(SignUpForm _signUpForm)
        {
            InitializeComponent();
            signUpForm = _signUpForm;
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            this.email = textBoxEmail.Text.ToString().Trim().ToLower();
            this.password = textBoxPassword.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(this.email) || string.IsNullOrWhiteSpace(this.password))
            {
                MessageBox.Show("Email ve şifre alanları boş bırakılamaz!", "Null Email or Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // user validation
            this.user = new User(this.email, this.password);
            this.userCheck = this.user.VerifyLogin();

            if (userCheck)
            {
                loginTime = DateTime.Now.ToString();
                MessageBox.Show("Resim tespit sayfasına yönlendiriliyorsunuz...", "Detect Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.query = @"SELECT userID FROM Users WHERE email = @_email";
                SqlParameter[] parameters = {
                    new SqlParameter("@_email", SqlDbType.VarChar) { Value = this.email}
                };
                this.connection = new DBConnection();
                this.reader = this.connection.ExecuteQueryWithReader(query, parameters);
                if (reader.Read()) 
                {
                    this.userID = Convert.ToInt32(reader["userID"]);
                    Thread.Sleep(500);
                    this.detectImageForm = new DetectImageForm(this);
                    this.detectImageForm.ShowDialog();
                    this.Close();
                }
            }
            else
            {
                remainingPassword--;
                if (remainingPassword > 0)
                {
                    MessageBox.Show($"Şifreyi hatalı girdiniz. Kalan deneme hakkınız: {remainingPassword}", "Wrong Password!",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBoxPassword.Focus();
                }
                else
                {
                    MessageBox.Show("Hakkınız bitti! Hesabınız kilitlendi.", "Account Locked",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    loginBtn.Enabled = false; // disabling the login button
                }
            }
        }
        public int getUserID()
        {
            return this.userID;
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            textBoxEmail.Text = string.Empty;
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            textBoxPassword.Text = string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            // Graphics nesnesini al
            Graphics g = e.Graphics;

            // Üçgenin köşe noktalarını tanımla
            Point[] trianglePoints = {
            new Point(0, 0),            // Sol üst köşe
            new Point(0, panel1.Height), // Sol alt köşe
            new Point(panel1.Width, panel1.Height) // Sağ alt köşe
            };

            // Üçgeni çiz
            using (Brush brush = new SolidBrush(Color.White)) // Üçgenin dolgusu
            {
                g.FillPolygon(brush, trianglePoints); // Dolu üçgen
            }
        }

        private void btnTogglePassword_Click(object sender, EventArgs e)
        {
            // Change password display status
            this.isPasswordVisible = !this.isPasswordVisible;

            if (this.isPasswordVisible)
            {
                textBoxPassword.PasswordChar = '\0'; // show password
                btnTogglePassword.Text = "🙈";  
            }
            else
            {
                textBoxPassword.PasswordChar = '●'; // hidden password
                btnTogglePassword.Text = "👁️";
            }

            textBoxPassword.Focus(); 
        }
    }
}
