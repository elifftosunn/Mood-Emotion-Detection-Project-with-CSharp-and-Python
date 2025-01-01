using designProject.Models;
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
        public DetectImageForm()
        {
            InitializeComponent();
        }

        private void btnDetect_Click(object sender, EventArgs e)
        {
            openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                imagePath = openFileDialog.FileName;
                yolo_detectPyPath = @"C:\Users\dptos\source\repos\designProject\designProject\yolo_detect.py";

                // Python betiðini çalýþtýr ve tespit edilen resim yolunu al
                resultImagePath = RunPythonScript(yolo_detectPyPath, imagePath);

                string ImagePath = resultImagePath.Split(",")[0];
                string mood = resultImagePath.Split(",")[1].Trim();
                string query = "INSERT INTO MoodHistory VALUES (@_userID, @_mood, @_detectionTime)";
                SqlParameter[] parameters =
                {
                    new SqlParameter("@_userID", System.Data.SqlDbType.Int){Value = 1},
                    new SqlParameter ("@_mood", System.Data.SqlDbType.VarChar) {Value = mood },
                    new SqlParameter("@_detectionTime", System.Data.SqlDbType.DateTime) {Value = DateTime.Now},
                };
                conn = new DBConnection();
                int res = conn.ExecuteNonQuery(query, parameters);
                if(res > 0)
                {
                    MessageBox.Show("Tespit veritabanýna baþarýlý bir þekilde kayýt edildi.","Detection",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    Debug.WriteLine($"Image: {ImagePath}\nMood: {mood}\nVeritabanýna kayýt edilemedi!");
                }
                // Tespit edilen görüntüyü PictureBox üzerinde göster
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

        private string ExtractFilePath(string raw)
        {
            string[] parts = raw.Split(' ');
            int firstColonIndex = parts[2].IndexOf(':'); // Ýlk ':'
            int secondColonIndex = parts[2].LastIndexOf(':'); // Ýlk ':' sonrasý
            // ':' iþaretine kadar olan kýsmý al
            string imagePath = parts[2].Substring(firstColonIndex - 1, secondColonIndex);
            return imagePath;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
