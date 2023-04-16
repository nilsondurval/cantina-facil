using CantinaFacil.Application.AutoMapper;
using CantinaFacil.Infrastructure.IoC;

namespace CantinaFacil.Api.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            BootStrapper.RegisterServices(services);

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile));
            services.AddAutoMapper(typeof(ViewModelToDomainMappingProfile));
        }
    }
}
