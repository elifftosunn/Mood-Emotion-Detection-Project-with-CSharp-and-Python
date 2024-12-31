using designProject.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace designProject.Views
{
    public partial class SignUpForm : Form
    {
        private DBConnection dbConnection;
        private SqlDataReader dataReader;
        private User user;
        private string fName, lName, email, phoneNumber, password, confirmPassword;
        public SignUpForm()
        {
            InitializeComponent();
            dbConnection = new DBConnection();
        }
        private bool IsValidEmail(string email)
        {
            return email.Contains("@") && email.Contains(".");
        }
        private bool IsValidPassword(string password)
        {
            if (password.Length < 8)
                return false; // check min length

            bool hasUpperCase = password.Any(char.IsUpper); 
            bool hasLowerCase = password.Any(char.IsLower); 
            bool hasDigit = password.Any(char.IsDigit); 
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch)); // check special character

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar;
        }
        private bool CheckEmailHasOnTable(string email)
        {
            string query = "SELECT Password FROM Users WHERE Email = @Email";
            SqlParameter[] parameters =
            {
                new SqlParameter("@Email", SqlDbType.VarChar) { Value = email }
            };

            try
            {
                using (dataReader = dbConnection.ExecuteQueryWithReader(query, parameters))
                {
                    if (dataReader.Read())
                    {
                        return true;
                    }
                    return false;
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Hata: " + ex.Message);
                return false;
            }
        }

        private void signUpBtn_Click(object sender, EventArgs e)
        {
            fName = textBoxFName.Text.ToString().Trim();
            lName = textBoxLName.Text.ToString().Trim();  
            email = textBoxEmail.Text.ToString().Trim();
            phoneNumber = textBoxPhoneNumber.Text.ToString().Trim();
            password = textBoxPassword.Text.ToString().Trim();
            confirmPassword = textBoxConfirmPassword.Text.Trim();   
            if (!string.IsNullOrWhiteSpace(fName))
            {
                errorProviderFName.SetError(textBoxFName, ""); // clean error message
                fName = string.Concat(fName[0].ToString().ToUpper(), fName.AsSpan(1));
                if (!string.IsNullOrWhiteSpace(lName)) 
                {
                    errorProviderLName.SetError(textBoxLName, "");
                    lName = string.Concat(lName[0].ToString().ToUpper(), lName.AsSpan(1));
                    if (!string.IsNullOrWhiteSpace(email) && IsValidEmail(email)) 
                    {
                        errorProviderEmail.SetError(textBoxEmail, "");
                        if (!CheckEmailHasOnTable(email))
                        {
                            if (!string.IsNullOrWhiteSpace(phoneNumber) && phoneNumber.Length >= 11)
                            {
                                errorProviderPhoneNumber.SetError(textBoxPhoneNumber, "");
                                if (!string.IsNullOrWhiteSpace(password) && IsValidPassword(password))
                                {
                                    errorProviderPassword.SetError(textBoxPassword, "");
                                    if (!string.IsNullOrWhiteSpace(confirmPassword) && IsValidPassword(confirmPassword))
                                    {
                                        errorProviderConfirmPassword.SetError(textBoxConfirmPassword, "");
                                        if (password == confirmPassword)
                                        {
                                            user = new User(fName, lName, email, phoneNumber, password, DateTime.Now);
                                            string hashedPassword = user.HashPassword(password);
                                            string query = "INSERT INTO Users VALUES (@_firstname,@_lastname, @_email, @_phoneNumber, @_password, @_recordTime)";
                                            SqlParameter[] parameters = {
                                                new SqlParameter("@_firstname", SqlDbType.VarChar){Value = fName},
                                                new SqlParameter("@_lastname", SqlDbType.VarChar) {Value = lName},
                                                new SqlParameter("@_email", SqlDbType.VarChar){Value=email},
                                                new SqlParameter("@_phoneNumber", SqlDbType.VarChar) {Value=phoneNumber},
                                                new SqlParameter("@_password", SqlDbType.VarChar) {Value=hashedPassword},
                                                new SqlParameter("@_RecordTime", SqlDbType.DateTime) {Value = DateTime.Now}
                                            };

                                            int res = dbConnection.ExecuteNonQuery(query, parameters);
                                            if (res > 0) 
                                            {
                                                MessageBox.Show("Record added successfully!", "Add Record",
                                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                Thread.Sleep(1000);
                                                LoginForm loginForm = new LoginForm();
                                                loginForm.Show();
                                                this.Hide();
                                            }else
                                                MessageBox.Show("Couldn't add user!", "Error",
                                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                                        } else
                                            MessageBox.Show("Şifreler aynı olmalıdır!");

                                    }
                                    else
                                    {
                                        errorProviderConfirmPassword.SetError(textBoxConfirmPassword, "Şifreniz doğru formatta olmalıdır!");
                                        textBoxConfirmPassword.Focus();
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Şifreniz en az 8 karakter uzunluğunda, büyük/küçük harf ve en az 1 rakam içermelidir!",
                                            "Password Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    errorProviderPassword.SetError(textBoxPassword, "Şifreniz doğru formatta olmalıdır!");
                                    textBoxPassword.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("Telefon numaranız en az 11 karakter uzunlugunda olmalıdır!",
                                       "Phone Number Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                errorProviderPhoneNumber.SetError(textBoxPhoneNumber, "En az 11 karakter uzunlugunda olmalıdır!");
                                textBoxPhoneNumber.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Girdiğiniz mail adresine ait kullanıcı veritabanında bulunmaktadır.\nGiriş sayfasına yönlendiriliyorsunuz...",
                                "User Found!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Thread.Sleep(1000);
                            LoginForm loginForm = new LoginForm();
                            loginForm.Show();
                            this.Hide();
                        }

                    }
                    else
                    {
                        MessageBox.Show("Mail adresiniz formata uygun olmalıdır!\nÖrneğin: username@gmail.com",
                                "Email Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        errorProviderEmail.SetError(textBoxEmail, "Alanı email formatına uygun doldurunuz!");
                        textBoxEmail.Focus();
                    }
                }
                else
                {
                    errorProviderLName.SetError(textBoxLName, "Bu alan boş bırakılamaz!");
                    textBoxLName.Focus();
                }

            }
            else
            {
                errorProviderFName.SetError(textBoxFName, "Bu alan boş bırakılamaz!");
                textBoxFName.Focus();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            loginForm.Show();
            this.Hide();
        }


        private void textBoxFName_Enter(object sender, EventArgs e)
        {
            textBoxFName.Text = string.Empty;

        }

        private void textBoxLName_Enter(object sender, EventArgs e)
        {
            textBoxLName.Text = string.Empty;
        }

        private void textBoxEmail_Enter(object sender, EventArgs e)
        {
            textBoxEmail.Text = string.Empty;
        }

        private void textBoxPhoneNumber_Enter(object sender, EventArgs e)
        {
            textBoxPhoneNumber.Text = string.Empty;
        }

        private void textBoxPassword_Enter(object sender, EventArgs e)
        {
            textBoxPassword.Text = string.Empty;
        }

        private void textBoxConfirmPassword_Enter(object sender, EventArgs e)
        {
            textBoxConfirmPassword.Text = string.Empty;

        }
    }
}
