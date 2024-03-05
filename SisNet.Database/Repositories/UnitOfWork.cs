using Microsoft.EntityFrameworkCore.Storage;
using SisNet.Database.Context;
using SisNet.Domain.Interfaces.Repositories;

namespace SisNet.Database.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        // DIP->princípio de injeção de dependência 
        private readonly SqlContext context;
        // transactions
        private IDbContextTransaction transaction;

        public UnitOfWork(SqlContext context)
        {
            this.context = context;
        }

        public void Dispose()
        {
            context.Dispose();
        }

        #region Transactions

        public void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }

        public void Commit()
        {
            transaction.Commit();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        #endregion

        #region Repositories

        public IVagaRepository VagaRepository => new VagaRepository(context);

        public ICandidatoRepository CandidatoRepository => new CandidatoRepository(context);

        public ICandidatoVagaRepository CandidatoVagaRepository => new CandidatoVagaRepository(context);

        #endregion

    }
}
