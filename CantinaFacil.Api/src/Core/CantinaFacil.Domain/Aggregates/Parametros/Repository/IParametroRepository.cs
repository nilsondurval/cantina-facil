using CantinaFacil.Domain.Aggregates.Parametros.Enumeration;
using CantinaFacil.Shared.Kernel.Data;

namespace CantinaFacil.Domain.Aggregates.Parametros.Repository
{
    public interface IParametroRepository : IRepository<Parametro>
    {
        Task<Parametro> ObterParametroPorChaveAsync(string chave);
    }
}
