using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelpDesk.Models
{
    public class Request
    {
        //fali redni broj al to cu kasnije
        public int Username { get; set; }
        public DateTime Time { get; set; }
        public string Description { get; set; }
        public string Undertaken { get; set; }
        public string Comment { get; set; }
        public string Status { get; set; }
    }
}
