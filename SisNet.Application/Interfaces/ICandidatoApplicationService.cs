using SisNet.Application.DTO;

namespace SisNet.Application.Interfaces
{
    public interface ICandidatoApplicationService : IDisposable
    {
        void Add(CandidatoPostDTO dto);
        void Update(CandidatoGetDTO dto);
        void Remove(Guid id);
        List<CandidatoGetDTO> GetAll();
        CandidatoGetDTO GetById(Guid id);
    }
}
