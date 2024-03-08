using SisNet.Application.DTO;
using SisNet.Application.ViewModels;

namespace SisNet.Application.Interfaces
{
    public interface ICandidatoApplicationService : IDisposable
    {
        Task Add(CandidatoAddViewModel dto);
        Task Update(CandidatoUpdateViewModel dto);
        Task Remove(Guid id);
        Task<List<CandidatoDTO>> GetAll();
        Task<CandidatoDTO> GetById(Guid id);
    }
}
