using SisNet.Application.DTO;
using SisNet.Domain.Models;

namespace SisNet.Application.Interfaces
{
    public interface IVagaApplicationService : IDisposable
    {
        void Add(VagaPostDTO entity);
        void Update(VagaGetDTO entity);
        void Remove(Guid id);
        List<VagaGetDTO> GetAll();
        VagaGetDTO GetById(Guid id);
        VagaGetDTO GetByCodigo(int codigo);
    }
}
