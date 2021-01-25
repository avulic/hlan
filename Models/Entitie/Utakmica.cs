using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;

namespace HLAN.Models.Entitie
{
    public class Utakmica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [AllowNull]
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Datum { get; set; }
        [AllowNull]
        public Kolo Kolo { get; set; }
        public Sezona Sezona { get; set; }
        [Required]
        public Klub Domaci { get; set; }
        [Required]
        public Klub Gosti { get; set; }
        [AllowNull]
        public int? RezDomaci { get; set; }
        [AllowNull]
        public int? RezGosti { get; set; }

    }
}
