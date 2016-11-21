namespace WebAPIServiceLayer.Infrastructure.Services
{
    public interface IServiceLocator
    {
        TService Locate<TService>();
    }
}