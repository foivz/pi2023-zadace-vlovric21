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
    public class SubmittionRepository
    {
        public static Submittion GetSubmittion(int id)
        {
            Submittion submittion = null;
            string sql = $"SELECT * FROM dbo.Requests WHERE ID_request = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                submittion = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return submittion;
        }

        public static List<Submittion> GetSubmittions()
        {
            List<Submittion> submittions = new List<Submittion>();
            string sql = "SELECT * FROM dbo.Requests";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Submittion submittion = CreateObject(reader);
                submittions.Add(submittion);
            }
            reader.Close();
            DB.CloseConnection();
            return submittions;
        }
        private static Submittion CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID_request"].ToString());
            int name = int.Parse(reader["ID_submitter"].ToString());
            string description = reader["description"].ToString();
            DateTime date = DateTime.Parse(reader["time"].ToString());

            var submittion = new Submittion
            {
                Id = id,
                Name = name,
                Description = description,
                Date = date,
            };
            return submittion;
            
        }
        public static void SubmitRequest(int id_request, string description, string status, Submitter submitter)
        {
            string sql = $"INSERT INTO dbo.Requests (ID_request, time, description, status, ID_submitter) VALUES ({id_request}, CURRENT_TIMESTAMP, '{description}', '{status}', {submitter.Id})";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
