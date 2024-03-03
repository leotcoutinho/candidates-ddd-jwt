using Microsoft.EntityFrameworkCore;
using SisNet.Database.Context;
using SisNet.Domain.Interfaces.Repositories;

namespace SisNet.Database.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        // DIP -> Principio de Inversão de Dependência
        protected readonly SqlContext context;
        // CRUD
        protected readonly DbSet<TEntity> dbSet;

        // Injeção de dependência
        protected BaseRepository(SqlContext context)
        {
            this.context = context;
            dbSet = context.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            dbSet.Add(entity);
            context.SaveChanges();
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Update(entity);
            context.SaveChanges();
        }

        public virtual void Remove(TEntity entity)
        {
            dbSet.Remove(entity);
            context.SaveChanges();
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return dbSet;
        }

        public virtual TEntity GetById(Guid id)
        {
            return dbSet.Find(id);  
        }

        public void Dispose()
        {
            context.Dispose();  
        }
    }
}
