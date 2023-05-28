using CantinaFacil.Application.ViewModels.Estabelecimentos;

namespace CantinaFacil.Application.Services.Interfaces
{
    public interface IEstabelecimentoAppService : IDisposable
    {
        Task AdicionarAsync(int usuarioId, AdicionarEstabelecimentoViewModel estabelecimento);
        Task<ObterEstabelecimentoViewModel> ObterAsync(int estabelecimentoId);
        Task<IEnumerable<ObterEstabelecimentoViewModel>> ObterPorUsuarioAsync(int usuarioId);
        Task AtualizarAsync(int usuarioId, int estabelecimentoId, AtualizarEstabelecimentoViewModel estabelecimento);
        Task RemoverAsync(int estabelecimentoId);
        Task AdicionarProdutoAsync(int estabelecimentoId, AdicionarProdutoViewModel produto);
        Task AtualizarProdutoAsync(int estabelecimentoId, int produtoId, AtualizarProdutoViewModel produto);
        Task RemoverProdutoAsync(int produtoId);
    }
}
