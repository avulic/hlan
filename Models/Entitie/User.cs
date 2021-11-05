using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models.Entitie
{
    public class User : IdentityUser
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public override String Id { get; set; }
        public String Ime { get; set; }
        public String Prezime { get; set; }
        [AllowNull]
        public String OIB { get; set; }
        [AllowNull]
        public int Broj { get; set; }
        [AllowNull]
        public String Adresa { get; set; }
        [AllowNull]
        public String Pozicija { get; set; }
        [AllowNull]
        public bool Platio_clanarinu { get; set; }
        [AllowNull]
        public int? KlubId { get; set; }      
        [ForeignKey("KlubId")]
        public virtual Klub Klub { get; set; }
        [NotMapped]
        public IFormFile Slika { get; set; }
        [AllowNull]
        public string Profilna { get; set; }
        public ICollection<KlubTrener> KlubTrener { get; set; }
        [NotMapped]
        public string Password { get; set; }
        [NotMapped]
        public ICollection<string> Uloge { get; set; }
        [NotMapped]
        public string PunoIme
        {
            get 
            { 
                return Ime + " " + Prezime; 
            }
        }
    }
}
