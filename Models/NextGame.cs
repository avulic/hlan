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
        public String Domaci { get; set; }
        public String Gosti { get; set; }
        public String Datum { get; set; }

    }
}
