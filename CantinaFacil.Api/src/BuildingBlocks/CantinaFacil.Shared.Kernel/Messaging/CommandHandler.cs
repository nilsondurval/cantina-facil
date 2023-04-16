using System.Threading.Tasks;
using FluentValidation.Results;
using CantinaFacil.Shared.Kernel.Data;

namespace CantinaFacil.Shared.Kernel.Messaging
{
    public abstract class CommandHandler
    {
        protected ValidationResult ValidationResult;

        protected CommandHandler()
        {
            ValidationResult = new ValidationResult();
        }

        protected void AddError(string mensagem)
        {
            ValidationResult.Errors.Add(new ValidationFailure(string.Empty, mensagem));
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow, string message)
        {
            if (!await uow.CommitAsync()) 
                AddError(message);

            return ValidationResult;
        }

        protected async Task<ValidationResult> Commit(IUnitOfWork uow)
        {
            return await Commit(uow, "Erro ao persistir dados").ConfigureAwait(false);
        }
    }
}