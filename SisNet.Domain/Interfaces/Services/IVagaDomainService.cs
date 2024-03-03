using SisNet.Domain.Models;

namespace SisNet.Domain.Interfaces.Services
{
    public interface IVagaDomainService : IBaseDomainService<Vaga>
    {
        Vaga GetByCodigo(int codigo);
    }
}
