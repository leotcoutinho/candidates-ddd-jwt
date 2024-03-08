using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Interfaces.Services;
using SisNet.Domain.Models;

namespace SisNet.Domain.Services
{
    public class CandidatoDomainService : BaseDomainService<Candidato>
                                        , ICandidatoDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public CandidatoDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.CandidatoRepository)
        {
            this.unitOfWork = unitOfWork;
        }

        public override void Update(Candidato entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("Candidato inválido.");
            }

            var existeCandidato = base.GetById(entity.Id);

            if(existeCandidato == null)
            {
                throw new Exception("Candidato não existe com este Id.");
            }

            base.Update(entity);
        }
    }
}
