using CantinaFacil.Shared.Kernel.Domain;
using CantinaFacil.Shared.Kernel.Domain.Services;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Domain.Aggregates.Usuarios.Repository;
using CantinaFacil.Domain.Messages;
using CantinaFacil.Domain.Auth.Services;

namespace CantinaFacil.Domain.Aggregates.Usuarios.Services
{
    public class UsuarioService : Service, IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IJwtService _jwtService;

        public UsuarioService(
            IMediatorHandler mediator, 
            IUsuarioRepository usuarioRepository, 
            IJwtService jwtService) : base(mediator)
        {
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        public string GerarToken(Usuario usuario, string privateKey, string expirationMinutes)
        {
            if (usuario is null)
            {
                RaiseError(MessageResource.UsuarioInvalido);
                return string.Empty;
            }

            var claims = new Dictionary<string, object>
            {
                { UserClaimTypes.Nome, usuario.Nome },
                { UserClaimTypes.Documento, usuario.Cpf },
                { UserClaimTypes.Perfil, usuario.Perfil.Nome }
            };

            return _jwtService.CreateJwtToken(claims, privateKey, expirationMinutes);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
