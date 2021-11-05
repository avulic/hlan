using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models.Entitie
{
    public class StatistikaKluba
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Klub Klub { get; set; }
        public int Disposals { get; set; }
        public int Marks { get; set; }
        public int Tackles { get; set; }
        public int Spoils { get; set; }
        public int Hitouts { get; set; }
        public int Goals { get; set; }
        public int Behinds { get; set; }
    }
}
