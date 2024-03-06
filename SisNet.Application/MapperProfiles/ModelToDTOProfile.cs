using AutoMapper;
using SisNet.Application.DTO;
using SisNet.Domain.Models;

namespace SisNet.Application.MapperProfiles
{
    public class ModelToDTOProfile : Profile
    {
        public ModelToDTOProfile()
        {
            CreateMap<Vaga, VagaDTO>();
            CreateMap<Candidato, CandidatoDTO>();
        }
        
    }
}
