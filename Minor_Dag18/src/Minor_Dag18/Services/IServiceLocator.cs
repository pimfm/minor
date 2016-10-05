namespace Minor_Dag18.Services
{
    public interface IServiceLocator
    {
        TService Locate<TService>();
    }
}