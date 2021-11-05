using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace HLAN.Models.Entitie
{
    public class Utakmica
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [AllowNull]
        [DataType(DataType.DateTime)]
        public DateTime Datum { get; set; }
        [Required]
        [DisallowNull]
        public int KoloId { get; set; }
        public Kolo Kolo { get; set; }
        [Required]
        [DisallowNull]
        public int SezonaId { get; set; }
        public Sezona Sezona { get; set; }
        [Required]
        public int DomaciId { get; set; }
        [Display(Name = "Domaci")]
        public Klub Domaci { get; set; }
        [Required]
        public int GostiId { get; set; }
        [Display(Name ="Gost")]
        public Klub Gosti { get; set; }
        [AllowNull]
        public int? RezDomaci { get; set; }
        [AllowNull]
        public int? RezGosti { get; set; }
        [NotMapped]
        public string Naziv
        {
            get
            {
                return Sezona?.Godina.ToString() + " " + Kolo?.Br.ToString() + " " + Domaci?.Naziv + " vs " + Gosti?.Naziv;
            }
        }

    }
}
