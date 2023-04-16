using CantinaFacil.Shared.Kernel.Messaging;
using System;

namespace CantinaFacil.Shared.Kernel.Domain.Events
{
    public class DomainNotificationEvent : Event
    {
        public Guid DomainNotificationId { get; private set; }
        public string Key { get; private set; }
        public string Value { get; private set; }
        public DomainNotificationType Type { get; private set; }

        public DomainNotificationEvent(DomainNotificationType type, string key, string value)
        {
            DomainNotificationId = Guid.NewGuid();
            Type = type;
            Key = key;
            Value = value;
        }
    }
}
