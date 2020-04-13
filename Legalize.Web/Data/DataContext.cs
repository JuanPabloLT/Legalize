using Legalize.Web.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Legalize.Web.Data
{
    public class DataContext : IdentityDbContext<UserEntity>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<LegalizeEntity> Legalizes { get; set; }
        public DbSet<TripEntity> Trips { get; set; }
        public DbSet<TripDetailEntity> TripDetails { get; set; }
        public DbSet<CityEntity> Cities { get; set; }
        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<LegalizeEntity>()
                .HasIndex(t => t.EmployeeId)
                .IsUnique();
        }
    }
}
