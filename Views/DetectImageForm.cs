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

                // Tespit edilen görüntüyü PictureBox üzerinde göster
                if (File.Exists(resultImagePath))
                {
                    uploadImgPictureBox.Image = System.Drawing.Image.FromFile(resultImagePath);
                    uploadImgPictureBox.SizeMode = PictureBoxSizeMode.Zoom;
                }
                else
                {
                    MessageBox.Show($"Detection failed. File not found: {resultImagePath}");
                }
            }
        }
        private string RunPythonScript(string scriptPath, string imagePath)
        {
            pythonExe = @"C:\Users\dptos\AppData\Local\Programs\Python\Python310\python.exe";
            outputPath = string.Empty;

            try
            {
                ProcessStartInfo start = new ProcessStartInfo
                {
                    FileName = pythonExe,  // Çalýþtýrýlacak dosyanýn yolu
                    Arguments = $"{scriptPath} \"{imagePath}\"",  // Komut satýrý argümanlarý
                    RedirectStandardOutput = true,  // Python betiðinin çýktýlarýný okumak için yeniden yönlendir
                    UseShellExecute = false,  // Kabuk iþlemi kullanma (doðrudan uygulama çalýþtýr)
                    CreateNoWindow = true     // Yeni bir konsol penceresi oluþturma
                };

                using (Process process = Process.Start(start))
                {
                    using (StreamReader reader = process.StandardOutput)
                    {
                        string rawOutput = reader.ReadToEnd().Trim();
                        Debug.WriteLine("rawOutput: " + rawOutput);
                        outputPath = ExtractFilePath(rawOutput);
                        Debug.WriteLine("Extracted Output Path: " + outputPath);
                    }
                }
                //outputPath = @"C:\Users\dptos\source\repos\designProject\designProject\detected_images\happy-photo.jpg";
                // Python betiðinden gelen yolun geçerli olup olmadýðýný kontrol et
                if (!File.Exists(outputPath))
                {
                    throw new FileNotFoundException("Python script did not return a valid file path.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return outputPath;
        }

        private string ExtractFilePath(string raw)
        {
            // Boþluk karakterine göre parçala
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
