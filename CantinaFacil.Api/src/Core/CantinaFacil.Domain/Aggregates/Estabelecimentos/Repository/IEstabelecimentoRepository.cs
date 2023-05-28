using CantinaFacil.Domain.Aggregates.Estabelecimentos;
using CantinaFacil.Shared.Kernel.Data;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Repository
{
    public interface IEstabelecimentoRepository : IRepository<Estabelecimento>
    {
        Task<Estabelecimento?> ObterAsync(int estabelecimentoId);
        Task<IEnumerable<Estabelecimento>> ObterPorUsuarioAsync(int usuarioId);
        Task AdicionarProdutoAsync(Produto produto);
        Task AtualizarProdutoAsync(Produto produto);
        Task RemoverProdutoAsync(int produtoId);
    }
}
