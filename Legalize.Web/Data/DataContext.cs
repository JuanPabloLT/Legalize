using Legalize.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<TripEntity> Trips { get; set; }

        public DbSet<LegalizeEntity> Legalizes { get; set; }


        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TripEntity>()
                .HasIndex(t => t.Id)
                .IsUnique();
        }*/
    }
}
