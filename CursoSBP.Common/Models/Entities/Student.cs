using CursoSBP.Common.Enums;

namespace CursoSBP.Common.Models.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime Bithdate { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public Gender StudentGender { get; set; }

    }
}
