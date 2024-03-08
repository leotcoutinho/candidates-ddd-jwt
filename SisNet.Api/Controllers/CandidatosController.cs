using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SisNet.Api.Adapters;
using SisNet.Application.Interfaces;
using SisNet.Application.ViewModels;

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
        public async Task<IActionResult> Add(CandidatoAddViewModel dto)
        {
            try
            {
                await candidatoApplicationService.Add(dto);

                return Ok(new { Message = "Candidato adicionado com sucesso."});
            }
            catch (ValidationException ex)
            {
                return BadRequest(ValidationAdapter.Parse(ex.Errors));
            }
            catch (Exception e)
            {
               return StatusCode(500, e.Message);
            }            
        }

        [HttpPut]
        public async Task<IActionResult> Update(CandidatoUpdateViewModel dto)
        {
            try
            {
                await candidatoApplicationService.Update(dto);

                return Ok(new { Message = "Candidato atualizado com sucesso." });
            }
            catch (ValidationException ex)
            {
                return BadRequest(ValidationAdapter.Parse(ex.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                await candidatoApplicationService.Remove(id);

                return Ok(new { Message = "Candidato removido com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            var candidatos = await candidatoApplicationService.GetAll();
            return Ok(candidatos);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> Get(string id)
        {
            var candidato = await candidatoApplicationService.GetById(Guid.Parse(id));

            if(candidato == null)
            {
                return NotFound();
            }

            return Ok(candidato);
        }
    }
}
