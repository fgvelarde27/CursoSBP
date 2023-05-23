using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoSBP.Common.Models.Entities.Configurations
{
    public class CampusConfig : IEntityTypeConfiguration<Campus>
    {
        public void Configure(EntityTypeBuilder<Campus> builder)
        {
            builder.Property(p => p.CampusName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Url)
                .HasMaxLength(1000)
                .IsUnicode(false);
        }
    }
}