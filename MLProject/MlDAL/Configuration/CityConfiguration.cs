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
    public class CityConfiguration : IEntityTypeConfiguration<City>
    {
        public  void Configure (EntityTypeBuilder<City> builder)
        {
            builder.HasKey(c => c.CityId);

            builder.Property(c => c.Name)
               .IsRequired()
               .HasMaxLength(25)
               .HasColumnName("City");

        }
    }
}
