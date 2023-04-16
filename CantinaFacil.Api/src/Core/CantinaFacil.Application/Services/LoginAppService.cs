using AutoMapper;
using CantinaFacil.Domain.Aggregates.Usuarios.Repository;
using CantinaFacil.Domain.Aggregates.Usuarios.Services;
using MediatR;
using CantinaFacil.Shared.Kernel.Application;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Application.ViewModels.Login;
using CantinaFacil.Domain.Messages;
using CantinaFacil.Application.Services.Interfaces;

namespace CantinaFacil.Application.Services
{
    public class LoginAppService : ApplicationService, ILoginAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IParametroAppService _parametroAppService;
        private readonly IMapper _mapper;

        public LoginAppService
        (
            IUnitOfWork unitOfWork,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotificationEvent> notifications,
            IUsuarioService usuarioService,
            IUsuarioRepository usuarioRepository,
            IParametroAppService parametroAppService,
            IMapper mapper
        ) : base(unitOfWork, mediator, notifications)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _parametroAppService = parametroAppService;
            _mapper = mapper;
        }

        public async Task<string> AutenticarAsync(LoginViewModel login)
        {
            if (string.IsNullOrWhiteSpace(login.Email) || string.IsNullOrWhiteSpace(login.Senha))
            {
                RaiseError(MessageResource.UsuarioEOuSenhaInvalido);
                return string.Empty;
            }

            var usuario = await _usuarioRepository.ObterAsync(login.Email, login.Senha);

            if (usuario == null)
            {
                RaiseError(MessageResource.UsuarioEOuSenhaInvalido);
                return string.Empty;
            }

            var privateKey = await _parametroAppService.ObterChavePrivadaJwtAsync();
            var expirationMinutes = await _parametroAppService.ObterTempoExpiracaoJwtAsync();

            return _usuarioService.GerarToken(usuario, privateKey, expirationMinutes);
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
