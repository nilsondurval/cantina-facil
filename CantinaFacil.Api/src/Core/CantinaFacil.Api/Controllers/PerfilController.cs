using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CantinaFacil.Shared.Kernel.Api.Controllers;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Application.Services.Interfaces;

namespace BEC.Autorizacao.API.Controllers
{
    [Route("api/perfis")]
    [ApiController]
    public class PerfilController : MainController
    {
        private readonly IPerfilAppService _perfilAppService;

        public PerfilController
        (
            INotificationHandler<DomainNotificationEvent> notifications,
            IMediatorHandler mediator,
            IPerfilAppService usuarioAppService
        ) : base(notifications, mediator)
        {
            _perfilAppService = usuarioAppService;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> ObterTodosAsync()
        {
            return Response(await _perfilAppService.ObterTodosAsync());
        }
    }
}
