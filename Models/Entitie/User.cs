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
        [AllowNull]
        public Klub Klub { get; set; }
        [AllowNull]
        public String Slika { get; set; }
    }
}
