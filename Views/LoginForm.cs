using designProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace designProject.Views
{
    public partial class LoginForm : Form
    {
        private string email, password;
        private bool isPasswordVisible = false;
        private User user;
        private bool userCheck;
        private int remainingPassword = 3;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            email = textBoxEmail.Text.ToString().Trim();
            password = textBoxPassword.Text.ToString().Trim();

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Email ve şifre alanları boş bırakılamaz!", "Null Email or Password",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // user validation
            user = new User(email, password);
            userCheck = user.VerifyLogin();

            if (userCheck)
            {
                MessageBox.Show("Resim tespit sayfasına yönlendiriliyorsunuz...", "Detect Image",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                Thread.Sleep(500);
                DetectImageForm detectImageForm = new DetectImageForm();
                detectImageForm.Show();
                this.Hide();
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
            // Şifre gösterim durumunu değiştir
            isPasswordVisible = !isPasswordVisible;

            if (isPasswordVisible)
            {
                textBoxPassword.PasswordChar = '\0'; // Şifreyi göster
                btnTogglePassword.Text = "🙈";  // Göz kapa simgesi
            }
            else
            {
                textBoxPassword.PasswordChar = '●'; // Şifreyi gizle
                btnTogglePassword.Text = "👁️"; // Göz simgesi
            }

            // Kullanıcının metni etkilenmez, hiçbir veri silinmez
            textBoxPassword.Focus(); // Kullanıcı deneyimi için odak şifre alanında kalır
        }
    }
}
