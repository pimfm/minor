
namespace WebAPIServiceLayer.Infrastructure.Factories
{
    public class ContextFactory<TContext> : IManufacturesContext<TContext>
        where TContext : new()
    {
        public TContext ManufactureContext()
        {
            return new TContext();
        }
    }
}
