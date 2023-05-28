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
        /// <summary>
        /// Stvara objekt tipa Submittion prema ID-u s njegovim podatcima, submittion je posrednik između podnositelja i forme u programskoj logici.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Objekt podnošenja</returns>
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
        /// <summary>
        /// Stvara listu objekata Submittion prema ID-u
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static List<Submittion> GetSubmittions(int id)
        {
            List<Submittion> submittions = new List<Submittion>();
            string sql = $"SELECT * FROM dbo.Requests WHERE ID_submitter = {id}";
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
        /// <summary>
        /// Stvara novi objekt i upisuje u njega podatke iz baze
        /// </summary>
        /// <param name="reader"></param>
        /// <returns>Objekt sa podatcima</returns>
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
        /// <summary>
        /// Nalazi najveći ID zahtjeva u tablici zahtjeva
        /// </summary>
        /// <returns>najveći ID</returns>
        public static int FindMaxID()
        {
            int maxId = 1;
            string sql = "SELECT MAX(ID_request) AS MaxID FROM dbo.Requests";
            DB.OpenConnection();
            var reader = DB.GetDataReader(sql);
            if (reader.HasRows)
            {
                reader.Read();
                maxId = int.Parse(reader["MaxID"].ToString());
                reader.Close();
            }
            DB.CloseConnection();
            return maxId;
        }
        /// <summary>
        /// Unosi argumente u bazu zahtjeva kao novi zahtjev.
        /// </summary>
        /// <param name="id_request"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <param name="submitter"></param>
        public static void SubmitRequest(int id_request, string description, string status, Submitter submitter)
        {
            string sql = $"INSERT INTO dbo.Requests (ID_request, time, description, status, ID_submitter) VALUES ({id_request}, CURRENT_TIMESTAMP, '{description}', '{status}', {submitter.Id})";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
        /// <summary>
        /// Ažurira red zahtjeva s određenim ID-om s novim datumom i sadržajem.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <param name="submitter"></param>
        public static void UpdateRequest(int id, string description, string status, Submitter submitter)
        {
            string sql = $"UPDATE dbo.Requests SET time = CURRENT_TIMESTAMP, description = '{description}', status = '{status}', ID_submitter = {submitter.Id} WHERE ID_request = {id}";
            DB.OpenConnection();
            DB.ExecuteCommand(sql);
            DB.CloseConnection();
        }
    }
}
