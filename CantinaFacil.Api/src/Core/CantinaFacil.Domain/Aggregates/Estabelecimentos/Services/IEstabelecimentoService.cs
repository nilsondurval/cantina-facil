namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Services
{
    public interface IEstabelecimentoService : IDisposable
    {
        Task AdicionarAsync(Estabelecimento estabelecimento);
        Task AtualizarAsync(int estabelecimentoId, Estabelecimento estabelecimento);
        Task RemoverAsync(int estabelecimentoId);
        Task AdicionarProdutoAsync(int estabelecimentoId, Produto produto);
        Task AtualizarProdutoAsync(int estabelecimentoId, int produtoId, Produto produto);
        Task RemoverProdutoAsync(int produtoId);
    }
}
