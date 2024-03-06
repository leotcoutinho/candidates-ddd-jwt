using AutoMapper;
using FluentValidation;
using SisNet.Application.DTO;
using SisNet.Application.Interfaces;
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

        public void Add(VagaPostDTO dto)
        {   
            var vaga = mapper.Map<Vaga>(dto);   

            var validation = new VagaValidation().Validate(vaga);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            vagaDomainService.Add(vaga);
        }

        public void Update(VagaDTO dto)
        {
            var vagaAtualizada = mapper.Map<Vaga>(dto);

            var validation = new VagaValidation().Validate(vagaAtualizada);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            vagaDomainService.Update(vagaAtualizada);
        }

        public void Remove(Guid id)
        {
            var vaga = vagaDomainService.GetById(id);

            if (vaga == null)
            {
                throw new Exception("Vaga não encontrada.");
            }

            vagaDomainService.Remove(vaga);
        }

        public List<VagaDTO> GetAll()
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

            return vagaslistaRetorno;
        }

        public VagaDTO GetById(Guid id)
        {
            var vaga = vagaDomainService.GetById(id);

            if (vaga == null) return null;

            var retorno = mapper.Map<VagaDTO>(vaga);

            return retorno;
        }

        public VagaDTO GetByCodigo(int codigo)
        {
            var vaga = vagaDomainService.GetByCodigo(codigo);

            if (vaga == null) return null;

            var retorno = mapper.Map<VagaDTO>(vaga);

            return retorno;
        }

        public void Dispose()
        {
            vagaDomainService.Dispose();
        }
    }
}
