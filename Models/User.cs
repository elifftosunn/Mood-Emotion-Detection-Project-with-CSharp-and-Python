using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Diagnostics;
using MoodSyncProject.Controllers;

namespace designProject.Models
{
    public class User
    {
        private string firstname, lastname, email, phoneNumber, password;
        private DateTime recordTime;
        private DBConnection connection;
        private SqlDataReader dataReader;
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public string Email { get => email; set => email = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string Password { get => password; set => password = value; }
        public DateTime RecordTime { get => recordTime; set => recordTime = value; }
        public DBConnection Connection { get => connection; }
        public SqlDataReader DataReader { get => dataReader; }
        public User(string email, string password)
        {
            this.email = email;
            this.password = password;
        }
        public User(string firstname, string lastname, string email, string phoneNumber, string password,
            DateTime recordTime)
        {
            this.firstname = firstname;
            this.lastname = lastname;
            this.email = email;
            this.phoneNumber = phoneNumber;
            this.password = password;
            this.recordTime = recordTime;
        }
        public string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                // Şifreyi byte array'e dönüştür
                byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
                // Hash işlemi
                byte[] hashBytes = sha256.ComputeHash(passwordBytes);
                // Hashlenmiş byte array'i string'e dönüştür
                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Hexadecimal format
                }
                return sb.ToString();
            }
        }
        public bool VerifyLogin()
        {
            string hashedPasswordFromDb = null;
            connection = new DBConnection();
            string query = "SELECT Password FROM Users WHERE Email = @_email";
            SqlParameter[] parameters =
            {
                new SqlParameter("@_email", SqlDbType.VarChar) { Value = this.email }
            };

            try
            {
                using (dataReader = connection.ExecuteQueryWithReader(query, parameters)) // null gozukuyor
                {
                    if (dataReader.Read())
                    {
                        hashedPasswordFromDb = dataReader["Password"].ToString();
                    }
                }

                if (hashedPasswordFromDb == null)
                {
                    return false; // user not found
                }

                // Kullanıcıdan gelen şifreyi hashle ve karşılaştır
                string hashedPassword = HashPassword(this.password);

                return hashedPassword == hashedPasswordFromDb;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Hata: " + ex.Message);
                return false;
            }
        }

    }
}
