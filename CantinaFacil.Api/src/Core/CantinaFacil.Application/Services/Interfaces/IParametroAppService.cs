namespace CantinaFacil.Application.Services.Interfaces
{
    public interface IParametroAppService : IDisposable
    {
        Task<string> ObterChavePrivadaJwtAsync();
        Task<string> ObterChavePublicaJwtAsync();
        Task<string> ObterTempoExpiracaoJwtAsync();
    }
}
