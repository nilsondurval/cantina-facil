using CantinaFacil.Application.ViewModels.Login;
using CantinaFacil.Application.ViewModels.Usuario;

namespace CantinaFacil.Application.Services.Interfaces
{
    public interface IUsuarioAppService : IDisposable
    {
        Task AdicionarAsync(AdicionarUsuarioViewModel usuario);
        Task<ObterUsuarioViewModel?> ObterAsync(int usuarioId);
        Task AtualizarAsync(int usuarioId, AtualizarUsuarioViewModel usuario);
        Task RemoverAsync(int usuarioId);
    }
}
