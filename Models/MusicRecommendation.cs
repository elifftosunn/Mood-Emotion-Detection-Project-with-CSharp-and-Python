using designProject.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using designProject.Models;

namespace MoodSyncProject.Models
{
    public class MusicRecommendation
    {
        private Music music;
        private DateTime recommendationTime;
        private string reason;

        public int UserID { get; set; }
        public string Mood { get; set; }
        public List<string> Recommendations { get; set; } = new List<string>();

        // Kullanıcı bilgilerini ve önerileri veri tabanından çeker
        public static MusicRecommendation GetUserDetails(int userId)
        {
            MusicRecommendation recommendation = new MusicRecommendation();
            recommendation.UserID = userId;

            // Database bağlantısı
            string queryUser = "SELECT Mood FROM UserMoods WHERE UserID = @UserID";
            string queryRecommendations = "SELECT Genre FROM MusicRecommendations WHERE UserID = @UserID";

            DBConnection connection = new DBConnection();

            // Kullanıcı ruh hali
            SqlParameter[] userParams = { new SqlParameter("@UserID", SqlDbType.Int) { Value = userId } };
            var reader = connection.ExecuteQueryWithReader(queryUser, userParams);
            if (reader.Read())
            {
                recommendation.Mood = reader["Mood"].ToString();
            }

            // Kullanıcı önerileri
            SqlParameter[] recParams = { new SqlParameter("@UserID", SqlDbType.Int) { Value = userId } };
            var recReader = connection.ExecuteQueryWithReader(queryRecommendations, recParams);
            while (recReader.Read())
            {
                recommendation.Recommendations.Add(recReader["Genre"].ToString());
            }

            return recommendation;
        }
    }
}
