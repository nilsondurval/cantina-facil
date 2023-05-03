using CantinaFacil.Shared.Kernel.GuardCauses;
using CantinaFacil.Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace CantinaFacil.Api.Configurations
{
    public static class DataBaseConfiguration
    {
        public static void AddDataBaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DataContext>(options =>
            options.UseMySql(Environment.GetEnvironmentVariable("DefaultConnection"), ServerVersion.AutoDetect(Environment.GetEnvironmentVariable("DefaultConnection"))));
            //options.UseMySql(configuration.GetConnectionString("DefaultConnection"), ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection"))));
        }
    }
}
