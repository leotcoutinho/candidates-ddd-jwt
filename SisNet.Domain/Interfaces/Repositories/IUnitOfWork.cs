namespace SisNet.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        #region Transactions

        void BeginTransaction();
        void Commit();
        void RollBack();

        #endregion

        #region Repositories

        IVagaRepository VagaRepository { get; }
        ICandidatoRepository CandidatoRepository { get; }
        ICandidatoVagaRepository CandidatoVagaRepository { get; }

        #endregion
    }
}
