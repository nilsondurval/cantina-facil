using CantinaFacil.Domain.Aggregates.Estabelecimentos;
using CantinaFacil.Shared.Kernel.Data;

namespace CantinaFacil.Domain.Aggregates.Estabelecimentos.Repository
{
    public interface IEstabelecimentoRepository : IRepository<Estabelecimento>
    {
        Task<IEnumerable<Estabelecimento>> ObterAsync(int usuarioId);
    }
}
