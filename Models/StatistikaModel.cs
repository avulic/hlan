using HLAN.Models.Entitie;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HLAN.Models
{
    public class StatistikaModel
    {
        public StatistikaIgraca Statistika { get; set; }
        public IEnumerable<StatistikaIgraca> StatistikaIgraca { get; set; }
    }
}
