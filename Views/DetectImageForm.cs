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

                // Python beti�ini �al��t�r ve tespit edilen resim yolunu al
                resultImagePath = RunPythonScript(yolo_detectPyPath, imagePath);

                // Tespit edilen g�r�nt�y� PictureBox �zerinde g�ster
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
                    FileName = pythonExe,  // �al��t�r�lacak dosyan�n yolu
                    Arguments = $"{scriptPath} \"{imagePath}\"",  // Komut sat�r� arg�manlar�
                    RedirectStandardOutput = true,  // Python beti�inin ��kt�lar�n� okumak i�in yeniden y�nlendir
                    UseShellExecute = false,  // Kabuk i�lemi kullanma (do�rudan uygulama �al��t�r)
                    CreateNoWindow = true     // Yeni bir konsol penceresi olu�turma
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
                // Python beti�inden gelen yolun ge�erli olup olmad���n� kontrol et
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
            // Bo�luk karakterine g�re par�ala
            string[] parts = raw.Split(' ');
            int firstColonIndex = parts[2].IndexOf(':'); // �lk ':'
            int secondColonIndex = parts[2].LastIndexOf(':'); // �lk ':' sonras�
            // ':' i�aretine kadar olan k�sm� al
            string imagePath = parts[2].Substring(firstColonIndex - 1, secondColonIndex);
            return imagePath;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
