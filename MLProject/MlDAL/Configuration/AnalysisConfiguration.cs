using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Configuration
{
    public class AnalysisConfiguration : IEntityTypeConfiguration<Analysis>
    {
        public void Configure(EntityTypeBuilder<Analysis> builder)
        {
            builder.HasKey(e => e.AnalysisId);

            builder.Property(e => e.AnalysisName)
                   .HasMaxLength(20);

            builder.Property(e => e.Cost)
                   .HasColumnType("decimal(18, 0)");
        }

    }
}
