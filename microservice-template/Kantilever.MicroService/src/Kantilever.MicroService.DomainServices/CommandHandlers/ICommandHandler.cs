using Kantilever.MicroService.Domain.Commands;

namespace Kantilever.MicroService.DomainServices.CommandHandlers
{
    //NOTE: This interface should be in common
    public interface ICommandHandler<TCommand>
        where TCommand : DomainCommand
    {
        void Handle(TCommand command);
    }
}
