using SisNet.Domain.Models;

namespace SisNet.Domain.Interfaces.Repositories
{
    //SOLID- ISP(interface segregation principle)
    public interface IVagaRepository: IBaseRepository<Vaga>
    {
        Vaga GetByCodigo(int codigo);
    }
}
