using SisNet.Database.Context;
using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Models;

namespace SisNet.Database.Repositories
{
    public class CandidatoRepository : BaseRepository<Candidato>
                                     , ICandidatoRepository
    {
        // injeção de dependêndia
        public CandidatoRepository(SqlContext context) : base(context)
        {

            
        }
    }
}