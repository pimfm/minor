using Kantilever.MicroService.Domain.Commands;

namespace $safeprojectname$.CommandHandlers
{
    //NOTE: This interface should be in common
    public interface ICommandHandler<TCommand>
        where TCommand : DomainCommand
    {
        void Handle(TCommand command);
    }
}
