using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoSBP.Common.Models.Entities
{
    public class Subject
    {
        [Key]
        public int SubjectId { get; set; }
        public string? SubjectName { get; set; }
        public string? Object { get; set; }
        public string? Teacher { get; set; }
        public bool IsActive { get; set; }
    }
}
