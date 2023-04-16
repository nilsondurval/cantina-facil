using CantinaFacil.Shared.Kernel.Data;

namespace CantinaFacil.Domain.Aggregates.Usuarios.Repository
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> ObterAsync(string cpf);
        Task<Usuario?> ObterAsync(string email, string senha);
    }
}
