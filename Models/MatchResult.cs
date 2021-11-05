using HLAN.Models.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models
{
    public class MatchResult
    {
        public Klub Domaci { get; set; }
        public Klub Gosti { get; set; }
        public int RezDomaci { get; set; }
        public int RezGosti { get; set; }
        public String Datum { get; set; }
    }
}
