using MoodSyncProject.Controllers;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoodSyncProject.Models
{
    public class Music
    {
        private string Name { get; set; }
        private string Artist { get; set; }
        private string Mood { get; set; }
        private DBConnection conn;
        private SqlDataReader reader;
        private string query;
        private List<Music> musicList;
        public Music(string mood)
        {
            Mood = mood;
        }
        public string getName()
        {
            return Name;
        }
        public string getArtist() 
        { 
            return Artist;
        }
        public List<Music> getMusicList()
        {
            conn = new DBConnection();
            musicList = new List<Music>();
            query = @"SELECT TOP 10 track_name, track_artist FROM Musics WHERE Mood=@_mood";
            SqlParameter[] parameters =
            {
                new SqlParameter("@_mood", SqlDbType.VarChar) {Value = this.Mood}
            };
            reader = conn.ExecuteQueryWithReader(query, parameters);
            while (reader.Read())
            {
                if (this.Mood != null) 
                {
                    musicList.Add(new Music(this.Mood)
                    {
                        Name = reader["track_name"].ToString(),
                        Artist = reader["track_artist"].ToString()
                    });
                }
            }
            return musicList;
        }

    }
}
