using Microsoft.Extensions.DependencyInjection;
using SisNet.Application.Interfaces;
using SisNet.Application.Services;
using SisNet.Database.Repositories;
using SisNet.Domain.Interfaces.Repositories;
using SisNet.Domain.Interfaces.Services;
using SisNet.Domain.Services;

namespace SisNet.IoC
{
    public class DependencyInjection
    {
        public static void Register(IServiceCollection service)
        {
            #region Application

            service.AddTransient<IVagaApplicationService, VagaApplicationService>();
            service.AddTransient<ICandidatoApplicationService, CandidatoApplicationService>();

            #endregion

            #region Domain

            service.AddTransient<IVagaDomainService, VagaDomainService>();
            service.AddTransient<ICandidatoDomainService, CandidatoDomainService>();
            service.AddTransient<ICandidatoVagaDomainService, CandidatoVagaDomainService>();

            #endregion

            #region Infra

            service.AddTransient<IVagaRepository, VagaRepository>();
            service.AddTransient<ICandidatoRepository, CandidatoRepository>();
            service.AddTransient<ICandidatoVagaRepository, CandidatoVagaRepository>();
            service.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion
        }
    }
}
