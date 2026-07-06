using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MlDAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Configuration
{
    internal class AnalysisConfiguration : IEntityTypeConfiguration<AnalysisDto>
    {
        public void Configure(EntityTypeBuilder<AnalysisDto> builder)
        {
            builder.HasKey(e => e.AnalysisID);

            builder.Property(e => e.AnalysisName)
                   .HasMaxLength(20);

            builder.Property(e => e.AnalysisCost)
                   .HasColumnType("decimal(10, 2)");
        }


    }
}
