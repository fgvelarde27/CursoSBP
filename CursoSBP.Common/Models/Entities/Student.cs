using CursoSBP.Common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoSBP.Common.Models.Entities
{
    public class Student
    {
        public int Id { get; set; } 
        //hace un referencia foreing key hacia la tabla Campus
       
        public HashSet<Campus>? Campus { get; set; } // define que la relcion es de muchos a muchos entre la tabla Student y Campus.
        [StringLength(50)]
        [Required (ErrorMessage ="*El campo nombre es obligatorio.")]
        public string? FirstName { get; set; }
        [StringLength(50)]
        public string LastName { get; set; } = default!;
        [DataType(DataType.Date)]
        public DateTime Bithdate { get; set; }
        [StringLength(100)]

        public string? Email { get; set; }
        [StringLength(9)]

        public string? Phone { get; set; }
        [StringLength(200)]

        public string? Address { get; set; }

        public Gender StudentGender { get; set; }
       
    }
}
