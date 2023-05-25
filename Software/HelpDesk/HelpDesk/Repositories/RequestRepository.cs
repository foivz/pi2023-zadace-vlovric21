using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DBLayer;
using HelpDesk.Models;

namespace HelpDesk.Repositories
{
    public class RequestRepository
    {
        public static Request GetRequest(int id)
        { 
            Request request = null;
            string sql = $"SELECT * FROM dbo.Requests WHERE ID_requests = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                request = CreateObject(reader);
                reader.Close();
            }
            DB.CloseConnection();
            return request;
        }
        public static List<Request> GetRequests()
        {
            List<Request> requests = new List<Request> ();
            string sql = "SELECT * FROM dbo.Requests";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Request request = CreateObject(reader);
                requests.Add(request);
            }
            reader.Close();
            DB.CloseConnection();

            return requests;
        }
        private static Request CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID_request"].ToString());
            int username = int.Parse(reader["ID_submitter"].ToString());
            DateTime time = DateTime.Parse(reader["time"].ToString());
            string description = reader["description"].ToString();
            string undertaken = reader["undertaken"].ToString();
            string comment = reader["comment"].ToString();
            string status = reader["status"].ToString();

            var request = new Request
            {
                Id = id,
                Username = username,
                Time = time,
                Description = description,
                Undertaken = undertaken,
                Comment = comment,
                Status = status
            };
            return request;
        }
        public static void DeleteRequest(int id)
        {
            string sql = $"DELETE FROM dbo.Requests WHERE ID_request = {id}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
