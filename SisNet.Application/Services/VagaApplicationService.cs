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

        public void Add(VagaDTO dto)
        {
            var vaga = new Vaga
            {
                Id = Guid.NewGuid(),
                Codigo = dto.Codigo,
                Titulo = dto.Titulo,
                Descricao = dto.Descricao,
                DataCadastro = DateTime.Now,
                Ativo = true
            };

            var validation = new VagaValidation().Validate(vaga);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            vagaDomainService.Add(vaga);
        }

        public void Update(VagaDTO dto)
        {
            var vaga = vagaDomainService.GetById(dto.Id);

            if (vaga == null)
            {
                throw new Exception("Vaga não encontrada");
            }

            vaga.Titulo = dto.Titulo;
            vaga.Descricao = dto.Descricao;
            vaga.Codigo = dto.Codigo;
            vaga.Ativo = dto.Ativo;

            var validation = new VagaValidation().Validate(vaga);

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

        public List<VagaDTO> GetAll()
        {
            var lista = vagaDomainService.GetAll();
            List<VagaDTO> vagas = new List<VagaDTO>();

            if (lista != null)
            {
                foreach (var item in vagas)
                {
                    var v = new VagaDTO()
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

        public VagaDTO GetById(Guid id)
        {
            var vaga = vagaDomainService.GetById(id);

            if (vaga == null)
            {
                throw new Exception("Vaga não encontrada.");
            }

            var vagaDto = new VagaDTO()
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

        public VagaDTO GetByCodigo(int codigo)
        {
            var vaga = vagaDomainService.GetByCodigo(codigo);

            if (vaga == null)
            {
                throw new Exception("Vaga não encontrada.");
            }

            var vagaDto = new VagaDTO()
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
