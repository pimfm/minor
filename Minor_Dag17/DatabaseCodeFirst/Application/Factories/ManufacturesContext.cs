namespace DatabaseCodeFirst.Application.Factories
{
    public interface ManufacturesContext<ContextType>
    {
        ContextType ManufactureContext();
    }
}