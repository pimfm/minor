
namespace WebAPIServiceLayer.Infrastructure.Factories
{ 
    public interface IManufacturesContext<ContextType>
    {
        ContextType ManufactureContext();
    }
}