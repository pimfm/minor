using Application.Factories;
using DatabaseCodeFirst.Infrastructure.Database;

namespace DatabaseCodeFirst.Application.Factories
{
    public class PartyContextFactory : ContextFactory<PartyContext>
    {
        public PartyContext MakeContext()
        {
            return new PartyContext();
        }
    }
}
