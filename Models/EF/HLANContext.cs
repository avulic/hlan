using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HLAN.Models.Entitie;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HLAN.Models.EF
{
    public class HLANContext : IdentityDbContext<User>
    {
        public HLANContext(DbContextOptions<HLANContext> options)
            : base(options)
        {
        }

        public DbSet<Klub> Klubovi { get; set; }
        public DbSet<Utakmica> Utakmice { get; set; }
        public DbSet<Upisnica> Upisnice { get; set; }
        public DbSet<StatistikaIgraca> StatistikaIgraca { get; set; }
        public DbSet<Sezona> Sezone { get; set; }
        public DbSet<Kolo> Kola { get; set; }
        public DbSet<KlubTrener> KlubTreneri { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            //builder.Entity<Upisnica>()
            //    .HasIndex(u => u.UserId)
            //    .IsUnique(true);

        }
    }
}
