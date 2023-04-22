using System.Collections.Generic;

namespace CantinaFacil.Domain.Auth.Services
{
    public interface IJwtService
    {
        public string CreateJwtToken(Dictionary<string, object> claims, string privateKey, string expirationMinutes);
    }
}
