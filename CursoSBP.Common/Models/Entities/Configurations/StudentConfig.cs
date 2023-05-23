using CursoSBP.Common.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Reflection.Emit;

namespace CursoSBP.Common.Models.Entities.Configurations
{
    public class StudentConfig : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.Property(p => p.FirstName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            builder.Property(p => p.LastName)
                .HasMaxLength(50)
                .IsRequired()
                .IsUnicode(false);
            builder.Property(p => p.Birthdate)
                .HasColumnType("Date");
            builder.Property(p => p.Email)
                .HasMaxLength(500)
                .IsUnicode(false);
            builder.Property(p => p.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        }
    }
}
