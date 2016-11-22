using System;

namespace Minor.WSA.Common.Domain
{
    /// <summary>
    ///     Base class for domain event
    ///     holding data that can be generated
    ///     at event creation and is part of every event
    /// </summary>
    public abstract class DomainEvent
    {
        public readonly Guid Guid;
        public readonly DateTime Timestamp;

        public DomainEvent()
        {
            Guid = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }
    }
}
