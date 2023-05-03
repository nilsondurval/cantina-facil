using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CantinaFacil.Shared.Kernel.Api.Controllers;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Application.ViewModels.Login;
using CantinaFacil.Application.Services.Interfaces;

namespace BEC.Autorizacao.API.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : MainController
    {
        private readonly ILoginAppService _loginAppService;

        public LoginController
        (
            INotificationHandler<DomainNotificationEvent> notifications,
            IMediatorHandler mediator,
            ILoginAppService loginAppService
        ) : base(notifications, mediator)
        {
            _loginAppService = loginAppService;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AutenticarAsync(LoginViewModel login)
        {
            return Response(await _loginAppService.AutenticarAsync(login));
        }
    }
}
