using DBLayer;
using HelpDesk.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Repositories
{
    public class SubmitterRepository
    {
        public static Submitter GetSubmitter(string username)
        {
            string sql = $"SELECT * FROM dbo.Request_Submitter WHERE username = '{username}'";
            return FetchSubmitter(sql);
        }
        public static Submitter GetSubmitter(int id)
        {
            string sql = $"SELECT * FROM dbo.Request_Submitter WHERE ID_submitter = {id}";
            return FetchSubmitter(sql);
        }
        private static Submitter FetchSubmitter(string sql)
        {
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            Submitter submitter = null;

            if (reader.HasRows)
            {
                reader.Read();
                submitter = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return submitter;
        }
        private static Submitter CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID_submitter"].ToString());
            string firstName = reader["firstname"].ToString();
            string lastName = reader["lastname"].ToString();
            string username = reader["username"].ToString();
            string password = reader["password"].ToString();

            var submitter = new Submitter
            {
                Id = id,
                Name = firstName,
                LastName = lastName,
                Username = username,
                Password = password
            };
            return submitter;

        }
    }
}
