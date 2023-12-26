using Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;

namespace Var1API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Help> Helps { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Travel> Travels { get; set; }
        public DbSet<TravelApplication> TravelApplications { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Help>().ToTable("Help");
            modelBuilder.Entity<Member>().ToTable("Memeber");
            modelBuilder.Entity<Travel>().ToTable("Travel");
            modelBuilder.Entity<TravelApplication>().ToTable("TravelApplication");
            base.OnModelCreating(modelBuilder);
        }
    }
}
