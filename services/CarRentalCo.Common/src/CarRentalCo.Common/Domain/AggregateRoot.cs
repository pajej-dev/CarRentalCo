using System;
using System.Collections.Generic;
using System.Text;

namespace CarRentalCo.Common.Domain
{
    public abstract class AggregateRoot
    {
        private List<IDomainEvent> _domainEvents;

        public int Version { get; protected set; }
        public IEnumerable<IDomainEvent> Events => _domainEvents;
        protected void AddDomainEvent(IDomainEvent domainEvent)
        {
            _domainEvents = _domainEvents ?? new List<IDomainEvent>();
            this._domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents?.Clear();
        }

    }

}
