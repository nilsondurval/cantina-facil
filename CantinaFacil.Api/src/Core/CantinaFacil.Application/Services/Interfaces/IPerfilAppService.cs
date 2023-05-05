using CantinaFacil.Application.ViewModels.Perfil;

namespace CantinaFacil.Application.Services.Interfaces
{
    public interface IPerfilAppService : IDisposable
    {
        Task<IEnumerable<ObterPerfilViewModel>> ObterTodosAsync();
    }
}
