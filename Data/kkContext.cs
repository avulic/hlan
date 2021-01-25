using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HLAN.Models.Entitie;
using HLAN.Models;

namespace HLAN.Data
{
    public class kkContext : DbContext
    {
        public kkContext (DbContextOptions<kkContext> options)
            : base(options)
        {
        }

        public DbSet<HLAN.Models.Entitie.Klub> Klub { get; set; }

        public DbSet<HLAN.Models.Igrac> Igrac { get; set; }
    }
}
