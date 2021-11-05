using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models.Entitie
{
    public class Klub
    {
        public int Id { get; set; }
        public String Skracenica { get; set; }
        public String Naziv { get; set; }
        public String Logo { get; set; }
        [NotMapped]
        public IFormFile Slika { get; set; }
        public String VlasnikId { get; set; }
        [ForeignKey("VlasnikId")]
        public virtual User Vlasnik { get; set; }
        [InverseProperty("Klub")]
        public ICollection<User> Igraci { get; set; }
        public virtual ICollection<KlubTrener> KlubTrener { get; set; }
        [NotMapped]
        public int[] SelectedValues { get; set; }
    }
}
