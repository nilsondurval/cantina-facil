using Microsoft.IdentityModel.Tokens;
using CantinaFacil.Domain.Authentication;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using Microsoft.Extensions.Configuration;

namespace CantinaFacil.Infrastructure.Authentication
{
    public class JwtService : IJwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration configuration)
        {
            _config = configuration;
        }

        public string CreateJwtToken(Dictionary<string, object> claimsDictionary, string privateKey, string expirationMinutes)
        {
            var rsa = RSA.Create();
            rsa.ImportRSAPrivateKey(Convert.FromBase64String(privateKey), out _);

            var tokenHandler = new JwtSecurityTokenHandler();
            var claims = new ClaimsIdentity(CreateClaims(claimsDictionary));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddMinutes(Convert.ToInt32(_config["Jwt:TokenExpirationInMinutes"])),
                Issuer = _config["Jwt:Issuer"],
                Audience = _config["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(new RsaSecurityKey(rsa), SecurityAlgorithms.RsaSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            
            return tokenHandler.WriteToken(token);
        }

        private List<Claim> CreateClaims(Dictionary<string, object> claims)
        {
            var userClaims = new List<Claim>();
            
            foreach (var claim in claims)
            {
                if (claim.Value is IEnumerable<string>)
                {
                    foreach (var value in (IEnumerable<string>)claim.Value)
                        userClaims.Add(new Claim(claim.Key, value.ToString()));
                }
                else
                {
                    var value = claim.Value.ToString();
                        userClaims.Add(new Claim(claim.Key, value));
                }
            }

            return userClaims;
        }
    }
}
