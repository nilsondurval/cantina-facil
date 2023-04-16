using System.Threading.Tasks;

namespace CantinaFacil.Shared.Kernel.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}