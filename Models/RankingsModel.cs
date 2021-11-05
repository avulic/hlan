using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HLAN.Models
{
    public class RankingsModel
    {
        public int Br { get; set; }
        public int P { get; set; }
        public int W{ get; set; }
        public int L{ get; set; }
        public int N { get; set; }
        public int Pts { get; set; }
        [JsonPropertyName("Naziv")]
        public String Klub { get; set; }
    }
}
