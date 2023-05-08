using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Shared.Kernel.API.Configurations;

namespace CantinaFacil.Api.Configurations
{
    public static class JwtAuthenticationConfiguration
    {
        public static void AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            using var scope = services.BuildServiceProvider().CreateScope();
            var parametro = scope.ServiceProvider.GetService<IParametroAppService>();
            var publicKey = parametro?.ObterChavePublicaJwtAsync().Result;

            if (!string.IsNullOrWhiteSpace(publicKey))
                services.AddBaseJwtAuthentication(configuration, publicKey);
        }
    }
}
