using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Interfaces.Services;
using SisNet.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SisNet.Domain.Services
{
    public class CandidatoVagaDomainService : BaseDomainService<CandidatoVaga>
                                            , ICandidatoVagaDomainService
    {
        private readonly IUnitOfWork unitOfWork;

        public CandidatoVagaDomainService(IUnitOfWork unitOfWork) : base(unitOfWork.CandidatoVagaRepository)
        {
            this.unitOfWork = unitOfWork;
        }
    }
}
