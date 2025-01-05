using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace designProject.Models
{
    public class DBConnection
    {
        public SqlConnection connection;
        private SqlCommand cmd;
        private SqlDataReader dataReader;
        public void OpenConnection()
        {
            connection = new SqlConnection("Data Source=.\\MSSQLSERVER2022;Initial Catalog=MoodSync;Integrated Security=True;MultipleActiveResultSets=True;");
            connection.Open();

        }
        public SqlDataReader ExecuteQueryWithReader(string query, SqlParameter[] parameters = null)
        {
            OpenConnection();
            cmd = new SqlCommand(query, connection);
            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            dataReader = cmd.ExecuteReader();
            return dataReader;
        }
        public int ExecuteNonQuery(string query, SqlParameter[] parameters = null)
        {
            try
            {
                OpenConnection();
                cmd = new SqlCommand(query, connection);
                if (parameters != null) 
                {
                    cmd.Parameters.AddRange(parameters);
                }
                return cmd.ExecuteNonQuery();
            }
            finally 
            {
                CloseConnection();
            }
        }
        public void CloseConnection() 
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open) 
            {
                connection.Close();
            }
        }
    }
}
