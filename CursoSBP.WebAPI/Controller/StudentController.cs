using CursoSBP.Common.Models.Entities;
using CursoSBP.Data.Interface;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CursoSBP.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class StudentController : ControllerBase
    {
        // private readonly DataContext _ctx;
        //define variable of the interfase created in Data project
        private readonly IStudentService _studentService;
        //forma antigua
        //public StudentController(DataContext ctx)
        //{
        //    _ctx = ctx;
        //}
        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        /// <summary>
        /// Get all Student from the database CursoSBP. (forma antigua)
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
        /// Get all Student from the database CursoSBP. (forma utilizando dentro de Curso.Data)
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<Student>))]
        public async Task<ActionResult<IEnumerable<Student>>> GetStudents()
        {
            try
            {
                return Ok((List<Student>?)await _studentService.GetStudentsAsync());

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        /// <summary>
        /// Get a Student (forma antigua)
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
        /// Get a Student (utilizando el contexto en Curso.Data)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<Student>> GetUniqueStudent(int id)
        {
            try
            {
                //Student? student = null;
                var student = await _studentService.GetUniqueStudentAsync(id);
                return student == null ? NotFound("Registro del estudiante no encontrado") : Ok(student);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }


        }


        /// <summary>
        /// inserta un nuevo estudiante
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult> PostStudent([FromBody] Student student)
        {
            try
            {
                if (!ModelState.IsValid) return BadRequest("Model invalid");
                bool SuccessAddStudent = await _studentService.AddNewStudentAsync(student);
                return (SuccessAddStudent)
                   ? CreatedAtAction(nameof(GetUniqueStudent), new { id = student.Id }, student)
                   : BadRequest("No se puede agregar el nuevo estudiante");

                //if (!resultNewStudent.IsSuccess)
                //    return BadRequest("No pudo insertar el nuevo estudiante");
                //return Ok(resultNewStudent.Result);  
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        /// <summary>
        /// Update a student specify an Id.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="student"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status202Accepted, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> PutStudent(int id, [FromBody] Student student)
        {
            if (id != student.Id) return BadRequest();
            bool isUpdated = await _studentService.UpdateStudentAsync(id, student);
            return (isUpdated)
                ? Accepted(await _studentService.GetUniqueStudentAsync(id))
                : NotFound();
        }
        /// <summary>
        /// Delete a student.
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(Student))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            bool sucessDelete = await _studentService.DeleteStudentAsync(id);
            return (sucessDelete) ? NoContent() : NotFound();
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


    }
}
