using CantinaFacil.Application.ViewModels.Estabelecimentos;

namespace CantinaFacil.Application.Services.Interfaces
{
    public interface IEstabelecimentoAppService : IDisposable
    {
        Task AdicionarAsync(AdicionarEstabelecimentoViewModel estabelecimento);
        Task<IEnumerable<ObterEstabelecimentoViewModel>> ObterAsync(int usuarioId);
        Task AtualizarAsync(int estabelecimentoId, AtualizarEstabelecimentoViewModel estabelecimento);
        Task RemoverAsync(int estabelecimentoId);
    }
}
