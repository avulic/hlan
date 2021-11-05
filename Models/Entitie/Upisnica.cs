using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models.Entitie
{
    public class Upisnica
    {
        [Key]
        [DisplayName("Br.")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public String UserId { get; set; }
        [DisplayName("Igrač")]
        public User User { get; set; }
        [NotMapped]
        [RegularExpression("True", ErrorMessage = "Morate prihvatiti uvjete")]
        public bool PrihvaceniUvjeti { get; set; }
        public bool Potvrdena { get; set; }
    }
}
