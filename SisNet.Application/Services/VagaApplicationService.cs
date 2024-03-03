using FluentValidation;
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

        public void Add(Vaga entity)
        {
            var vaga = new Vaga
            {
                Id = Guid.NewGuid(),
                Codigo = entity.Codigo,
                Titulo = entity.Titulo,
                Descricao = entity.Descricao,
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

        public void Update(Vaga entity)
        {
            var vaga = vagaDomainService.GetById(entity.Id);

            if(vaga == null)
            {
                throw new Exception("Vaga não encontrada");
            }

            vaga.Titulo = entity.Titulo;
            vaga.Descricao = entity.Descricao;
            vaga.Codigo = entity.Codigo;
            vaga.Ativo  = entity.Ativo;

            var validation = new VagaValidation().Validate(vaga);

            if (!validation.IsValid)
            {
                throw new ValidationException(validation.Errors);
            }

            vagaDomainService.Update(vaga);
        }

        public void Remove(Vaga entity)
        {
            var vaga = vagaDomainService.GetById(entity.Id);

            if (vaga == null)
            {
                throw new Exception("Vaga não encontrada");
            }

            vagaDomainService.Remove(vaga);
        }

        public List<Vaga> GetAll()
        {
            return vagaDomainService.GetAll();
        }

        public Vaga GetById(Guid id)
        {
            return vagaDomainService.GetById(id);
        }

        public Vaga GetByCodigo(int codigo)
        {
            return vagaDomainService.GetByCodigo(codigo);
        }

        public void Dispose()
        {
            vagaDomainService.Dispose();
        }
    }
}
