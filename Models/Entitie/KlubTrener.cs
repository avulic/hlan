using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models.Entitie
{
    public class KlubTrener
    {
        [Key]
        public int Id { get; set; }
        public int KlubId { get; set; }
        [ForeignKey("KlubId")]
        public Klub Klub { get; set; }
        public String UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }
    }
}
