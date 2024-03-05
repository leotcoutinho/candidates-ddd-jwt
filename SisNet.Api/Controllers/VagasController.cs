using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using SisNet.Api.Adapters;
using SisNet.Application.DTO;
using SisNet.Application.Interfaces;
using SisNet.Domain.Models;

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

        [HttpPost]
        public IActionResult Post(VagaPostDTO dto)
        {
            try
            {
                vagaApplicationService.Add(dto);
                return Ok(new { Message = "Vaga cadastrada com sucesso." });
            }
            catch(ValidationException ex)
            {
                return BadRequest(ValidationAdapter.Parse(ex.Errors));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(VagaGetDTO dto)
        {
            try
            {
                vagaApplicationService.Update(dto);
                return Ok();
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

        [HttpDelete("id")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                vagaApplicationService.Remove(id);
                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var vagas = vagaApplicationService.GetAll();
                return Ok(vagas);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("id")]
        public IActionResult Get(Guid id)
        {
            try
            {
                var vaga = vagaApplicationService.GetById(id);

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

        [HttpGet("codigo")]
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
