using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CantinaFacil.Shared.Kernel.Api.Controllers;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Application.ViewModels.Estabelecimentos;

namespace BEC.Autorizacao.API.Controllers
{
    [Route("api/estabelecimentos")]
    [ApiController]
    public class EstabelecimentoController : MainController
    {
        private readonly IEstabelecimentoAppService _estabelecimentoAppService;

        public EstabelecimentoController
        (
            INotificationHandler<DomainNotificationEvent> notifications,
            IMediatorHandler mediator,
            IEstabelecimentoAppService estabelecimentoAppService
        ) : base(notifications, mediator)
        {
            _estabelecimentoAppService = estabelecimentoAppService;
        }

        [HttpPost]
        public async Task<IActionResult> AdicionarAsync([FromBody] AdicionarEstabelecimentoViewModel estabelecimento)
        {
            await _estabelecimentoAppService.AdicionarAsync(estabelecimento);
            return Response();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> ObterAsync([FromQuery] int usuarioId)
        {
            return Response(await _estabelecimentoAppService.ObterAsync(usuarioId));
        }

        [HttpPut("{estabelecimentoId}")]
        [Authorize]
        public async Task<IActionResult> AtualizarAsync([FromRoute] int estabelecimentoId, [FromBody] AtualizarEstabelecimentoViewModel estabelecimento)
        {
            await _estabelecimentoAppService.AtualizarAsync(estabelecimentoId, estabelecimento);
            return Response();
        }

        [HttpDelete("{estabelecimentoId}")]
        [Authorize]
        public async Task<IActionResult> RemoverAsync([FromRoute] int estabelecimentoId)
        {
            await _estabelecimentoAppService.RemoverAsync(estabelecimentoId);
            return Response();
        }


        [HttpPost("{estabelecimentoId}/produtos")]
        public async Task<IActionResult> AdicionarProdutoAsync([FromRoute] int estabelecimentoId, [FromBody] AdicionarProdutoViewModel produto)
        {
            await _estabelecimentoAppService.AdicionarProdutoAsync(estabelecimentoId, produto);
            return Response();
        }

        [HttpPut("{estabelecimentoId}/produtos/{produtoId}")]
        public async Task<IActionResult> AtualizarProdutoAsync([FromRoute] int estabelecimentoId, [FromRoute] int produtoId, [FromBody] AtualizarProdutoViewModel produto)
        {
            await _estabelecimentoAppService.AtualizarProdutoAsync(estabelecimentoId, produtoId, produto);
            return Response();
        }

        [HttpDelete("{estabelecimentoId}/produtos/{produtoId}")]
        [Authorize]
        public async Task<IActionResult> RemoverAsync([FromRoute] int estabelecimentoId, [FromRoute] int produtoId)
        {
            await _estabelecimentoAppService.RemoverProdutoAsync(produtoId);
            return Response();
        }
    }
}
