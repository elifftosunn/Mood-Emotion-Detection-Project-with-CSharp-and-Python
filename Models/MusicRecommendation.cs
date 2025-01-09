using designProject.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoodSyncProject.Views;
using System.Diagnostics;
using MoodSyncProject.Controllers;

namespace MoodSyncProject.Models
{
    public class MusicRecommendation
    {
        private UserDetailForm userDetailForm;
        private DBConnection connection;

        public MusicRecommendation(UserDetailForm _userDetailForm)
        {
            userDetailForm = _userDetailForm;
            connection = userDetailForm._dbConnection;
        }
        public int CalculatePreferenceLevel(int userId, int genreId)
        {
            int listenCount = GetListenCount(userId, genreId); // Taken from listening history
            Debug.WriteLine($"CalculatePreferenceLevel / listenCount: {listenCount}");
            if (listenCount == 0)
                return 1; // Default value if there is no listening history
            return Math.Max(1, Math.Min(5, (int)Math.Ceiling(listenCount / 10.0))); // The recommended value is scaled from 1 to 5
        }

        private int GetListenCount(int userId, int genreId)
        {
            string query = @"SELECT 
                                MAX(countByGenreID) AS maxCountByGenreID 
                            FROM ( 
                                    SELECT  userID, genreID, COUNT(genreID) AS countByGenreID
                                    FROM MusicRecommendations WHERE userID = @_userID
                                    GROUP BY userID, genreID 
                                    HAVING COUNT(genreID) >= 3 
                                 ) AS GenreCounts";
            SqlParameter[] parameters = { new SqlParameter("@_userID", SqlDbType.Int) { Value = userId } };
            SqlDataReader reader = connection.ExecuteQueryWithReader(query, parameters);
            int maxCountByGenreID;
            try
            {
                if (reader.Read())
                    return Convert.ToInt32(reader["maxCountByGenreID"]);
            }
            finally
            {
                reader.Close();
            }

            // If there is no result or an error occurs
            return 0;
        }

        public void SaveUserPreference(int userId, int genreId, int preferenceLevel, bool isManual)
        {
            if (!isManual)
            {
                preferenceLevel = GetFinalPreferenceLevelAsManual(userId, genreId);
            }
            Debug.WriteLine($"SaveUserPreference / preferenceLevel: {preferenceLevel}");
            string query = @"
                    MERGE INTO UserPreferences AS target
                    USING (SELECT @_UserID AS UserID, @_GenreID AS GenreID, @_PreferenceLevel AS PreferenceLevel, @_IsManual AS IsManual) AS source
                    ON target.UserID = source.UserID AND target.GenreID = source.GenreID
                    WHEN MATCHED THEN 
                        UPDATE SET 
                            PreferenceLevel = source.PreferenceLevel, 
                            IsManual = source.IsManual
                    WHEN NOT MATCHED THEN 
                        INSERT (UserID, GenreID, PreferenceLevel, IsManual)
                        VALUES (source.UserID, source.GenreID, source.PreferenceLevel, source.IsManual);";

            SqlParameter[] parameters = {
                new SqlParameter("@_UserID", SqlDbType.Int) { Value = userId },
                new SqlParameter("@_GenreID", SqlDbType.Int) { Value = genreId },
                new SqlParameter("@_PreferenceLevel", SqlDbType.Int) { Value = preferenceLevel },
                new SqlParameter("@_IsManual", SqlDbType.Bit) { Value = isManual }
            };

            connection.ExecuteNonQuery(query, parameters);

        }


        public int GetFinalPreferenceLevelAsManual(int userId, int genreId)
        {
            string query = @"SELECT PreferenceLevel FROM UserPreferences WHERE UserID = @UserID AND GenreID = @GenreID";
            SqlParameter[] parameters = {
                new SqlParameter("@UserID", SqlDbType.Int) { Value = userId },
                new SqlParameter("@GenreID", SqlDbType.Int) { Value = genreId }
            };
                
            var result = connection.ExecuteQueryWithReader(query, parameters);
            if (result.Read())
            {
                //if (Convert.ToInt32(result["IsManual"]) == 1)
                //    return Convert.ToInt32(result["PreferenceLevel"]); // user changed as manually
                //else
                    return CalculatePreferenceLevel(userId, genreId); // return system recommendation
            }
            return 0;
           
        }
    }
}
