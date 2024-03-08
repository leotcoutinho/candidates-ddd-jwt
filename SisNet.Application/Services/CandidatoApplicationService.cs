using AutoMapper;
using FluentValidation;
using SisNet.Application.DTO;
using SisNet.Application.Interfaces;
using SisNet.Application.ViewModels;
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

        public async Task Add(CandidatoAddViewModel dto)
        {
            var candidato = mapper.Map<Candidato>(dto);

            var validation = new CandidatoValidation().Validate(candidato);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            await Task.Run(() => candidatoDomainService.Add(candidato));
        }

        public async Task Update(CandidatoUpdateViewModel dto)
        {
            var candidatoModificado = mapper.Map<Candidato>(dto); 

            var validation = new CandidatoValidation().Validate(candidatoModificado);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            await Task.Run(() => candidatoDomainService.Update(candidatoModificado));
        }

        public async Task Remove(Guid id)
        {
            var candidato = candidatoDomainService.GetById(id);

            if (candidato == null)
            {
                throw new Exception("Candidato não encontrado.");
            }

            await Task.Run(() => candidatoDomainService.Remove(candidato));
        }

        public async Task<List<CandidatoDTO>> GetAll()
        {
            var candidatos = candidatoDomainService.GetAll();

            var listaCandidatos = new List<CandidatoDTO>();

            foreach (var c in candidatos) {

                var candidatoLido = mapper.Map<CandidatoDTO>(c);
                listaCandidatos.Add(candidatoLido);            
            }

            return await Task.Run(() => listaCandidatos);
        }

        public async Task<CandidatoDTO> GetById(Guid id)
        {
            var candidato = candidatoDomainService.GetById(id);

            var candidatoLido = mapper.Map<CandidatoDTO>(candidato);

            return await Task.Run(() => candidatoLido);
        }

        public void Dispose()
        {
            candidatoDomainService.Dispose();
        }
    }
}
