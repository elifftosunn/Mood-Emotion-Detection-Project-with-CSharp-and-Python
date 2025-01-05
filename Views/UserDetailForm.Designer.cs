namespace MoodSyncProject.Views
{
    partial class UserDetailForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserDetailForm));
            panel2 = new Panel();
            btnLogout = new Button();
            label1 = new Label();
            lblUserDetail = new Label();
            groupBoxUserInformation = new GroupBox();
            dbLblLastLoginDate = new Label();
            dbLblRecordDate = new Label();
            dbLblEmail = new Label();
            dbLblFullName = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            labelTwoDots = new Label();
            lblLastLoginDatetime = new Label();
            lblRecordDatetime = new Label();
            lblEmail = new Label();
            lblFullName = new Label();
            dataGridViewMoodHistory = new DataGridView();
            mood = new DataGridViewTextBoxColumn();
            detectionTime = new DataGridViewTextBoxColumn();
            dataGridViewMusicRecommendation = new DataGridView();
            genreName = new DataGridViewTextBoxColumn();
            recommendationTime = new DataGridViewTextBoxColumn();
            reason = new DataGridViewTextBoxColumn();
            listViewUserPreferences = new ListView();
            btnBack = new Button();
            domainUpDownForGenre = new DomainUpDown();
            label5 = new Label();
            btnUpdateRecords = new Button();
            panel2.SuspendLayout();
            groupBoxUserInformation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMoodHistory).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMusicRecommendation).BeginInit();
            SuspendLayout();
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(202, 180, 133);
            panel2.Controls.Add(btnLogout);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1032, 88);
            panel2.TabIndex = 7;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Maroon;
            btnLogout.Dock = DockStyle.Right;
            btnLogout.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnLogout.ForeColor = Color.White;
            btnLogout.Location = new Point(929, 0);
            btnLogout.Name = "btnLogout";
            btnLogout.Size = new Size(103, 88);
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
            // lblUserDetail
            // 
            lblUserDetail.AutoSize = true;
            lblUserDetail.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 162);
            lblUserDetail.ForeColor = SystemColors.ActiveCaptionText;
            lblUserDetail.Location = new Point(410, 100);
            lblUserDetail.Name = "lblUserDetail";
            lblUserDetail.Size = new Size(186, 41);
            lblUserDetail.TabIndex = 9;
            lblUserDetail.Text = "User Details";
            // 
            // groupBoxUserInformation
            // 
            groupBoxUserInformation.Controls.Add(dbLblLastLoginDate);
            groupBoxUserInformation.Controls.Add(dbLblRecordDate);
            groupBoxUserInformation.Controls.Add(dbLblEmail);
            groupBoxUserInformation.Controls.Add(dbLblFullName);
            groupBoxUserInformation.Controls.Add(label4);
            groupBoxUserInformation.Controls.Add(label3);
            groupBoxUserInformation.Controls.Add(label2);
            groupBoxUserInformation.Controls.Add(labelTwoDots);
            groupBoxUserInformation.Controls.Add(lblLastLoginDatetime);
            groupBoxUserInformation.Controls.Add(lblRecordDatetime);
            groupBoxUserInformation.Controls.Add(lblEmail);
            groupBoxUserInformation.Controls.Add(lblFullName);
            groupBoxUserInformation.Location = new Point(129, 157);
            groupBoxUserInformation.Name = "groupBoxUserInformation";
            groupBoxUserInformation.Size = new Size(365, 165);
            groupBoxUserInformation.TabIndex = 10;
            groupBoxUserInformation.TabStop = false;
            groupBoxUserInformation.Text = "User Information";
            // 
            // dbLblLastLoginDate
            // 
            dbLblLastLoginDate.AutoSize = true;
            dbLblLastLoginDate.Location = new Point(146, 118);
            dbLblLastLoginDate.Name = "dbLblLastLoginDate";
            dbLblLastLoginDate.Size = new Size(15, 20);
            dbLblLastLoginDate.TabIndex = 11;
            dbLblLastLoginDate.Text = "*";
            // 
            // dbLblRecordDate
            // 
            dbLblRecordDate.AutoSize = true;
            dbLblRecordDate.Location = new Point(147, 89);
            dbLblRecordDate.Name = "dbLblRecordDate";
            dbLblRecordDate.Size = new Size(15, 20);
            dbLblRecordDate.TabIndex = 10;
            dbLblRecordDate.Text = "*";
            // 
            // dbLblEmail
            // 
            dbLblEmail.AutoSize = true;
            dbLblEmail.Location = new Point(147, 60);
            dbLblEmail.Name = "dbLblEmail";
            dbLblEmail.Size = new Size(15, 20);
            dbLblEmail.TabIndex = 9;
            dbLblEmail.Text = "*";
            // 
            // dbLblFullName
            // 
            dbLblFullName.AutoSize = true;
            dbLblFullName.Location = new Point(147, 32);
            dbLblFullName.Name = "dbLblFullName";
            dbLblFullName.Size = new Size(15, 20);
            dbLblFullName.TabIndex = 8;
            dbLblFullName.Text = "*";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(124, 118);
            label4.Name = "label4";
            label4.Size = new Size(12, 20);
            label4.TabIndex = 7;
            label4.Text = ":";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(124, 89);
            label3.Name = "label3";
            label3.Size = new Size(12, 20);
            label3.TabIndex = 6;
            label3.Text = ":";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(124, 60);
            label2.Name = "label2";
            label2.Size = new Size(12, 20);
            label2.TabIndex = 5;
            label2.Text = ":";
            // 
            // labelTwoDots
            // 
            labelTwoDots.AutoSize = true;
            labelTwoDots.Location = new Point(124, 30);
            labelTwoDots.Name = "labelTwoDots";
            labelTwoDots.Size = new Size(12, 20);
            labelTwoDots.TabIndex = 4;
            labelTwoDots.Text = ":";
            // 
            // lblLastLoginDatetime
            // 
            lblLastLoginDatetime.AutoSize = true;
            lblLastLoginDatetime.Location = new Point(10, 118);
            lblLastLoginDatetime.Name = "lblLastLoginDatetime";
            lblLastLoginDatetime.Size = new Size(112, 20);
            lblLastLoginDatetime.TabIndex = 3;
            lblLastLoginDatetime.Text = "Last Login Date";
            // 
            // lblRecordDatetime
            // 
            lblRecordDatetime.AutoSize = true;
            lblRecordDatetime.Location = new Point(10, 89);
            lblRecordDatetime.Name = "lblRecordDatetime";
            lblRecordDatetime.Size = new Size(92, 20);
            lblRecordDatetime.TabIndex = 2;
            lblRecordDatetime.Text = "Record Date";
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(10, 60);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 1;
            lblEmail.Text = "Email";
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(10, 30);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(76, 20);
            lblFullName.TabIndex = 0;
            lblFullName.Text = "Full Name";
            // 
            // dataGridViewMoodHistory
            // 
            dataGridViewMoodHistory.AllowUserToAddRows = false;
            dataGridViewMoodHistory.AllowUserToDeleteRows = false;
            dataGridViewMoodHistory.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridViewMoodHistory.Columns.AddRange(new DataGridViewColumn[] { mood, detectionTime });
            dataGridViewMoodHistory.Location = new Point(347, 362);
            dataGridViewMoodHistory.Name = "dataGridViewMoodHistory";
            dataGridViewMoodHistory.ReadOnly = true;
            dataGridViewMoodHistory.RowHeadersWidth = 51;
            dataGridViewMoodHistory.Size = new Size(378, 155);
            dataGridViewMoodHistory.TabIndex = 11;
            // 
            // mood
            // 
            mood.HeaderText = "Mood";
            mood.MaxInputLength = 50;
            mood.MinimumWidth = 6;
            mood.Name = "mood";
            mood.Width = 125;
            // 
            // detectionTime
            // 
            detectionTime.HeaderText = "Detection Time";
            detectionTime.MinimumWidth = 6;
            detectionTime.Name = "detectionTime";
            detectionTime.Width = 125;
            // 
            // dataGridViewMusicRecommendation
            // 
            dataGridViewMusicRecommendation.AllowUserToAddRows = false;
            dataGridViewMusicRecommendation.AllowUserToDeleteRows = false;
            dataGridViewMusicRecommendation.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            //dataGridViewMusicRecommendation.Columns.AddRange(new DataGridViewColumn[] { genreName, recommendationTime, reason });
            dataGridViewMusicRecommendation.Location = new Point(527, 168);
            dataGridViewMusicRecommendation.Name = "dataGridViewMusicRecommendation";
            dataGridViewMusicRecommendation.ReadOnly = true;
            dataGridViewMusicRecommendation.RowHeadersWidth = 51;
            dataGridViewMusicRecommendation.Size = new Size(479, 154);
            dataGridViewMusicRecommendation.TabIndex = 12;
            // 
            // genreName
            // 
            genreName.FillWeight = 200F;
            genreName.HeaderText = "Genre Name";
            genreName.MinimumWidth = 15;
            genreName.Name = "genreName";
            genreName.ReadOnly = true;
            genreName.Width = 213;
            // 
            // recommendationTime
            // 
            recommendationTime.HeaderText = "Recommendation Time";
            recommendationTime.MinimumWidth = 6;
            recommendationTime.Name = "recommendationTime";
            recommendationTime.ReadOnly = true;
            recommendationTime.Width = 107;
            // 
            // reason
            // 
            reason.HeaderText = "Reason";
            reason.MinimumWidth = 6;
            reason.Name = "reason";
            reason.ReadOnly = true;
            reason.Width = 106;
            // 
            // listViewUserPreferences
            // 
            listViewUserPreferences.Location = new Point(757, 362);
            listViewUserPreferences.Name = "listViewUserPreferences";
            listViewUserPreferences.Size = new Size(249, 155);
            listViewUserPreferences.TabIndex = 14;
            listViewUserPreferences.UseCompatibleStateImageBehavior = false;
            listViewUserPreferences.View = View.Details;
            // 
            // btnBack
            // 
            btnBack.BackColor = Color.FromArgb(202, 180, 133);
            btnBack.BackgroundImage = (Image)resources.GetObject("btnBack.BackgroundImage");
            btnBack.Dock = DockStyle.Left;
            btnBack.FlatStyle = FlatStyle.Popup;
            btnBack.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnBack.ForeColor = Color.Black;
            btnBack.Location = new Point(0, 88);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(87, 507);
            btnBack.TabIndex = 15;
            btnBack.Text = "<";
            btnBack.UseVisualStyleBackColor = false;
            btnBack.Click += btnBack_Click;
            // 
            // domainUpDownForGenre
            // 
            domainUpDownForGenre.BorderStyle = BorderStyle.None;
            domainUpDownForGenre.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 162);
            domainUpDownForGenre.Items.Add("Pop");
            domainUpDownForGenre.Items.Add("Rap");
            domainUpDownForGenre.Items.Add("Rock");
            domainUpDownForGenre.Items.Add("Latin");
            domainUpDownForGenre.Items.Add("R&B (Rhythm and Blues)");
            domainUpDownForGenre.Items.Add("EDM");
            domainUpDownForGenre.Location = new Point(129, 400);
            domainUpDownForGenre.Name = "domainUpDownForGenre";
            domainUpDownForGenre.Size = new Size(171, 26);
            domainUpDownForGenre.TabIndex = 16;
            domainUpDownForGenre.Text = "Pop";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 162);
            label5.Location = new Point(129, 362);
            label5.Name = "label5";
            label5.Size = new Size(152, 23);
            label5.TabIndex = 17;
            label5.Text = "Select genre name";
            // 
            // btnUpdateRecords
            // 
            btnUpdateRecords.BackColor = Color.PeachPuff;
            btnUpdateRecords.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 162);
            btnUpdateRecords.ForeColor = Color.Black;
            btnUpdateRecords.Location = new Point(129, 449);
            btnUpdateRecords.Name = "btnUpdateRecords";
            btnUpdateRecords.Size = new Size(178, 50);
            btnUpdateRecords.TabIndex = 19;
            btnUpdateRecords.Text = "Update Records";
            btnUpdateRecords.UseVisualStyleBackColor = false;
            btnUpdateRecords.Click += btnUpdateRecords_Click;
            // 
            // UserDetailForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 595);
            Controls.Add(btnUpdateRecords);
            Controls.Add(label5);
            Controls.Add(domainUpDownForGenre);
            Controls.Add(btnBack);
            Controls.Add(listViewUserPreferences);
            Controls.Add(dataGridViewMusicRecommendation);
            Controls.Add(dataGridViewMoodHistory);
            Controls.Add(groupBoxUserInformation);
            Controls.Add(lblUserDetail);
            Controls.Add(panel2);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "UserDetailForm";
            Text = "UserDetails";
            Load += UserDetailForm_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            groupBoxUserInformation.ResumeLayout(false);
            groupBoxUserInformation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMoodHistory).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMusicRecommendation).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel panel2;
        private Button btnLogout;
        private Label label1;
        private Label lblUserDetail;
        private GroupBox groupBoxUserInformation;
        private Label lblFullName;
        private Label lblEmail;
        private Label lblRecordDatetime;
        private Label lblLastLoginDatetime;
        private DataGridView dataGridViewMoodHistory;
        private DataGridViewTextBoxColumn mood;
        private DataGridViewTextBoxColumn detectionTime;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label labelTwoDots;
        private Label dbLblLastLoginDate;
        private Label dbLblRecordDate;
        private Label dbLblEmail;
        private Label dbLblFullName;
        private DataGridView dataGridViewMusicRecommendation;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn genreNameUserPref;
        private DataGridViewTextBoxColumn preferenceLevel;
        private ListView listViewUserPreferences;
        private DataGridViewTextBoxColumn genreName;
        private DataGridViewTextBoxColumn recommendationTime;
        private DataGridViewTextBoxColumn reason;
        private Button btnBack;
        private DomainUpDown domainUpDownForGenre;
        private Label label5;
        private Button btnUpdateRecords;
    }
}