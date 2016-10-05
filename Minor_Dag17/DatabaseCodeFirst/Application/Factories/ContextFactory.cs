using DatabaseCodeFirst.Infrastructure.Database;

namespace DatabaseCodeFirst.Application.Factories
{
    public class ContextFactory<TContext> : ManufacturesContext<TContext>
        where TContext : new()
    {
        public TContext ManufactureContext()
        {
            return new TContext();
        }
    }
}
