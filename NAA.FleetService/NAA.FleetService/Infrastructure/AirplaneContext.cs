using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using NAA.FleetService.Domain;

namespace NAA.FleetService.Infrastructure
{
    public sealed class AirplaneContext : DbContext
    {
        public AirplaneContext(DbContextOptions options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Airplane>(x =>
            {
                x.HasKey(y => y.Id);
                x.Property(y => y.Manufacturer);
                x.Property(y => y.Model);
                x.Property(y => y.Registration);
                x.HasData(new List<Airplane>
                {
                    new Airplane(Guid.NewGuid(), "Airbus", "A319", "N892NA"),
                    new Airplane(Guid.NewGuid(), "Airbus", "A320", "N351NA"),
                    new Airplane(Guid.NewGuid(), "Airbus", "A321", "N762NA")
                });
            });
        }

        public DbSet<Airplane> Airplanes { get; set; }
    }
}
