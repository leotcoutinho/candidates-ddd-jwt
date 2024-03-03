namespace SisNet.Domain.Interfaces.Services
{
    public interface IBaseDomainService<TEntity> : IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        List<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
