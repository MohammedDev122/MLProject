using Core.Models;
using Microsoft.EntityFrameworkCore;
using MlDAL.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.DbContexts
{
    public partial class AppDbContext : DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext> options) : base(options)
        { }


        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Region> Regions { get; set; }
        public virtual DbSet<Lab> Laps { get; set; }


        public virtual DbSet<Analysis> Analysis { get; set; }
        public virtual DbSet<Containings> Containings { get; set; }
        public virtual DbSet<Package> Packages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnalysisConfiguration());   
            modelBuilder.ApplyConfiguration(new ContainingConfiguration());
            modelBuilder.ApplyConfiguration(new PackageConfiguration());
            modelBuilder.ApplyConfiguration(new LabsConfiguration());
            modelBuilder.ApplyConfiguration(new CityConfiguration());
            modelBuilder.ApplyConfiguration(new RegionConfiguration());

            base.OnModelCreating(modelBuilder);
        }

    }
}
