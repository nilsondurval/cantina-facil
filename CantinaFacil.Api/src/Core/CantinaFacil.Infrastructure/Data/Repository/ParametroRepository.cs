using Microsoft.EntityFrameworkCore;
using CantinaFacil.Domain.Aggregates.Parametros;
using CantinaFacil.Domain.Aggregates.Parametros.Enumeration;
using CantinaFacil.Domain.Aggregates.Parametros.Repository;
using CantinaFacil.Infrastructure.Data.Context;

namespace CantinaFacil.Infrastructure.Data.Repository
{
    public class ParametroRepository : Repository<Parametro>, IParametroRepository
    {
        public ParametroRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<Parametro> ObterParametroPorChaveAsync(string nome)
        {
            return await _context.Parametros.AsNoTracking()
                .FirstAsync(x => x.Nome.Equals(nome));
        }
    }
}
