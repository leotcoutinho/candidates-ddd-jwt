using SisNet.Database.Context;
using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Models;

namespace SisNet.Database.Repositories
{
    public class VagaRepository :  BaseRepository<Vaga>
                                , IVagaRepository
    {
        public VagaRepository(SqlContext context) : base(context)
        {
        }

        public Vaga GetByCodigo(int codigo)
        {
            return dbSet.FirstOrDefault(x=>x.Codigo.Equals(codigo));
        }
    }
}
