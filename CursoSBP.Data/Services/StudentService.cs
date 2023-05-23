using CursoSBP.Common.Models.Entities;
using CursoSBP.Data.Interface;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CursoSBP.Data.Services
{
    public class StudentService : IStudentService
    {
        private readonly DataContext _ctx;
        private readonly ILogger<StudentService> _logger;
        public StudentService(DataContext ctx, ILogger<StudentService> logger)
        {
            _ctx = ctx;
            _logger = logger;
        }

        /// <summary>
        /// Get a List of all Student.Return an object of type Student
        /// </summary>
        /// <returns></returns>
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
        /// <summary>
        /// Add new student to the database
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> AddNewStudentAsync(Student student)
        {
            try
            {
                var resultAddStudent = await _ctx.Students.AddAsync(student);
                
                //return new Response
                //{
                //    IsSuccess = true,
                //    Message = "Estudiante insertado correctamente.",
                //    Result = student
                //};
                return (await _ctx.SaveChangesAsync() > 0);
            }
            catch (Exception ex)
            {
                {
                    _logger.LogError(ex, "Error attempt saving student.");
                    return false;
                }
                //return new Response
                //{
                //    IsSuccess = false,
                //    Message = ex.Message
                //};
            }
        }
        /// <summary>
        /// Delete student fro database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<bool> DeleteStudentAsync(int id)
        {
            try
            {
                var std = await _ctx.Students.FindAsync(id);
                if (std == null)
                    return false;
                var result = _ctx.Students.Remove(std);
                await _ctx.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error attempt delete student.");
                return false;
            }
        }
        /// <summary>
        /// Update a student in the database
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        public async Task<bool> UpdateStudentAsync(int id, Student student)
        {
            try
            {
                if (student.Id > 0 && id == student.Id) //Validate call for update student.
                {
                    Student? stdEntity = await _ctx.Students.FindAsync(id);
                    if (stdEntity is null) return false;
                    await student.MapToStudentEntity(stdEntity);
                    return (await _ctx.SaveChangesAsync() >= 0);
                }
                else return false;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating the student.");
                return false;
            }
        }
    
}
}

