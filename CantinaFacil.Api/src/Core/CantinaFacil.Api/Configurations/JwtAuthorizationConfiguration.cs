using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace CantinaFacil.Api.Configurations
{
    public static class JwtAuthorizationConfiguration
    {
        public static void AddJwtAuthorization(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                
            });
        }
    }
}
