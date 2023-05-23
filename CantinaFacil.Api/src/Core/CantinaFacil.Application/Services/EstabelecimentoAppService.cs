using AutoMapper;
using MediatR;
using CantinaFacil.Shared.Kernel.Application;
using CantinaFacil.Shared.Kernel.Data;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Application.Services.Interfaces;
using CantinaFacil.Domain.Messages;
using CantinaFacil.Domain.Aggregates.Estabelecimentos.Services;
using CantinaFacil.Domain.Aggregates.Estabelecimentos.Repository;
using CantinaFacil.Application.ViewModels.Estabelecimentos;
using CantinaFacil.Domain.Aggregates.Estabelecimentos;

namespace CantinaFacil.Application.Services
{
    public class EstabelecimentoAppService : ApplicationService, IEstabelecimentoAppService
    {
        private readonly IEstabelecimentoService _estabelecimentoService;
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;
        private readonly IMapper _mapper;

        public EstabelecimentoAppService
        (
            IUnitOfWork unitOfWork,
            IMediatorHandler mediator,
            INotificationHandler<DomainNotificationEvent> notifications,
            IEstabelecimentoService estabelecimentoService,
            IEstabelecimentoRepository estabelecimentoRepository,
            IMapper mapper) : base(unitOfWork, mediator, notifications)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
            _estabelecimentoService = estabelecimentoService;
            _mapper = mapper;
        }

        public async Task AdicionarAsync(AdicionarEstabelecimentoViewModel estabelecimento)
        {
            await _estabelecimentoService.AdicionarAsync(_mapper.Map<Estabelecimento>(estabelecimento));
            await CommitAsync();
        }

        public async Task<IEnumerable<ObterEstabelecimentoViewModel>> ObterAsync(int usuarioId)
        {
            var estabelecimentos = await _estabelecimentoRepository.ObterAsync(usuarioId);

            if (!estabelecimentos.Any())
            {
                RaiseError(MessageResource.RegistroNaoEncontrado);
                return new List<ObterEstabelecimentoViewModel>();
            }

            return _mapper.Map<IEnumerable<ObterEstabelecimentoViewModel>>(estabelecimentos);
        }

        public async Task AtualizarAsync(int estabelecimentoId, AtualizarEstabelecimentoViewModel estabelecimento)
        {
            await _estabelecimentoService.AtualizarAsync(estabelecimentoId, _mapper.Map<Estabelecimento>(estabelecimento));
            await CommitAsync();
        }

        public async Task RemoverAsync(int estabelecimentoId)
        {
            await _estabelecimentoService.RemoverAsync(estabelecimentoId);
            await CommitAsync();
        }

        public async Task AdicionarProdutoAsync(int estabelecimentoId, AdicionarProdutoViewModel produto)
        {
            await _estabelecimentoService.AdicionarProdutoAsync(estabelecimentoId, _mapper.Map<Produto>(produto));
            await CommitAsync();
        }

        public async Task AtualizarProdutoAsync(int estabelecimentoId, int produtoId, AtualizarProdutoViewModel produto)
        {
            await _estabelecimentoService.AtualizarProdutoAsync(estabelecimentoId, produtoId, _mapper.Map<Produto>(produto));
            await CommitAsync();
        }

        public async Task RemoverProdutoAsync(int produtoId)
        {
            await _estabelecimentoService.RemoverProdutoAsync(produtoId);
            await CommitAsync();
        }

        public void Dispose()
        {
            _estabelecimentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
