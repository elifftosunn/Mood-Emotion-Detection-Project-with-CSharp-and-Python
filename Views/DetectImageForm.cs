using designProject.Views;
using Microsoft.VisualBasic.Logging;
using MoodSyncProject.Controllers;
using MoodSyncProject.Models;
using MoodSyncProject.Views;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
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
        public DBConnection conn;
        private SqlDataReader dataReader;
        private Music music;
        private List<Music> musicList;
        public LoginForm login;
        public string logoutTime;
        public string genreID;
        private string ImagePath;
        public string mood;
        public int userID;
        private UserDetailForm userdetailform;
        public DetectImageForm(LoginForm loginForm)
        {
            InitializeComponent();
            this.login = loginForm;
            this.userID = login.getUserID();
            this.conn = new DBConnection();


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
                ImagePath = resultImagePath.Split(",")[0];
                mood = resultImagePath.Split(",")[1].Trim();
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
                    new SqlParameter("@_userID", System.Data.SqlDbType.Int){Value = userID},
                    new SqlParameter ("@_mood", System.Data.SqlDbType.VarChar) {Value = mood },
                    new SqlParameter("@_detectionTime", System.Data.SqlDbType.DateTime) {Value = DateTime.Now},
            };
            int res = conn.ExecuteNonQuery(query, parameters);
            if (res > 0)
            {
                addPanelForMusics(mood);
            }
            else
            {
                Debug.WriteLine($"Image: {ImagePath}\nMood: {mood}\nVeritabanýna kayýt edilemedi!");
            }
        }
        private void panelForMusicClick(object sender, EventArgs e)
        {
            // Actions to be performed during click
            Panel clickedPanel = sender as Panel;
            if (clickedPanel != null)
            {
                var musicData = clickedPanel.Tag as Tuple<string, string>;
                if (musicData != null)
                {
                    string musicName = musicData.Item1;
                    string musicArtist = musicData.Item2;
                    string genreIDQuery = "SELECT genreID FROM Musics WHERE track_name=@_trackName AND track_artist=@_trackArtist";
                    SqlParameter[] parametersForGenreID =
                    {
                        new SqlParameter("@_trackName", SqlDbType.VarChar) {Value = musicName},
                        new SqlParameter("@_trackArtist", SqlDbType.VarChar) {Value = musicArtist}
                    };

                    SqlDataReader reader = conn.ExecuteQueryWithReader(genreIDQuery, parametersForGenreID);
                    if (reader.Read())
                    {
                        genreID = reader["genreID"].ToString();
                        Debug.WriteLine($"genreID: {genreID}\nMood: {mood}\nMusic: {musicName}\nArtist: {musicArtist}");
                    }
                    string query = "INSERT INTO MusicRecommendations VALUES (@_userID, @_genreID, @_recommendationTime, @_reason)";
                    SqlParameter[] parameters = {
                        new SqlParameter("@_userID", SqlDbType.Int){Value = userID},
                        new SqlParameter("@_genreID", SqlDbType.Int) {Value = genreID},
                        new SqlParameter("@_recommendationTime", SqlDbType.DateTime) {Value = DateTime.Now},
                        new SqlParameter("@_reason", SqlDbType.VarChar){Value = "Was added because the mode was "+mood}
                    };
                    int res = conn.ExecuteNonQuery(query, parameters);
                    if (res > 0)
                    {
                        Debug.WriteLine("Added record on MusicRecommendations table");
                    }
                    else
                    {
                        Debug.WriteLine("Can't add record on MusicRecommendations table");
                    }

                }
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
                    BackColor = Color.FromArgb(202, 180, 133), // Default color
                    Location = new Point(3, 58),
                    Name = "panelForMusics",
                    Size = new Size(573, 70),
                    TabIndex = 0,
                    Tag = new Tuple<string, string>(music.getName(), music.getArtist())
                };

                // Assign mouse events
                panelForMusics.MouseEnter += panelForMusic_MouseEnter;
                panelForMusics.MouseLeave += panelForMusic_MouseLeave;
                panelForMusics.Click += panelForMusic_Click;

                // Add label on panel
                Label musicLabel = new Label
                {
                    Text = $"{music.getArtist()} - {music.getName()}",
                    AutoSize = true,
                    ForeColor = Color.White,
                    Location = new Point(10, 10)
                };
                panelForMusics.Controls.Add(musicLabel);
                flowLayoutPanelForMusics.Controls.Add(panelForMusics);
            }
        }
        private void panelForMusic_MouseEnter(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(255, 200, 150); // set hover color
            }
        }

        private void panelForMusic_MouseLeave(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(202, 180, 133); // convert original color
            }
        }

        private void panelForMusic_Click(object sender, EventArgs e)
        {
            Panel panel = sender as Panel;
            if (panel != null)
            {
                panel.BackColor = Color.FromArgb(255, 150, 100); // change color after click
            }

            // Call the existing click function
            panelForMusicClick(sender, e);
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
            Debug.WriteLine("*********** LOGOUT *************");
            Debug.WriteLine($"userID: {userID}");
            SqlParameter[] sessionParameters =
            {
                    new SqlParameter("@_userID", SqlDbType.Int) {Value = userID},
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
        private void btnUserDetails_Click(object sender, EventArgs e)
        {
            this.Hide();
            userdetailform = new UserDetailForm(this);
            userdetailform.Show();
        }
    }
}
