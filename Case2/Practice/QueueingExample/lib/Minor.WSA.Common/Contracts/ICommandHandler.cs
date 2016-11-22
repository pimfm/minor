using Minor.WSA.Common.Domain;
using System.Threading.Tasks;

namespace Minor.WSA.Common.Contracts
{
    /// <summary>
    ///     Use a handler to listen for a command
    ///     and implement the handle method to add
    ///     functionality to when the command is fired.
    /// </summary>
    /// <example>
    ///     public class CreateRoomHandler : ICommandHandler<CreateRoomCommand>
    /// </example>
    /// <typeparam name="TEvent"></typeparam>
    public interface ICommandHandler<TCommand> 
        where TCommand : DomainCommand
    {
        /// <summary>
        ///     Add functionality to a triggered command
        /// </summary>
        /// <param name="domainCommand"></param>
        /// <returns></returns>
        Task Handle(TCommand domainCommand);
    }
}