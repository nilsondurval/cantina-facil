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

        public async Task<Estabelecimento?> ObterAsync(int estabelecimentoId)
        {
            return await _context.Estabelecimentos
                .Include(e => e.Produtos)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == estabelecimentoId);
        }

        public async Task<IEnumerable<Estabelecimento>> ObterPorUsuarioAsync(int usuarioId)
        {
            return await _context.Estabelecimentos
                .Include(e => e.Produtos)
                .Where(e => e.UsuarioId == usuarioId)
                .AsNoTracking()
                .ToListAsync();
        }

        public async Task RemoverAsync(int estabelecimentoId)
        {
            var produtos = await _context.Produtos
                .Where(p => p.EstabelecimentoId == estabelecimentoId)
                .AsNoTracking()
                .ToListAsync();

            if (produtos.Any())
                await Task.Run(() => _context.Produtos.RemoveRange(produtos));

            var estabelecimento = await _context.Estabelecimentos
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == estabelecimentoId);

            if (estabelecimento != null)
                await Task.Run(() => _context.Estabelecimentos.Remove(estabelecimento));
        }

        public async Task AdicionarProdutoAsync(Produto produto)
        {
            await _context.Produtos.AddAsync(produto);
        }

        public async Task AtualizarProdutoAsync(Produto produto)
        {
            await Task.Run(() => _context.Produtos.Update(produto));
        }

        public async Task RemoverProdutoAsync(int produtoId)
        {
            var produto = await _context.Produtos.FirstOrDefaultAsync(p => p.Id == produtoId);

            if (produto != null)
                await Task.Run(() => _context.Produtos.Remove(produto));
        }
    }
}
