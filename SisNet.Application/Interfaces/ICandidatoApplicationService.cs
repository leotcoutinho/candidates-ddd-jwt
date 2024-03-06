using SisNet.Application.DTO;

namespace SisNet.Application.Interfaces
{
    public interface ICandidatoApplicationService : IDisposable
    {
        void Add(CandidatoPostDTO dto);
        void Update(CandidatoDTO dto);
        void Remove(Guid id);
        List<CandidatoDTO> GetAll();
        CandidatoDTO GetById(Guid id);
    }
}
