using HelpDesk.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Submitter: Person
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public bool CheckPassword(string password)
        {
            return Password == password;
        }
        public void PerformSubmittion(int id_request, string description, string status, Submitter submitter)
        {
            SubmittionRepository.SubmitRequest(id_request, description, status, submitter);
        }
    }
}
