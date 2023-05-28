using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        /// <summary>
        /// Vraća ime i prezime osobe
        /// </summary>
        /// <returns>Ime i prezime osobe</returns>
        public override string ToString()
        {
            return $"{Name} {LastName}";
        }
        
    }
}
