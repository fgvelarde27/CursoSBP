using Azure;
using Microsoft.AspNetCore.Mvc;
using Response = CursoSBP.Common.Models.ViewModels.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CursoSBP.WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseOrderController : ControllerBase
    {
       
        [HttpGet]
        public IEnumerable<Response> Get()
        {
            var response1 = new Response()
            {
                IsSuccess = true,
                Message="ok",
                Result="Este es mi primer response"
            };
            var response2 = new Response()
            {
                IsSuccess = false,
                Message = "Error",
                Result = "Este es mi primer response 2"
            };

            List<Response> listresult = new List<Response>() { response1, response2 };

            return listresult;
        }

        // GET api/<PurchaseOrderController>/5
        [HttpGet("{id}")]

        public  ActionResult<Response> Get(int id)
        {
            var respuesta = new Response()
            {
                IsSuccess = true,
                Message = "ok HTTP",
                Result = $"Usted esta consultando el registro numero {id}"
            };
            return Ok(respuesta);
        }
       

        // POST api/<PurchaseOrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<PurchaseOrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<PurchaseOrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
