using CursoSBP.Common.Models.Entities;
using CursoSBP.Common.Models.ViewModels;

namespace CursoSBP.Data.Interface
{
    public interface IStudentService
    {
        Task<IEnumerable<Student>?> GetStudentsAsync();

        Task<Student?> GetUniqueStudentAsync(int id);
        Task<bool> AddNewStudentAsync(Student student);
        Task<bool> UpdateStudentAsync(int id, Student student);
        Task<bool> DeleteStudentAsync(int id);

    }
}