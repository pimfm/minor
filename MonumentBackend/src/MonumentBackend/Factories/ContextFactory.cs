
namespace MonumentBackend.Factories
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
