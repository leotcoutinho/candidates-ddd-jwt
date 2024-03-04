using SisNet.Application.DTO;
using SisNet.Domain.Models;

namespace SisNet.Application.Interfaces
{
    public interface ICandidatoApplicationService : IDisposable
    {
        void Add(CandidatoDTO dto);
        void Update(CandidatoDTO dto);
        void Remove(Guid id);
        List<Candidato> GetAll();
        Candidato GetById(Guid id);
    }
}
