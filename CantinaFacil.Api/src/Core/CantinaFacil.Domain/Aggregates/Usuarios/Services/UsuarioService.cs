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

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _usuarioRepository.AddAsync(usuario);
        }

        public async Task AtualizarAsync(int usuarioId, Usuario usuario)
        {
            if (usuario is null)
            {
                RaiseError(MessageResource.RegistroNaoEncontrado);
                return;
            }

            usuario.AtribuirId(usuarioId);
            await Task.Run(() => _usuarioRepository.Update(usuario));
        }

        public async Task RemoverAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);

            if (usuario is null)
            {
                RaiseError(MessageResource.RegistroNaoEncontrado);
                return;
            }

            await _usuarioRepository.RemoveAsync(usuarioId);
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
                { UserClaimTypes.Id, usuario.Id },
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
