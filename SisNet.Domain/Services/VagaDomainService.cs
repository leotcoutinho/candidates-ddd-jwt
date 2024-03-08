using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Interfaces.Services;
using SisNet.Domain.Models;

namespace SisNet.Domain.Services
{
    public class VagaDomainService : BaseDomainService<Vaga>, IVagaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public VagaDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.VagaRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Add(Vaga entity)
        {
            var existCode = GetByCodigo(entity.Codigo);

            if (existCode != null)
            {
                throw new ArgumentException("Código já existe.");
            }

            base.Add(entity);
        }

        public Vaga GetByCodigo(int codigo)
        {
           return unitOfWork.VagaRepository.GetByCodigo(codigo);
        }
    }
}
