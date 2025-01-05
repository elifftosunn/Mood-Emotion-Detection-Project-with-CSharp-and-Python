using designProject.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using designProject.Models;
using MoodSyncProject.Views;

namespace MoodSyncProject.Models
{
    public class MusicRecommendation
    {
        private Music music;
        private UserDetailForm userDetailForm;
        private DBConnection connection;
        private DateTime recommendationTime;
        private string reason;
        public int UserID { get; set; }
        public string Mood { get; set; }
        public List<string> Recommendations { get; set; } = new List<string>();
        public MusicRecommendation(UserDetailForm _userDetailForm)
        {
            connection = new DBConnection();
            userDetailForm = _userDetailForm;
            UserID = userDetailForm.userID;
            connection = userDetailForm._dbConnection;
            Mood = userDetailForm._detectImageForm.mood;
        }




    }
}
