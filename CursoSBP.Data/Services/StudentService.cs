using CursoSBP.Common.Models.Entities;
using CursoSBP.Common.Models.ViewModels;
using CursoSBP.Data.Interface;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CursoSBP.Data.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _ctx;
        public StudentService(DataContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<Student>?> GetStudentsAsync()
        {

            try
            {
                var resultListStudent = await _ctx.Students.ToListAsync();
                return resultListStudent;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }

        }
        public async Task<Student?> GetUniqueStudentAsync(int id)
        {
            try
            {
    
                var student = await _ctx.Students.FindAsync(id);

                return student;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Response> SaveNewStudentAsync(Student student)
        {
            try
            {
                var resultAddStudent = await _ctx.Students.AddAsync(student);
                var resultSaveAddStudent = await _ctx.SaveChangesAsync();
                return new Response
                {
                    IsSuccess = true,
                    Message = "Estudiante insertado correctamente.",
                    Result = student
                };
            }
            catch (Exception ex)
            {

                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message
                };
            }
        }
    }
    }

