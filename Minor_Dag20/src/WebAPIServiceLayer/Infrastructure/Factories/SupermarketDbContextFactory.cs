using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Services;

namespace WebAPIServiceLayer.Infrastructure.Factories
{
    public class SupermarketDbContextFactory : IManufacturesContext<SupermarketDbContext>
    {
        private IServiceLocator _serviceLocator;

        public SupermarketDbContextFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public SupermarketDbContext ManufactureContext()
        {
            return _serviceLocator.Locate<SupermarketDbContext>();
        }
    }
}
