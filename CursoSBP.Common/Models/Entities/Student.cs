using CursoSBP.Common.Enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoSBP.Common.Models.Entities
{
    public class Student
    {
      
        public HashSet<Campus>? Campus { get; set; } // define que la relcion es de muchos a muchos entre la tabla Student y Campus.
        public int Id { get; set; }
        //hace un referencia foreing key hacia la tabla Campus

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? Birthdate { get; set; }

        [EmailAddress(ErrorMessage = "Debe ingresar un correo válido.")]
        public string? Email { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public Gender StudentGender { get; set; }

        #region Mapping for create or update
        public async Task<bool> MapToStudentEntity(Student s)
        {
            try
            {
                s.Id = Id;
                if (FirstName is not null)
                    s.FirstName = FirstName;
                if (LastName is not null)
                    s.LastName = LastName;
                if (Birthdate is not null)
                    s.Birthdate = Birthdate;
                if (Email is not null)
                    s.Email = Email;
                if (Phone is not null)
                    s.Phone = Phone;
                if (Address is not null)
                    s.Address = Address;
                s.StudentGender = StudentGender;
                return await Task.FromResult(true);
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
