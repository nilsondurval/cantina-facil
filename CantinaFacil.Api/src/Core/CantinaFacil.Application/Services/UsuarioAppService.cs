using AutoMapper;
using CantinaFacil.Domain.Aggregates.Usuarios.Repository;
using CantinaFacil.Domain.Aggregates.Usuarios.Services;
using MediatR;
using CantinaFacil.Shared.Kernel.Application;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Application.ViewModels.Usuario;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Domain.Messages;

namespace CantinaFacil.Application.Services
{
    public class UsuarioAppService : ApplicationService, IUsuarioAppService
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioAppService
        (
            IUnitOfWork unitOfWork,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotificationEvent> notifications,
            IUsuarioService usuarioService,
            IUsuarioRepository usuarioRepository,
            IMapper mapper
        ) : base(unitOfWork, mediator, notifications)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(AdicionarUsuarioViewModel usuario)
        {
            await _usuarioService.AdicionarAsync(_mapper.Map<Usuario>(usuario));
            await CommitAsync();
        }

        public async Task<ObterUsuarioViewModel?> ObterAsync(int usuarioId)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(usuarioId);

            if (usuario is null)
            {
                RaiseError(MessageResource.UsuarioNaoEncontrado);
                return null;
            }

            return _mapper.Map<ObterUsuarioViewModel>(usuario);
        }

        public async Task AtualizarAsync(int usuarioId, AtualizarUsuarioViewModel usuario)
        {
            await _usuarioService.AtualizarAsync(usuarioId, _mapper.Map<Usuario>(usuario));
            await CommitAsync();
        }

        public async Task RemoverAsync(int usuarioId)
        {
            await _usuarioService.RemoverAsync(usuarioId);
            await CommitAsync();
        }

        public void Dispose()
        {
            _usuarioRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
