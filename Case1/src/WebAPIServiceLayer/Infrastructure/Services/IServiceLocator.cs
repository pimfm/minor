namespace BackendService.Infrastructure.Services
{
    public interface IServiceLocator
    {
        TService Locate<TService>();
    }
}