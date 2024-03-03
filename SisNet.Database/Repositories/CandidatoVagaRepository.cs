using SisNet.Database.Context;
using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Models;

namespace SisNet.Database.Repositories
{
    public class CandidatoVagaRepository :  BaseRepository<CandidatoVaga>
                                         , ICandidatoVagaRepository
    {
        public CandidatoVagaRepository(SqlContext context) : base(context)
        {
        }
    }
}
