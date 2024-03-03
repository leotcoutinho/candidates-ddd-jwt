namespace SisNet.Domain.Interfaces.Repositories
{
    public interface IBaseRepository<TEntity> : IDisposable
        where TEntity : class
    {
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Remove(TEntity entity);
        IQueryable<TEntity> GetAll();
        TEntity GetById(Guid id);
    }
}
