using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Configuration
{
    public class ContainingConfiguration : IEntityTypeConfiguration<Containings>
    {
        public void Configure(EntityTypeBuilder<Containings> builder)
        {

            builder.HasKey(c => c.ContainID);

            builder.HasOne(c => c.package)
                   .WithMany(c => c.containingAnalyses)
                   .HasForeignKey(c => c.PackageID);

            builder.HasOne(c => c.analysis)
                   .WithMany(c => c.containedPackages)
                   .HasForeignKey(C => C.AnalysisID);
                   

        }
    }
}
