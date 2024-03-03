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
    }
}
