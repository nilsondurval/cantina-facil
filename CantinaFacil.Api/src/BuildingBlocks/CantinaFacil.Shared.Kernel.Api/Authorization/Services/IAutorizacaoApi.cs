using Refit;
using CantinaFacil.Shared.Kernel.Api.ViewModels;
using System.Threading.Tasks;

namespace CantinaFacil.Shared.Kernel.API.Authorization.Services
{
    public interface IBaseAutorizacaoApi
    {
        [Get("/autorizacao/chave-publica")]
        Task<ResponseResult> ObterChavePublicaAsync();
    }
}