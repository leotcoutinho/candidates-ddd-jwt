using FluentValidation;
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

        public void Add(Candidato entity)
        {
            var candidato = new Candidato
            {
                Id = Guid.NewGuid(),
                Nome = entity.Nome,
                Email = entity.Email,
                Link = entity.Link,
                Cpf = entity.Cpf,
                DataNascimento = entity.DataNascimento,
                DataCadastro = DateTime.Now
            };

            var validation = new CandidatoValidation().Validate(candidato);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            candidatoDomainService.Add(candidato);
        }

        public void Update(Candidato entity)
        {
            var candidato = candidatoDomainService.GetById(entity.Id);

            if (candidato == null)
            {
                throw new Exception("Candidato é inválido.");
            }

            candidato.Nome = entity.Nome;
            candidato.Email = entity.Email;
            candidato.Cpf = entity.Cpf;
            candidato.Link = entity.Link;
            candidato.DataNascimento = entity.DataNascimento;

            var validation = new CandidatoValidation().Validate(candidato);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            candidatoDomainService.Update(candidato);
        }

        public void Remove(Candidato entity)
        {
            var candidato = candidatoDomainService.GetById(entity.Id);

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
