using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models
{
    public class MatchResult
    {
        public String Domaci { get; set; }
        public String Gosti { get; set; }
        public int RezDomaci { get; set; }
        public int RezGosti { get; set; }
        public String Datum { get; set; }
    }
}
