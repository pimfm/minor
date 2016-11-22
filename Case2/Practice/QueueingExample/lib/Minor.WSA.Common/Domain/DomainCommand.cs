using System;

namespace Minor.WSA.Common.Domain
{
    /// <summary>
    ///     Base class for every domain command
    ///     holding data that can be generated
    ///     at command creation and is part of every command
    /// </summary>
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
