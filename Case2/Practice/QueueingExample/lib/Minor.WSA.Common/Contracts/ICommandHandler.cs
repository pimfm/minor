using Minor.WSA.Common.Domain;
using System.Threading.Tasks;

namespace Minor.WSA.Common.Contracts
{
    public interface ICommandHandler<TCommand> 
        where TCommand : DomainCommand
    {
        Task Handle(TCommand domainCommand);
    }
}