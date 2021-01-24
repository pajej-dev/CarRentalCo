using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalCo.Common.Domain
{
    public abstract class AggregateRoot
    {
        private List<IDomainEvent> domainEvents;

        public int Version { get; protected set; }
        public IEnumerable<IDomainEvent> Events => domainEvents;
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            domainEvents = domainEvents ?? new List<IDomainEvent>();
            this.domainEvents.Add(domainEvent);
            Version++;
        }

        public void ClearDomainEvents() 
        {
            domainEvents?.Clear();
        }
    }
}
