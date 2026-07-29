using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MlDAL.Configuration
{
    public class LabsConfiguration : IEntityTypeConfiguration<Lab>
    {
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("LapName");

            builder.Property(x => x.Address)
               .IsRequired()
               .HasMaxLength(120)
               .HasColumnName("LapAddress");

            builder.HasOne(x => x.Region)
                .WithMany(r => r.labs)
                .HasForeignKey(x => x.RegionId);

            builder.Property(x => x.labType)
                .HasColumnName("LapTypeID");

            builder.Property(x => x.Status)
                .HasColumnName("LapStatusID");


        }
    }
}
