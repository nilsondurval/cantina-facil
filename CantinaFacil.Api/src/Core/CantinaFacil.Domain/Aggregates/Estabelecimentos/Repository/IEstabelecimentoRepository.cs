using CantinaFacil.Domain.Aggregates.Estabelecimentos;
using CantinaFacil.Shared.Kernel.Data;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Repository
{
    public interface IEstabelecimentoRepository : IRepository<Estabelecimento>
    {
        Task<IEnumerable<Estabelecimento>> ObterAsync(int usuarioId);
        Task AdicionarProdutoAsync(Produto produto);
        Task AtualizarProdutoAsync(Produto produto);
        Task RemoverProdutoAsync(int produtoId);
    }
}
