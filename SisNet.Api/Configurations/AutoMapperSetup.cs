using SisNet.Application.MapperProfiles;

namespace SisNet.Api.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(ModelToDTOProfile),typeof(ViewModelToModelProfile));
        }
    }
}
