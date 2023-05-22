using System.ComponentModel.DataAnnotations;

namespace CursoSBP.Common.Models.Entities
{
    public class Subject
    {


        [Key]
        public int SubjectId { get; set; }
        [StringLength(100)]
        public string? SubjectName { get; set; }
        [StringLength(400)]
        public string? Object { get; set; }
        [StringLength(100)]
        public string? Teacher { get; set; }
        public Decimal CostPerCycle { get; set; }
        public bool IsActive { get; set; }
    }
}
