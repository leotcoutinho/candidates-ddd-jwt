using SisNet.Application.DTO;
using SisNet.Application.ViewModels;

namespace SisNet.Application.Interfaces
{
    public interface IVagaApplicationService : IDisposable
    {
        Task Add(VagaAddViewModel entity);
        Task Update(VagaUpdateViewModel entity);
        Task Remove(Guid id);
        Task<List<VagaDTO>> GetAll();
        Task<VagaDTO> GetById(Guid id);
        Task<VagaDTO> GetByCodigo(int codigo);
    }
}
