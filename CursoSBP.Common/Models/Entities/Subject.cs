using System.ComponentModel.DataAnnotations;

namespace CursoSBP.Common.Models.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string? SubjectName { get; set; }
        public string? Objectives { get; set; }
        public string? TeacherName { get; set; }
        public decimal CostPerCycle { get; set; }
        public bool IsActive { get; set; }
    }
}
