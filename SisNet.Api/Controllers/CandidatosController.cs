using Microsoft.AspNetCore.Mvc;
using SisNet.Application.DTO;
using SisNet.Application.Interfaces;

namespace SisNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidatosController : ControllerBase
    {
        private readonly ICandidatoApplicationService candidatoApplicationService;

        public CandidatosController(ICandidatoApplicationService applicationService)
        {
            this.candidatoApplicationService = applicationService;
        }

        [HttpPost]
        public IActionResult Post(CandidatoDTO dto)
        {
            try
            {
                candidatoApplicationService.Add(dto);

                return Ok(new { Message = "Candidato adicionado com sucesso."});
            }
            catch (Exception e)
            {
               return StatusCode(500, e.Message);
            }            
        }

        [HttpPut]
        public IActionResult Put(CandidatoDTO dto)
        {
            try
            {
                candidatoApplicationService.Update(dto);
                return Ok(new { Message = "Candidato atualizado com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
           
        }

        [HttpDelete("id")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                candidatoApplicationService.Remove(id);
                return Ok(new { Message = "Candidato removido com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            var candidatos = candidatoApplicationService.GetAll();
            return Ok(candidatos);
        }

        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            var candidato = candidatoApplicationService.GetById(id);

            if(candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }
    }
}
