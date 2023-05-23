namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Services
{
    public interface IEstabelecimentoService : IDisposable
    {
        Task AdicionarAsync(Estabelecimento estabelecimento);
        Task AtualizarAsync(int estabelecimentoId, Estabelecimento estabelecimento);
        Task RemoverAsync(int estabelecimentoId);
    }
}
