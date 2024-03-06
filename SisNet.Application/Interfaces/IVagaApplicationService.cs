using SisNet.Application.DTO;
using SisNet.Domain.Models;

namespace SisNet.Application.Interfaces
{
    public interface IVagaApplicationService : IDisposable
    {
        void Add(VagaPostDTO entity);
        void Update(VagaDTO entity);
        void Remove(Guid id);
        List<VagaDTO> GetAll();
        VagaDTO GetById(Guid id);
        VagaDTO GetByCodigo(int codigo);
    }
}
