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
        public static List<Request> GetRequests(int id)
        {
            List<Request> requests = new List<Request> ();
            string sql = $"SELECT * FROM dbo.Requests WHERE ID_submitter = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            while (reader.Read())
            {
                Request request = CreateObject(reader);
                requests.Add(request);
            }
            reader.Close();
            DB.CloseConnection();
            foreach(Request request in requests)
            {
                request.FullName = GetFullName(request.Id_submitter);
            }

            return requests;
        }
        private static Request CreateObject(SqlDataReader reader)
        {
            int id = int.Parse(reader["ID_request"].ToString());
            int id_submitter = int.Parse(reader["ID_submitter"].ToString());
            DateTime time = DateTime.Parse(reader["time"].ToString());
            string description = reader["description"].ToString();
            string undertaken = reader["undertaken"].ToString();
            string comment = reader["comment"].ToString();
            string status = reader["status"].ToString();

            var request = new Request
            {
                Id = id,
                Id_submitter = id_submitter,
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
        public static string GetFullName(int id)
        {
            string firstname = null;
            string lastname = null;
            string sql = $"SELECT rs.firstname, rs.lastname FROM dbo.Request_Submitter rs JOIN dbo.Requests r ON rs.ID_submitter = r.ID_submitter WHERE r.ID_submitter = {id}";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                firstname = reader["firstname"].ToString();
                lastname = reader["lastname"].ToString();
                reader.Close();
            }
            DB.CloseConnection();
            return firstname + " " + lastname;
        }
    }
}
