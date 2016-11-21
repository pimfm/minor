using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Services;

namespace WebAPIServiceLayer.Infrastructure.Factories
{
    public class CourseAdministrationDbContextFactory : IManufacturesContext<CourseAdministrationDbContext>
    {
        private IServiceLocator _serviceLocator;

        public CourseAdministrationDbContextFactory(IServiceLocator serviceLocator)
        {
            _serviceLocator = serviceLocator;
        }

        public CourseAdministrationDbContext ManufactureContext()
        {
            return _serviceLocator.Locate<CourseAdministrationDbContext>();
        }
    }
}
