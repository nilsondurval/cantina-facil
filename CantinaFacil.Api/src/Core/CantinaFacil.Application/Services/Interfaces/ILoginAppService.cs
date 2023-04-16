using CantinaFacil.Application.ViewModels.Login;

namespace CantinaFacil.Application.Services.Interfaces
{
    public interface ILoginAppService : IDisposable
    {
        Task<string> AutenticarAsync(LoginViewModel login);
    }
}
