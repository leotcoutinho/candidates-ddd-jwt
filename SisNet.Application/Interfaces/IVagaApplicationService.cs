using SisNet.Domain.Models;

namespace SisNet.Application.Interfaces
{
    public interface IVagaApplicationService : IDisposable
    {
        void Add(Vaga entity);
        void Update(Vaga entity);
        void Remove(Vaga entity);
        List<Vaga> GetAll();
        Vaga GetById(Guid id);
    }
}
