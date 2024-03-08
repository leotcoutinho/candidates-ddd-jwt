using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SisNet.Api.Adapters;
using SisNet.Application.Interfaces;
using SisNet.Application.ViewModels;

namespace SisNet.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VagasController : ControllerBase
    {
        private readonly IVagaApplicationService vagaApplicationService;

        public VagasController(IVagaApplicationService vagaApplicationService)
        {
            this.vagaApplicationService = vagaApplicationService;
        }

        [HttpPost()]
        public async Task<IActionResult> Post(VagaAddViewModel dto)
        {
            try
            {    
                await vagaApplicationService.Add(dto);

                return Ok(new { Message = "Vaga cadastrada com sucesso." });
            }
            catch(ValidationException ex)
            {
                return BadRequest(ValidationAdapter.Parse(ex.Errors));
            }
            catch(ArgumentException ae)
            {
                return BadRequest(ae.Message);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut()]
        public async Task<IActionResult> Put(VagaUpdateViewModel dto)
        {
            try
            { 
                await vagaApplicationService.Update(dto);

                return Ok("Vaga Atualizada com sucesso.");
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
        public async Task<IActionResult> Delete(string id)
        {
            try
            {
                await vagaApplicationService.Remove(Guid.Parse(id));

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> Get()
        {
            try
            {
                var vagas = await vagaApplicationService.GetAll();
                return Ok(vagas);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetById")]
        public IActionResult Get(string id)
        {
            try
            {
                var vaga = vagaApplicationService.GetById(Guid.Parse(id));

                if (vaga == null)
                {
                    return NotFound();
                }

                return Ok(vaga);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("GetByCodigo")]
        public IActionResult Get(int codigo)
        {
            try
            {
                var vaga = vagaApplicationService.GetByCodigo(codigo);

                if (vaga == null)
                {
                    return NotFound("Vaga não encontrada.");
                }

                return Ok(vaga);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

    }
}
