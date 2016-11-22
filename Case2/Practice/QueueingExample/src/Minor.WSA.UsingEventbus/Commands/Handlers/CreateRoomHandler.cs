using System;
using System.Threading.Tasks;
using Minor.WSA.Common.Contracts;

namespace Minor.WSA.UsingEventbus.Commands.Handlers
{
    public class CreateRoomHandler : ICommandHandler<CreateRoomCommand>
    {
        public void Handle(CreateRoomCommand domainCommand)
        {
            throw new NotImplementedException();
        }
    }
}
