using CantinaFacil.Shared.Kernel.Domain;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Domain.Handlers;
using CantinaFacil.Shared.Kernel.Mediator;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using CantinaFacil.Shared.Kernel.Api.ViewModels;

namespace CantinaFacil.Shared.Kernel.Api.Controllers
{
    public class MainController : ControllerBase
    {
        private readonly DomainNotificationEventHandler _notifications;
        private readonly IMediatorHandler _mediator;

        public MainController(INotificationHandler<DomainNotificationEvent> notifications, IMediatorHandler mediator)
        {
            _notifications = (DomainNotificationEventHandler)notifications;
            _mediator = mediator;
        }

        protected new IActionResult Response(object result = null)
        {
            var success = IsValidOperation();

            return Ok(new ResponseResult
            {
                Success = success,
                Notifications = _notifications.GetNotifications().Select(n => n.Value).ToList(),
                Data = success ? result : null
            });
        }
        
        protected bool IsValidOperation()
        {
            return !_notifications.HasError();
        }

        protected void RaiseErrorModel()
        {
            var erros = ModelState.Values.SelectMany(x => x.Errors);

            foreach (var erro in erros)
                _mediator.PublishEvent(new DomainNotificationEvent(DomainNotificationType.Error, "ViewModel", erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message));
        }

        protected void RaiseError(string error)
        {
            _mediator.PublishEvent(new DomainNotificationEvent(DomainNotificationType.Error, "ViewModel", error));
        }

        protected virtual bool ModelStateIsValid()
        {
            if (ModelState.IsValid) 
                return true;

            RaiseErrorModel();
            return false;
        }
    }
}
