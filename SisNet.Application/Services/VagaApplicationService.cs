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
    // aqui manipulo as regras de negócio
    public class VagaApplicationService : IVagaApplicationService
    {
        private readonly IVagaDomainService vagaDomainService;
        private readonly IMapper mapper;

        public VagaApplicationService(IVagaDomainService vagaDomainService, IMapper mapper)
        {
            this.vagaDomainService = vagaDomainService;
            this.mapper = mapper;
        }

        public async Task Add(VagaAddViewModel model)
        {            
            var vaga = mapper.Map<Vaga>(model);   

            var validation = new VagaValidation().Validate(vaga);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            await Task.Run(() => vagaDomainService.Add(vaga));
        }

        public async Task Update(VagaUpdateViewModel dto)
        {
            var existe = vagaDomainService.GetById(Guid.Parse(dto.Id));

            if (existe == null)
            {
                throw new ArgumentException("Id fornecido é inválido.");
            }

            var vagaModificada = mapper.Map<Vaga>(dto);

            var validation = new VagaValidation().Validate(vagaModificada);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            await Task.Run(() => vagaDomainService.Update(vagaModificada));
        }

        public async Task Remove(Guid id)
        {
            var vaga = vagaDomainService.GetById(id);

            if (vaga == null)
            {
                throw new Exception("Vaga não encontrada.");
            }

            await Task.Run(() => vagaDomainService.Remove(vaga));
        }

        public async Task<List<VagaDTO>> GetAll()
        {
            var lista = vagaDomainService.GetAll();
            List<VagaDTO> vagaslistaRetorno = new List<VagaDTO>();

            if (lista != null)
            {
                foreach (var item in lista)
                {
                    var vaga = mapper.Map<VagaDTO>(item);

                    vagaslistaRetorno.Add(vaga);
                }
            }

            return await Task.Run(() => vagaslistaRetorno);
        }

        public async Task<VagaDTO> GetById(Guid id)
        {
            var vaga = vagaDomainService.GetById(id);

            if (vaga == null) return null;

            var retorno = mapper.Map<VagaDTO>(vaga);

            return await Task.Run(() => retorno);
        }

        public async Task<VagaDTO> GetByCodigo(int codigo)
        {
            var vaga = vagaDomainService.GetByCodigo(codigo);

            if (vaga == null) return null;

            var retorno = mapper.Map<VagaDTO>(vaga);

            return await Task.Run(() => retorno);
        }

        public void Dispose()
        {
            vagaDomainService.Dispose();
        }
    }
}
