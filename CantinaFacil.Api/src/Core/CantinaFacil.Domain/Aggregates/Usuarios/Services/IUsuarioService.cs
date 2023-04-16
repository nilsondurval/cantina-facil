namespace CantinaFacil.Domain.Aggregates.Usuarios.Services
{
    public interface IUsuarioService : IDisposable
    {
        string GerarToken(Usuario usuario, string privateKey, string expirationMinutes);
    }
}
