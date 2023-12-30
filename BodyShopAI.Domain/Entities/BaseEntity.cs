using MediatR;
using System;
using System.Collections.Generic;

namespace Ats.Domain.Library.Entities
{
    [Serializable]
    public abstract class BaseEntity
    {
        private List<INotification> _domainEvents;
        public List<INotification> DomainEvents => _domainEvents;

        private List<INotification> _domainEventsServiceBus;
        public List<INotification> DomainEventsServiceBus => _domainEventsServiceBus;

        private List<INotification> _nonPublishDomainEvents;
        public List<INotification> NonPublishDomainEvents => _nonPublishDomainEvents;

        public void AddDomainEvent(INotification eventItem, bool asynchronous = false, bool nonPublish = false)
        {
            if (nonPublish)
            {
                _nonPublishDomainEvents = _nonPublishDomainEvents ?? new List<INotification>();
                _nonPublishDomainEvents.Add(eventItem);
            }
            else if (!asynchronous)
            {
                _domainEvents = _domainEvents ?? new List<INotification>();
                _domainEvents.Add(eventItem);
            }
            else
            {
                _domainEventsServiceBus = _domainEventsServiceBus ?? new List<INotification>();
                _domainEventsServiceBus.Add(eventItem);

            }
        }
    }
}