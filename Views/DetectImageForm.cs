using designProject.Models;
using designProject.Views;
using Microsoft.VisualBasic.Logging;
using MoodSyncProject.Models;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace designProject
{
    public partial class DetectImageForm : Form
    {
        private string yolo_detectPyPath;
        private string imagePath;
        private OpenFileDialog openFileDialog;
        private string resultImagePath;
        private string pythonExe;
        private string outputPath;
        private DBConnection conn;
        private SqlDataReader dataReader;
        private Music music;
        private List<Music> musicList;
        private LoginForm login;
        public string logoutTime;

        public DetectImageForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.login = loginForm;
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                yolo_detectPyPath = @"C:\Users\dptos\source\repos\designProject\designProject\yolo_detect.py";

                // run python script and pull the detected image path 
                resultImagePath = RunPythonScript(yolo_detectPyPath, imagePath);
                string ImagePath = resultImagePath.Split(",")[0];
                string mood = resultImagePath.Split(",")[1].Trim();
                SaveUserMoodHistory(mood, ImagePath);

                // show the detected image on Picturebox
                if (File.Exists(ImagePath))
                {
                    uploadImgPictureBox.Image = System.Drawing.Image.FromFile(ImagePath);
                    uploadImgPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show($"Detection failed. File not found: {ImagePath}");
                }
            }
        }

        private void SaveUserMoodHistory(string mood, string ImagePath)
        {
            string query = "INSERT INTO MoodHistory VALUES (@_userID, @_mood, @_detectionTime)";
            SqlParameter[] parameters =
            {
                    new SqlParameter("@_userID", System.Data.SqlDbType.Int){Value = login.getUserID()},
                    new SqlParameter ("@_mood", System.Data.SqlDbType.VarChar) {Value = mood },
                    new SqlParameter("@_detectionTime", System.Data.SqlDbType.DateTime) {Value = DateTime.Now},
                };
            conn = new DBConnection();
            int res = conn.ExecuteNonQuery(query, parameters);
            if (res > 0)
            {
                //MessageBox.Show("Tespit veritabanýna baþarýlý bir þekilde kayýt edildi.","Detection",
                //    MessageBoxButtons.OK, MessageBoxIcon.Information);
                addPanelForMusics(mood);
            }
            else
            {
                Debug.WriteLine($"Image: {ImagePath}\nMood: {mood}\nVeritabanýna kayýt edilemedi!");
            }
        }
        private void panelForMusicClick(object sender, EventArgs e)
        {
            // Týklama sýrasýnda yapýlacak iþlemler
            Panel clickedPanel = sender as Panel;
            if (clickedPanel != null)
            {
                MessageBox.Show("Panel týklandý: " + clickedPanel.Name);
            }
        }
        private void addPanelForMusics(string mood)
        {
            music = new Music(mood);
            musicList = music.getMusicList();
            foreach (var music in musicList)
            {
                Panel panelForMusics = new Panel
                {
                    BackColor = Color.FromArgb(202, 180, 133),
                    Location = new Point(3, 58), // Default location, will be organized within the FlowLayoutPanel 
                    Name = "panelForMusics",
                    Size = new Size(573, 70),
                    TabIndex = 0
                };
                panelForMusics.Click += panelForMusicClick; // new EventHandler(panelForMusicClick)
                Label lblMusicName = new Label
                {
                    Text = music.getName(),
                    Location = new Point(10, 10),
                    AutoSize = true
                };
                Label lblArtist = new Label
                {
                    Text = "Artist: " + music.getArtist(),
                    Location = new Point(10, lblMusicName.Location.Y + lblMusicName.Height + 5), // lblMusicName'in altýnda 5 piksel boþluk
                    AutoSize = true
                };

                panelForMusics.Controls.Add(lblArtist);
                panelForMusics.Controls.Add(lblMusicName);

                flowLayoutPanelForMusics.Controls.Add(panelForMusics);
            }
        }

        private string ReadPythonOutput(string outputFilePath)
        {
            if (!File.Exists(outputFilePath))
                throw new FileNotFoundException("Python output file not found!");

            return File.ReadAllText(outputFilePath).Trim();  // read and return the content of file
        }

        private string RunPythonScript(string scriptPath, string imagePath)
        {
            pythonExe = @"C:\Users\dptos\AppData\Local\Programs\Python\Python310\python.exe";

            string outputFilePath = Path.Combine(Path.GetDirectoryName(scriptPath), "detected_images\\output.txt");
            try
            {
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = pythonExe,
                    Arguments = $"{scriptPath} \"{imagePath}\"",
                    RedirectStandardOutput = false,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };

                using (Process process = Process.Start(start))
                {
                    process.WaitForExit();
                }
                return ReadPythonOutput(outputFilePath);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
                return string.Empty;
            }
        }
        private void btnLogout_Click(object sender, EventArgs e)
        {
            logoutTime = DateTime.Now.ToString();
            string sessionQuery = "INSERT INTO Sessions VALUES (@_userID, @_loginTime, @_logoutTime)";
            SqlParameter[] sessionParameters =
            {
                    new SqlParameter("@_userID", SqlDbType.Int) {Value = login.getUserID()},
                    new SqlParameter("@_loginTime", SqlDbType.DateTime) {Value = login.loginTime},
                    new SqlParameter("@_logoutTime", SqlDbType.DateTime) {Value = logoutTime}
            };
            int res = conn.ExecuteNonQuery(sessionQuery, sessionParameters);
            if (res > 0)
            {
                Debug.WriteLine("Session bilgileri baþarýyla kaydedildi.");
            }
            else
            {
                Debug.WriteLine("Session bilgileri kaydedilemedi");
            }
            this.Close();
        }
    }
}
