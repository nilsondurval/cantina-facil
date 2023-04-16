using Microsoft.Extensions.Configuration;

namespace CantinaFacil.Shared.Kernel.API.Helpers
{
    public static class ConfigurationHelper
    {
        public static string GetApiPath(this IConfiguration configuration, string key)
        {
            if (configuration[key].StartsWith("http"))
                return configuration[key];

            return string.Concat(configuration["BaseApisUrl"], configuration[key]);
        }
    }
}
