using AutoMapper;
using SisNet.Application.ViewModels;
using SisNet.Domain.Models;

namespace SisNet.Application.MapperProfiles
{
    public class ViewModelToModelProfile : Profile
    {
        public ViewModelToModelProfile()
        {
            #region Candidato

            CreateMap<CandidatoAddViewModel, Candidato>()
               .AfterMap((src,dest)  => { 
                                           dest.Id = Guid.NewGuid(); 
                                           dest.DataCadastro = DateTime.Now; 
                                        });
           
            CreateMap<CandidatoUpdateViewModel, Candidato>()
                .AfterMap((src, dest) => {
                                            dest.Id = Guid.Parse(src.Id);
                                         });

            CreateMap<CandidatoDeleteViewModel, Candidato>()
               .AfterMap((src, dest) => {
                                            dest.Id = Guid.Parse(src.Id);
                                        });
            #endregion

            #region Vaga

            CreateMap<VagaAddViewModel, Vaga>()
                .AfterMap((src, dest) => {
                    dest.Id = Guid.NewGuid();
                    dest.DataCadastro = DateTime.Now;
                });

            CreateMap<VagaUpdateViewModel, Vaga>()
                 .AfterMap((src, dest) => {
                     dest.Id = Guid.Parse(src.Id);
                     dest.DataCadastro = DateTime.Parse(src.DataCadastro);
                 });

            CreateMap<VagaDeleteViewModel, Vaga>()
                 .AfterMap((src, dest) => {
                     dest.Id = Guid.Parse(src.Id);
                 });

            #endregion
        }
    }
}
