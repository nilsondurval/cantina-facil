using Microsoft.EntityFrameworkCore;
using CantinaFacil.Infrastructure.Data.Context;
using CantinaFacil.Domain.Aggregates.Perfis.Repository;
using CantinaFacil.Domain.Aggregates.Perfis;

namespace CantinaFacil.Infrastructure.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
        public PerfilRepository(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
