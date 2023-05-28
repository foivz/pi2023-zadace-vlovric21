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
        /// <summary>
        /// Provjerava je li lozinka koju je korisnik unio u textbox ona koja pripada ovom objektu podnositelja zahtjeva.
        /// </summary>
        /// <param name="password"></param>
        /// <returns>Bool je li lozinka ispravna ili ne</returns>
        public bool CheckPassword(string password)
        {
            return Password == password;
        }
        /// <summary>
        /// Unosi novi zahtjev u bazu
        /// </summary>
        /// <param name="id_request"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <param name="submitter"></param>
        public void PerformSubmittion(int id_request, string description, string status, Submitter submitter)
        {
            SubmittionRepository.SubmitRequest(id_request, description, status, submitter);
        }
        /// <summary>
        /// Ažurira zahtjev u bazi
        /// </summary>
        /// <param name="id"></param>
        /// <param name="description"></param>
        /// <param name="status"></param>
        /// <param name="submitter"></param>
        public void PerformUpdate(int id, string description, string status, Submitter submitter)
        {
            SubmittionRepository.UpdateRequest(id, description, status, submitter);
        }
    }
}
