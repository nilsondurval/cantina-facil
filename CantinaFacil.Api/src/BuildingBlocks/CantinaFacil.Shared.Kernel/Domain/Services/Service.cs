using FluentValidation.Results;
using CantinaFacil.Shared.Kernel.Domain.Events;
using CantinaFacil.Shared.Kernel.Mediator;
using System.Collections.Generic;

namespace CantinaFacil.Shared.Kernel.Domain.Services
{
    public abstract class Service
    {
        private readonly IMediatorHandler _mediator;

        protected Service(IMediatorHandler mediator)
        {
            _mediator = mediator;
        }

        protected void RaiseError(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
                _mediator.PublishEvent(new DomainNotificationEvent(DomainNotificationType.Error, error.PropertyName, error.ErrorMessage));
        }

        protected void RaiseError(List<ValidationResult> validationResults)
        {
            foreach (var validationResult in validationResults)
            {
                foreach (var error in validationResult.Errors)
                    _mediator.PublishEvent(new DomainNotificationEvent(DomainNotificationType.Error, error.PropertyName, error.ErrorMessage));
            }
        }

        protected void RaiseError(string message)
        {
            _mediator.PublishEvent(new DomainNotificationEvent(DomainNotificationType.Error, GetType().Name, message));
        }

        protected void RaiseInformation(string message)
        {
            _mediator.PublishEvent(new DomainNotificationEvent(DomainNotificationType.Information, GetType().Name, message));
        }
    }
}
