namespace CantinaFacil.Domain.Aggregates.Usuarios.Services
{
    public interface IUsuarioService : IDisposable
    {
        Task AdicionarAsync(Usuario usuario);
        Task AtualizarAsync(int usuarioId, Usuario usuario);
        Task RemoverAsync(int usuarioId);
        string GerarToken(Usuario usuario, string privateKey, string expirationMinutes);
    }
}
