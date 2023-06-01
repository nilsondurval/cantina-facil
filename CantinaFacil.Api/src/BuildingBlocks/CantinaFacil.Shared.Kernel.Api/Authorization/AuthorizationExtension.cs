using CantinaFacil.Shared.Kernel.Domain;
using System.Security.Claims;

namespace CantinaFacil.Shared.Kernel.API.Authorization
{
    public static class AuthorizationExtension
    {
        public static string? ObterId(this ClaimsPrincipal principal)
        {
            return principal
                .ObterClaim(UserClaimTypes.Id)
                ?.ObterValor();
        }

        public static string? ObterDocumento(this ClaimsPrincipal principal)
        {  
            return principal
                .ObterClaim(UserClaimTypes.Documento)
                ?.ObterValor();
        }

        public static string? ObterNome(this ClaimsPrincipal principal)
        {
            return principal
                .ObterClaim(UserClaimTypes.Nome)
                ?.ObterValor();
        }

        public static string? ObterPerfil(this ClaimsPrincipal principal)
        {
            return !(principal == null) ? principal.ObterClaim(UserClaimTypes.Perfil)
                            ?.ObterValor() : "Publico";
        }

        private static Claim? ObterClaim(this ClaimsPrincipal principal, string type)
        {
            if (principal == null)
                return null;

            return principal.Claims.First(x => x.Type.Equals(type));
        }

        private static string ObterValor(this Claim claim)
        {
            if (claim == null)
                return string.Empty;

            return claim.Value;
        }
    }
}
