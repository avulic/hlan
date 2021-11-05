using HLAN.Models.Entitie;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace HLAN.Models
{
    public class NextGame
    {
        public Klub Domaci { get; set; }
        public Klub Gosti { get; set; }
        public String Datum { get; set; }

    }
}
