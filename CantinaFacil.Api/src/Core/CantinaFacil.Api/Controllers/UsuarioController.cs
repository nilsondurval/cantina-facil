using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CantinaFacil.Shared.Kernel.Api.Controllers;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Application.ViewModels.Usuario;

namespace BEC.Autorizacao.API.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController : MainController
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public UsuarioController
        (
            INotificationHandler<DomainNotificationEvent> notifications,
            IMediatorHandler mediator,
            IUsuarioAppService usuarioAppService
        ) : base(notifications, mediator)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAsync([FromBody] AdicionarUsuarioViewModel usuario)
        {
            await _usuarioAppService.AdicionarAsync(usuario);
            return Response();
        }

        [HttpGet("{usuarioId}")]
        [Authorize]
        public async Task<IActionResult> ObterAsync([FromRoute] int usuarioId)
        {
            return Response(await _usuarioAppService.ObterAsync(usuarioId));
        }

        [HttpPut("{usuarioId}")]
        [Authorize]
        public async Task<IActionResult> AtualizarAsync([FromRoute] int usuarioId, [FromBody] AtualizarUsuarioViewModel usuario)
        {
            await _usuarioAppService.AtualizarAsync(usuarioId, usuario);
            return Response();
        }

        [HttpDelete("{usuarioId}")]
        [Authorize]
        public async Task<IActionResult> RemoverAsync([FromRoute] int usuarioId)
        {
            await _usuarioAppService.RemoverAsync(usuarioId);
            return Response();
        }
    }
}
