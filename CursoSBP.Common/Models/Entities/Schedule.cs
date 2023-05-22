using System.ComponentModel.DataAnnotations;

namespace CursoSBP.Common.Models.Entities
{
    public class Schedule
    {
        public int Id { get; set; }
        [Key]
        //de esta manera yo especifico que es una clave foramea
        public Student? StudentSchedule { get; set; }
        [Key]
        //de esta manera yo especifico que es una clave foramea
        public Subject? SubjectSchedule { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        [StringLength(10)]
        public string? Classroom { get; set; }

    }
}
