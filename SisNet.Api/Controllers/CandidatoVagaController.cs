using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SisNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatoVagaController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post()
        {
            return Ok();
        }       

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            return Ok();
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
    }
}
