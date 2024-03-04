using FluentValidation;
using SisNet.Application.DTO;
using SisNet.Application.Interfaces;
using SisNet.Domain.Interfaces.Services;
using SisNet.Domain.Models;
using SisNet.Domain.Validations;

namespace SisNet.Application.Services
{
    public class CandidatoApplicationService : ICandidatoApplicationService
    {
        private readonly ICandidatoDomainService candidatoDomainService;

        public CandidatoApplicationService(ICandidatoDomainService candidatoDomainService)
        {
            this.candidatoDomainService = candidatoDomainService;
        }

        public void Add(CandidatoDTO dto)
        {
            var candidato = new Candidato
            {
                Id = Guid.NewGuid(),
                Nome = dto.Nome,
                Email = dto.Email,
                Link = dto.Link,
                Cpf = dto.Cpf,
                DataNascimento = dto.DataNascimento,
                DataCadastro = DateTime.Now
            };

            var validation = new CandidatoValidation().Validate(candidato);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            candidatoDomainService.Add(candidato);
        }

        public void Update(CandidatoDTO dto)
        {
            var candidato = candidatoDomainService.GetById(dto.Id);

            if (candidato == null)
            {
                throw new Exception("Candidato é inválido.");
            }

            candidato.Nome = dto.Nome;
            candidato.Email = dto.Email;
            candidato.Cpf = dto.Cpf;
            candidato.Link = dto.Link;
            candidato.DataNascimento = dto.DataNascimento;

            var validation = new CandidatoValidation().Validate(candidato);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            candidatoDomainService.Update(candidato);
        }

        public void Remove(Guid id)
        {
            var candidato = candidatoDomainService.GetById(id);

            if (candidato == null)
            {
                throw new Exception("Candidato não encontrado.");
            }

            candidatoDomainService.Remove(candidato);
        }

        public List<Candidato> GetAll()
        {
            return candidatoDomainService.GetAll();
        }

        public Candidato GetById(Guid id)
        {
            return candidatoDomainService.GetById(id);
        }

        public void Dispose()
        {
            candidatoDomainService.Dispose();
        }
    }
}
