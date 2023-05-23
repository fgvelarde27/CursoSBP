using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CursoSBP.Common.Models.Entities.Configurations
{
    public class ScheduleConfig : IEntityTypeConfiguration<Schedule>
    {
        public void Configure(EntityTypeBuilder<Schedule> builder)
        {
            builder.HasKey(k => new { k.StudentId, k.SubjectId, k.ScheduleDate });
            builder.Property(p => p.ScheduleDate)
                .HasColumnType("date");
            builder.Property(p => p.Classroom)
                .HasMaxLength(50)
                .IsUnicode(false);
        }
    }
}
