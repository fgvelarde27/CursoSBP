using CursoSBP.Common.Models.Entities;
using CursoSBP.Common.Models.ViewModels;
using CursoSBP.Data;
using CursoSBP.Data.Interface;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CursoSBP.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // private readonly DataContext _ctx;
        private readonly IStudentService _studentService;
        //public StudentController(DataContext ctx)
        //{
        //    _ctx = ctx;
        //}
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        /// <summary>
        /// Get all Student from the database CursoSBP.
        /// </summary>
        /// <returns></returns>
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        //{
        //    try
        //    {
        //        List<Student> listStudentStudent = await _ctx.Students.ToListAsync();
        //        return Ok(listStudentStudent);
        //    }
        //    catch(Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }
                
        //}

    /// <summary>
    /// Get a Student
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Student>>GetUniqueStudent(int id)
        //{
        //   try
        //    {
        //        //Student? student = null;
        //       var  student = await _ctx.Students.FindAsync(id);               
        //         return student == null  ? NotFound("Registro del estudiante no encontrado") : Ok(student);
        //    }
        //    catch (Exception ex)
        //    {
        //        return BadRequest(ex.Message);
        //    }


        //}

      /// <summary>
      /// inserta un nuevo estudiante
      /// </summary>
      /// <param name="student"></param>
      /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody] Student student)
        {
            try
            {
           var resultNewStudent=  await _studentService.SaveNewStudentAsync(student);
                if (!resultNewStudent.IsSuccess)
                    return BadRequest("No pudo insertar el nuevo estudiante");
                return Ok(resultNewStudent.Result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
               
            }
        }

      ///// <summary>
      ///// Actualizar registro de estudiante
      ///// </summary>
      ///// <param name="id"></param>
      ///// <param name="student"></param>
      ///// <returns></returns>
      //  [HttpPut("{id}")]
      //  public async Task<ActionResult<Response>> Put(int id, [FromBody] Student student )
      //  {
      //      try
      //      {
      //          var StudentExists = await _ctx.Students.FindAsync(id);
      //          if (StudentExists == null) return NotFound("No existe el registro del estudiante");
      //          StudentExists.FirstName = student.FirstName;
      //          StudentExists.LastName = student.LastName;
      //          StudentExists.Email = student.Email;
      //          StudentExists.Phone = student.Phone;
      //          StudentExists.Bithdate=student.Bithdate;
      //          StudentExists.StudentGender = student.StudentGender;
      //          StudentExists.Address=student.Address;
            
      //          var resultSaveAddStudent = await _ctx.SaveChangesAsync();
      //          return Ok(new Response
      //          {
      //              IsSuccess = true,
      //              Message = "Registro del estudiante actualizado correctamente.",
      //              Result = student
      //          });
      //      }
      //      catch (Exception ex)
      //      {

      //          return BadRequest(new Response
      //          {
      //              IsSuccess = false,
      //              Message = ex.Message
      //          });
      //      }
      //  }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
