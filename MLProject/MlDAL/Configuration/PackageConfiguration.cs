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
    public class PackageConfiguration : IEntityTypeConfiguration<Package>
    {
        public void Configure (EntityTypeBuilder<Package> builder)
        {
            builder.HasKey(p => p.PackageID);

            builder.Property(p => p.PackageName)
                .IsRequired()
                .HasMaxLength(30);

            builder.Property(p => p.PackageCost)
                .IsRequired()
                .HasColumnType("decimal(10, 2)");

            builder.Property(p => p.PackageGender)
                .HasColumnName("PackageGenderID");

            builder.Property(p => p.PackageType)
                .HasColumnName("PackageTypeID");

            builder.Property(p => p.packageStatus)
                .HasColumnName("PackageStatusID");

            builder.Property(p => p.VisitType)
                .HasColumnName("VisitTypeID");

        }
    }
}
