
using System;

namespace Minor.WSA.Common.Domain
{
    public abstract class DomainCommand
    {
        public readonly Guid Guid;
        public readonly DateTime Timestamp;

        public DomainCommand()
        {
            Guid = Guid.NewGuid();
            Timestamp = DateTime.Now;
        }
    }
}
