using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Interfaces.Services;

namespace SisNet.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity> 
                where TEntity : class
    {
        // DIP - (Princípio de Inversão de Dependência)
        private readonly IBaseRepository<TEntity> repository;

        // Injeção de dependência
        protected BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }

        public virtual void Add(TEntity entity)
        {
           repository.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
           repository.Update(entity);
        }

        public virtual void Remove(TEntity entity)
        {
            repository.Remove(entity);  
        }

        public virtual List<TEntity> GetAll()
        {
            return repository.GetAll().ToList();
        }

        public virtual TEntity GetById(Guid id)
        {
           return repository.GetById(id);
        }

        public void Dispose()
        {
            repository.Dispose();
        }
    }
}
