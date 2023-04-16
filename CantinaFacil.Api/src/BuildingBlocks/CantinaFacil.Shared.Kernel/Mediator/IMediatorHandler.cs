using FluentValidation.Results;
using CantinaFacil.Shared.Kernel.Messaging;
using System.Threading.Tasks;

namespace CantinaFacil.Shared.Kernel.Mediator
{
    public interface IMediatorHandler
    {
        Task PublishEvent<T>(T @event) where T : Event;
        Task<ValidationResult> SendCommand<T>(T command) where T : Command;
    }
}