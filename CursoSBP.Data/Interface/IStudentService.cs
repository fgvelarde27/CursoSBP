using CursoSBP.Common.Models.Entities;
using CursoSBP.Common.Models.ViewModels;

namespace CursoSBP.Data.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>?> GetStudentsAsync();

        Task<Student?> GetUniqueStudentAsync(int id);
        Task<Response> SaveNewStudentAsync(Student student);
    }
}
