using designProject;
using designProject.Models;
using designProject.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MoodSyncProject.Views
{
    public partial class UserDetailForm : Form
    {
        public DetectImageForm _detectImageForm;
        public DBConnection _dbConnection;
        public int userID;

        public UserDetailForm(DetectImageForm detectImageForm)
        {
            InitializeComponent();
            _detectImageForm = detectImageForm;
            _dbConnection = new DBConnection();
            userID = _detectImageForm.userID;
        }
        private void UserDetailForm_Load(object sender, EventArgs e)
        {
            uploadUserInformation();
            uploadMusicRecommendation();
            uploadMoodHistory();
            ViewUserPreferences();
        }

        private void ViewUserPreferences()
        {
            string query = "SELECT genreName, preferenceLevel FROM UserPreferences UP INNER JOIN MusicGenres MG " +
                "ON MG.genreID = UP.genreID WHERE userID=@_userID";
            SqlParameter[] parameters = { new SqlParameter("@_userID", SqlDbType.Int) { Value = userID} };
            SqlDataReader reader = _dbConnection.ExecuteQueryWithReader(query, parameters);
            // Kolonları ekle
            listViewUserPreferences.Columns.Add("Genre Type", 120);
            listViewUserPreferences.Columns.Add("Preference Level", 120);
            while (reader.Read()) 
            {
                ListViewItem listViewItem = new ListViewItem(reader["genreName"].ToString());
                listViewItem.SubItems.Add(reader["preferenceLevel"].ToString());
                listViewUserPreferences.Items.Add(listViewItem);
            }
            this.Controls.Add(listViewUserPreferences);
        }

        private void uploadMoodHistory() 
        {
            string query = "SELECT mood, detectionTime FROM MoodHistory WHERE userID = @_userID";
            SqlParameter[] parameters = {new SqlParameter("@_userID", SqlDbType.Int) { Value = userID}};
            SqlDataAdapter adapter = new SqlDataAdapter(query, _dbConnection.connection);
            adapter.SelectCommand.Parameters.AddRange(parameters);

            // fill datas into a DataTable 
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // bind it to the DataGridView
            dataGridViewMoodHistory.DataSource = dataTable;

        }
        private void uploadMusicRecommendation() 
        {
            string query = "SELECT genreName, recommendationTime, reason FROM MusicRecommendations MR INNER JOIN MusicGenres MG " +
                "ON MG.genreID = MR.genreID WHERE userID = @_userID";
            SqlParameter[] parameters = { new SqlParameter("@_userID", SqlDbType.Int) { Value = userID } };

            SqlDataAdapter adapter = new SqlDataAdapter(query, _dbConnection.connection);
            adapter.SelectCommand.Parameters.AddRange(parameters);

            // fill datas into a DataTable 
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            // Create a BindingSource and bind it to the DataGridView
            BindingSource bindingSource = new BindingSource();
            bindingSource.DataSource = dataTable;
            dataGridViewMusicRecommendation.DataSource = bindingSource;
        }
        private void uploadUserInformation()
        {
            string query = "SELECT firstname, lastname, email, RecordTime FROM Users WHERE userID=@_userID";
            string sessionQuery = "SELECT TOP 1 loginTime FROM Sessions WHERE userID = @_userID ORDER BY loginTime DESC";

            SqlParameter[] parameters = { new SqlParameter("@_userID", SqlDbType.Int) { Value = userID } };
            SqlParameter[] parametersForLastLoginTime = { new SqlParameter("@_userID", SqlDbType.Int) { Value = userID } };
            SqlDataReader dataReader = _dbConnection.ExecuteQueryWithReader(query, parameters);
            SqlDataReader dataReaderForLastLoginTime = _dbConnection.ExecuteQueryWithReader(sessionQuery, parametersForLastLoginTime);
            try
            {
                if (dataReaderForLastLoginTime.Read())
                {
                    dbLblLastLoginDate.Text = dataReaderForLastLoginTime["loginTime"].ToString();
                }
                if (dataReader.Read())
                {
                    dbLblFullName.Text = dataReader["firstname"].ToString() + " " + dataReader["lastname"].ToString();
                    dbLblEmail.Text = dataReader["email"].ToString();
                    dbLblRecordDate.Text = dataReader["RecordTime"].ToString();

                }
            }
            finally 
            { 
                dataReader.Close();
                dataReaderForLastLoginTime.Close();
            }

        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            _detectImageForm.Show();
            this.Close();
        }

        private void btnUpdateRecords_Click(object sender, EventArgs e)
        {
            //_detectImageForm.mood;
        }


    }
}
