using Microsoft.EntityFrameworkCore;
using CantinaFacil.Domain.Aggregates.Usuarios.Repository;
using CantinaFacil.Domain.Aggregates.Usuarios;
using CantinaFacil.Infrastructure.Data.Context;

namespace CantinaFacil.Infrastructure.Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Usuario?> ObterAsync(string cpf)
        {
            return await _context.Usuarios
                .Include(u => u.Perfil)
                .AsNoTracking()
                .FirstAsync(u => u.Cpf == cpf);
        }

        public async Task<Usuario?> ObterAsync(string email, string senha)
        {
            return await _context.Usuarios
                .Include(u => u.Perfil)
                .AsNoTracking()
                .Where(u => u.Email == email)
                .Where(u => u.Senha == senha)
                .FirstOrDefaultAsync();
        }
    }
}
