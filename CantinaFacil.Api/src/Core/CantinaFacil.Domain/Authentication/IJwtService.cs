using System.Collections.Generic;

namespace CantinaFacil.Domain.Authentication
{
    public interface IJwtService
    {
        public string CreateJwtToken(Dictionary<string, object> claims, string privateKey, string expirationMinutes);
    }
}
