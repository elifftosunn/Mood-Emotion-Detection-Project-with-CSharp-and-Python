namespace designProject
{
    partial class DetectImageForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DetectImageForm));
            uploadImgPictureBox = new PictureBox();
            btnDetect = new Button();
            lblUploadImage = new Label();
            openFileDialog1 = new OpenFileDialog();
            openFileDialog2 = new OpenFileDialog();
            panel2 = new Panel();
            btnLogout = new Button();
            label1 = new Label();
            panel1 = new Panel();
            flowLayoutPanelForMusics = new FlowLayoutPanel();
            panel3 = new Panel();
            labelMusicName = new Label();
            labelArtist = new Label();
            ((System.ComponentModel.ISupportInitialize)uploadImgPictureBox).BeginInit();
            panel2.SuspendLayout();
            flowLayoutPanelForMusics.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // uploadImgPictureBox
            // 
            uploadImgPictureBox.Image = (Image)resources.GetObject("uploadImgPictureBox.Image");
            uploadImgPictureBox.Location = new Point(110, 169);
            uploadImgPictureBox.Name = "uploadImgPictureBox";
            uploadImgPictureBox.Size = new Size(475, 338);
            uploadImgPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            uploadImgPictureBox.TabIndex = 0;
            uploadImgPictureBox.TabStop = false;
            // 
            // btnDetect
            // 
            btnDetect.BackColor = Color.FromArgb(202, 180, 133);
            btnDetect.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnDetect.Location = new Point(247, 513);
            btnDetect.Name = "btnDetect";
            btnDetect.Size = new Size(178, 50);
            btnDetect.TabIndex = 1;
            btnDetect.Text = "Upload Image";
            btnDetect.UseVisualStyleBackColor = false;
            btnDetect.Click += btnDetect_Click;
            // 
            // lblUploadImage
            // 
            lblUploadImage.AutoSize = true;
            lblUploadImage.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblUploadImage.ForeColor = SystemColors.ActiveCaptionText;
            lblUploadImage.Location = new Point(110, 115);
            lblUploadImage.Name = "lblUploadImage";
            lblUploadImage.Size = new Size(477, 28);
            lblUploadImage.TabIndex = 2;
            lblUploadImage.Text = "Yüz İfadelerini Yükleyin ve Ruh Hali Analizi Yapın";
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // openFileDialog2
            // 
            openFileDialog2.FileName = "openFileDialog2";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(202, 180, 133);
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1218, 88);
            panel2.TabIndex = 4;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Maroon;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(1090, 15);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(103, 50);
            btnLogout.TabIndex = 2;
            btnLogout.Text = "Logout";
            btnLogout.UseVisualStyleBackColor = false;
            btnLogout.Click += btnLogout_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Viner Hand ITC", 24F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.RightToLeft = RightToLeft.No;
            label1.Size = new Size(223, 65);
            label1.TabIndex = 0;
            label1.Text = "MoodSync";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(202, 180, 133);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 88);
            panel1.Name = "panel1";
            panel1.Size = new Size(70, 507);
            panel1.TabIndex = 5;
            // 
            // flowLayoutPanelForMusics
            // 
            flowLayoutPanelForMusics.AutoScroll = true;
            flowLayoutPanelForMusics.Controls.Add(panel3);
            flowLayoutPanelForMusics.Location = new Point(630, 169);
            flowLayoutPanelForMusics.Name = "flowLayoutPanelForMusics";
            flowLayoutPanelForMusics.Size = new Size(576, 337);
            flowLayoutPanelForMusics.TabIndex = 6;
            // 
            // panel3
            // 
            panel3.Controls.Add(labelMusicName);
            panel3.Controls.Add(labelArtist);
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(573, 49);
            panel3.TabIndex = 1;
            // 
            // labelMusicName
            // 
            labelMusicName.AutoSize = true;
            labelMusicName.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelMusicName.Location = new Point(187, 16);
            labelMusicName.Name = "labelMusicName";
            labelMusicName.Size = new Size(108, 23);
            labelMusicName.TabIndex = 1;
            labelMusicName.Text = "Music Name";
            // 
            // labelArtist
            // 
            labelArtist.AutoSize = true;
            labelArtist.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            labelArtist.Location = new Point(15, 16);
            labelArtist.Name = "labelArtist";
            labelArtist.Size = new Size(55, 23);
            labelArtist.TabIndex = 0;
            labelArtist.Text = "Artist";
            // 
            // DetectImageForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGray;
            ClientSize = new Size(1218, 595);
            Controls.Add(flowLayoutPanelForMusics);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Controls.Add(lblUploadImage);
            Controls.Add(btnDetect);
            Controls.Add(uploadImgPictureBox);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DetectImageForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Detect Form";
            ((System.ComponentModel.ISupportInitialize)uploadImgPictureBox).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            flowLayoutPanelForMusics.ResumeLayout(false);
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox uploadImgPictureBox;
        private Button btnDetect;
        private Label lblUploadImage;
        private OpenFileDialog openFileDialog1;
        private OpenFileDialog openFileDialog2;
        private Panel panel2;
        private Label label1;
        private Panel panel1;
        private Button btnLogout;
        private FlowLayoutPanel flowLayoutPanelForMusics;
        private Panel panel3;
        private Label labelArtist;
        private Label labelMusicName;
    }
}
