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

        public void Add(CandidatoPostDTO dto)
        {
            var candidato = new Candidato(
                  Guid.NewGuid(),
                  dto.Nome,
                  dto.Email,
                  dto.Link,
                  dto.Cpf,
                  dto.DataNascimento,
                  DateTime.Now);

            var validation = new CandidatoValidation().Validate(candidato);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            candidatoDomainService.Add(candidato);
        }

        public void Update(CandidatoGetDTO dto)
        {
            var candidato = candidatoDomainService.GetById(dto.Id);

            if (candidato == null)
            {
                throw new Exception("Candidato é inválido.");
            }

            var candidatoModificado = new Candidato(
                                        candidato.Id, 
                                        dto.Nome, 
                                        dto.Email, 
                                        dto.Link, 
                                        dto.Cpf, 
                                        dto.DataNascimento,
                                        candidato.DataCadastro);

            var validation = new CandidatoValidation().Validate(candidatoModificado);

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

        public List<CandidatoGetDTO> GetAll()
        {
            var candidatos = candidatoDomainService.GetAll();

            var listaCandidatos = new List<CandidatoGetDTO>();

            foreach (var c in candidatos) {
                var candidatoLido = new CandidatoGetDTO() 
                { 
                    Id = c.Id,
                    Cpf = c.Cpf,
                    Nome = c.Nome,
                    Email = c.Email,
                    Link = c.Link,
                    DataCadastro = c.DataCadastro,
                    DataNascimento = c.DataNascimento
                };

                listaCandidatos.Add(candidatoLido);
            
            }

            return listaCandidatos;
        }

        public CandidatoGetDTO GetById(Guid id)
        {
            var candidato = candidatoDomainService.GetById(id);
           
            var result = new CandidatoGetDTO()
            {
                Id = candidato.Id,
                Email = candidato.Email,
                Cpf = candidato.Cpf,
                Nome = candidato.Nome,
                Link = candidato.Link,
                DataCadastro = candidato.DataCadastro,
                DataNascimento = candidato.DataNascimento
            };

            return result;
        }

        public void Dispose()
        {
            candidatoDomainService.Dispose();
        }
    }
}
