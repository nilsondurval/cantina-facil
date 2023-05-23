using Microsoft.EntityFrameworkCore;
using CantinaFacil.Infrastructure.Data.Context;
using CantinaFacil.Domain.Aggregates.Estabelecimentos;
using CantinaFacil.Domain.Aggregates.Estabelecimentos.Repository;

namespace CantinaFacil.Infrastructure.Data.Repository
{
    public class EstabelecimentoRepository : Repository<Estabelecimento>, IEstabelecimentoRepository
    {
        public EstabelecimentoRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<IEnumerable<Estabelecimento>> ObterAsync(int usuarioId)
        {
            return await _context.Estabelecimentos
                .Include(e => e.Produtos)
                .AsNoTracking()
                .Where(e => e.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
