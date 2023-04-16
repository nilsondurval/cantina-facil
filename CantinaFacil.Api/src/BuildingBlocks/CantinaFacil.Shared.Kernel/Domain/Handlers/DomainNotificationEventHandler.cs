using MediatR;
using CantinaFacil.Shared.Kernel.Domain.Events;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CantinaFacil.Shared.Kernel.Domain.Handlers
{
    public class DomainNotificationEventHandler : INotificationHandler<DomainNotificationEvent>
    {
        private List<DomainNotificationEvent> _notifications;

        public DomainNotificationEventHandler()
        {
            _notifications ??= new List<DomainNotificationEvent>();
        }

        public Task Handle(DomainNotificationEvent notification, CancellationToken cancellationToken)
        {
            _notifications.Add(notification);
            return Task.CompletedTask;
        }

        public List<DomainNotificationEvent> GetNotifications(DomainNotificationType? type = null)
        {
            return _notifications.Where(x => type is null || x.Type == type).ToList();
        }

        public virtual List<DomainNotificationEvent> GetErrors()
        {
            return GetNotifications(DomainNotificationType.Error);
        }

        public virtual List<DomainNotificationEvent> GetInformations()
        {
            return GetNotifications(DomainNotificationType.Information);
        }

        public bool HasNotifications()
        {
            return GetNotifications().Any();
        }

        public bool HasError()
        {
            return GetErrors() != null ? GetErrors().Any() : false;
        }

        public bool HasInformation()
        {
            return GetInformations().Any();
        }

        public void ClearNotifications()
        {
            _notifications = new List<DomainNotificationEvent>();
        }
    }
}
