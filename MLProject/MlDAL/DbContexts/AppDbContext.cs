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

        public virtual DbSet<Analysis> Analyses { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AnalysisConfiguration());   
        }

    }
}
