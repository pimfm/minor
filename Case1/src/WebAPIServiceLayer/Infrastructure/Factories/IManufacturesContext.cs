
namespace BackendService.Infrastructure.Factories
{ 
    public interface IManufacturesContext<ContextType>
    {
        ContextType ManufactureContext();
    }
}