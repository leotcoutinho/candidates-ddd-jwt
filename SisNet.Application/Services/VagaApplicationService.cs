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

        public VagaApplicationService(IVagaDomainService vagaDomainService)
        {
            this.vagaDomainService = vagaDomainService;
        }

        public void Add(VagaPostDTO dto)
        {
            var vaga = new Vaga(
                Guid.NewGuid(), 
                dto.Codigo,
                dto.Titulo,
                dto.Descricao,
                DateTime.Now,true);

            var validation = new VagaValidation().Validate(vaga);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            vagaDomainService.Add(vaga);
        }

        public void Update(VagaGetDTO dto)
        {
            var vaga = vagaDomainService.GetById(dto.Id);

            if (vaga == null)
            {
                throw new Exception("Vaga não encontrada");
            }

            var vagaAtualizada = new Vaga(
                        vaga.Id,
                        dto.Codigo, 
                        dto.Titulo, 
                        dto.Descricao, 
                        vaga.DataCadastro, 
                        vaga.Ativo);           

            var validation = new VagaValidation().Validate(vagaAtualizada);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            vagaDomainService.Update(vaga);
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

        public List<VagaGetDTO> GetAll()
        {
            var lista = vagaDomainService.GetAll();
            List<VagaGetDTO> vagas = new List<VagaGetDTO>();

            if (lista != null)
            {
                foreach (var item in vagas)
                {
                    var v = new VagaGetDTO()
                    {
                        Id = item.Id,
                        Codigo = item.Codigo,
                        DataCadastro = item.DataCadastro,
                        Descricao = item.Descricao,
                        Titulo = item.Titulo,
                        Ativo = item.Ativo
                    };

                    vagas.Add(v);
                }
            }

            return vagas;
        }

        public VagaGetDTO GetById(Guid id)
        {
            var vaga = vagaDomainService.GetById(id);

            if (vaga == null) return null;

            var vagaDto = new VagaGetDTO()
            {
                Id = vaga.Id,
                Codigo = vaga.Codigo,
                DataCadastro = vaga.DataCadastro,
                Descricao = vaga.Descricao,
                Titulo = vaga.Titulo,
                Ativo = vaga.Ativo
            };

            return vagaDto;
        }

        public VagaGetDTO GetByCodigo(int codigo)
        {
            var vaga = vagaDomainService.GetByCodigo(codigo);

            if (vaga == null) return null;
            
            var vagaDto = new VagaGetDTO()
            {
                Id = vaga.Id,
                Codigo = vaga.Codigo,
                DataCadastro = vaga.DataCadastro,
                Descricao = vaga.Descricao,
                Titulo = vaga.Titulo,
                Ativo = vaga.Ativo
            };

            return vagaDto;
        }

        public void Dispose()
        {
            vagaDomainService.Dispose();
        }
    }
}
