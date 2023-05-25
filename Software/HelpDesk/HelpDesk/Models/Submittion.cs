using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Submittion
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
