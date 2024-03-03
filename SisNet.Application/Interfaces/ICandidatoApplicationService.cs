using SisNet.Domain.Models;

namespace SisNet.Application.Interfaces
{
    public interface ICandidatoApplicationService : IDisposable
    {
        void Add(Candidato entity);
        void Update(Candidato entity);
        void Remove(Candidato entity);
        List<Candidato> GetAll();
        Candidato GetById(Guid id);
    }
}
