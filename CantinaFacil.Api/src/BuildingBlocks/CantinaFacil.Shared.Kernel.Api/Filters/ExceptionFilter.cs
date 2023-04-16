using CantinaFacil.Shared.Kernel.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using CantinaFacil.Shared.Kernel.Api.ViewModels;

namespace CantinaFacil.Shared.Kernel.Api.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public ExceptionFilter()
        {
        }

        public void OnException(ExceptionContext context)
        {
            if (context.Exception is DomainException)
            {
                context.Result = new OkObjectResult(new ResponseResult
                {
                    Success = false,
                    Notifications = new List<string> { context.Exception.Message }
                });
            }
            else
            {
                context.Result = new BadRequestObjectResult(new ResponseResult
                {
                    Success = false,
                    Notifications = new List<string> { "Sistema indisponível no momento, se o erro persistir, contate o administrador do sistema." }
                });
            }

            context.ExceptionHandled = true;
        }
    }
}
