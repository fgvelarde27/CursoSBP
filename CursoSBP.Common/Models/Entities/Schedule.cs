using System.ComponentModel.DataAnnotations;

namespace CursoSBP.Common.Models.Entities
{
    public class Schedule
    {
        public int StudentId { get; set; }
        public int SubjectId { get; set; }
        public DateTime ScheduleDate { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string? Classroom { get; set; }
        public Student? Student { get; set; }
        public Subject? Subject { get; set; }
        public Campus? Campus { get; set; }
    }
}
