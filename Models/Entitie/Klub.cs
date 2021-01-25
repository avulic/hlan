using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models.Entitie
{
    public class Klub
    {
        public Klub()
        {
            Igraci = new HashSet<User>();
        }
        public int Id { get; set; }
        public String Skracenica { get; set; }
        [DisplayName("Naziv kluba")]
        public String Naziv { get; set; }
        public String Logo { get; set; }
        public ICollection<User> Igraci { get; set; }
    }
}
