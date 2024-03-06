using AutoMapper;
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
        private readonly IMapper mapper;

        public CandidatoApplicationService(ICandidatoDomainService candidatoDomainService, IMapper mapper)
        {
            this.candidatoDomainService = candidatoDomainService;
            this.mapper = mapper;
        }

        public void Add(CandidatoPostDTO dto)
        {
            var candidato = mapper.Map<Candidato>(dto);

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

            var candidatoModificado = new Candidato(
                                                    candidato.Id,
                                                    dto.Nome, 
                                                    dto.Email, 
                                                    dto.Cpf, 
                                                    dto.Link, 
                                                    dto.DataNascimento,
                                                    dto.DataCadastro);

            var validation = new CandidatoValidation().Validate(candidatoModificado);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            candidatoDomainService.Update(candidatoModificado);
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

        public List<CandidatoDTO> GetAll()
        {
            var candidatos = candidatoDomainService.GetAll();

            var listaCandidatos = new List<CandidatoDTO>();

            foreach (var c in candidatos) {

                var candidatoLido = mapper.Map<CandidatoDTO>(c);
                listaCandidatos.Add(candidatoLido);            
            }

            return listaCandidatos;
        }

        public CandidatoDTO GetById(Guid id)
        {
            var candidato = candidatoDomainService.GetById(id);

            var candidatoLido = mapper.Map<CandidatoDTO>(candidato);

            return candidatoLido;
        }

        public void Dispose()
        {
            candidatoDomainService.Dispose();
        }
    }
}
