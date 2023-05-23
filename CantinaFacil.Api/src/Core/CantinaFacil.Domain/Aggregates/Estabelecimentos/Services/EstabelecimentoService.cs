using CantinaFacil.Shared.Kernel.Domain;
using CantinaFacil.Shared.Kernel.Domain.Services;
using CantinaFacil.Shared.Kernel.Mediator;
using CantinaFacil.Domain.Messages;
using CantinaFacil.Domain.Aggregates.Estabelecimentos.Repository;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Services
{
    public class EstabelecimentoService : Service, IEstabelecimentoService
    {
        private readonly IEstabelecimentoRepository _estabelecimentoRepository;

        public EstabelecimentoService(
            IMediatorHandler mediator, 
            IEstabelecimentoRepository estabelecimentoRepository) : base(mediator)
        {
            _estabelecimentoRepository = estabelecimentoRepository;
        }

        public async Task AdicionarAsync(Estabelecimento estabelecimento)
        {
            await _estabelecimentoRepository.AddAsync(estabelecimento);
        }

        public async Task AtualizarAsync(int estabelecimentoId, Estabelecimento estabelecimento)
        {
            if (estabelecimento is null)
            {
                RaiseError(MessageResource.RegistroNaoEncontrado);
                return;
            }

            estabelecimento.AtribuirId(estabelecimentoId);
            await Task.Run(() => _estabelecimentoRepository.Update(estabelecimento));
        }

        public async Task RemoverAsync(int estabelecimentoId)
        {
            var estabelecimento = await _estabelecimentoRepository.GetByIdAsync(estabelecimentoId);

            if (estabelecimento is null)
            {
                RaiseError(MessageResource.RegistroNaoEncontrado);
                return;
            }

            await _estabelecimentoRepository.RemoveAsync(estabelecimentoId);
        }

        public void Dispose()
        {
            _estabelecimentoRepository.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
