using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace MlDAL.Configuration
{
    public class RegionConfiguration : IEntityTypeConfiguration<Region>
    {

        public void Configure (EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(r => r.RegionID);

            builder.Property(r => r.Name)
                .IsRequired()
                .HasMaxLength(25)
                .HasColumnName("RegionName");

            builder.HasOne(r => r.city)
                .WithMany(c => c.Regions)
                .HasForeignKey(r => r.CityId);

        }
    }
}
