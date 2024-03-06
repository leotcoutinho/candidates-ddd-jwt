using AutoMapper;
using SisNet.Application.DTO;
using SisNet.Domain.Models;

namespace SisNet.Application.MapperProfiles
{
    public class DtoToModelProfile : Profile
    {
        public DtoToModelProfile()
        {
            #region Candidato

            CreateMap<CandidatoPostDTO, Candidato>()
                .ConstructUsing((src, dst) => new Candidato(Guid.NewGuid(), src.Nome, src.Email, src.Cpf, src.Link,src.DataNascimento, DateTime.Now));
            CreateMap<CandidatoDTO, Candidato>()
                .ConstructUsing((src, dst) => new Candidato(src.Id, src.Nome, src.Email, src.Cpf, src.Link, src.DataNascimento, src.DataCadastro));

            #endregion

            #region Vaga

            CreateMap<VagaPostDTO, Vaga>()
                .ConstructUsing((src, dst) => new Vaga(Guid.NewGuid(), src.Codigo, src.Titulo, src.Descricao, DateTime.Now, true));
            CreateMap<VagaDTO, Vaga>()
                .ConstructUsing((src, dst) => new Vaga(src.Id, src.Codigo, src.Titulo, src.Descricao, src.DataCadastro, src.Ativo));

            #endregion
        }
    }
}
