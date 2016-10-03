using Microsoft.EntityFrameworkCore;

namespace Application.Factories
{
    public interface ContextFactory<ContextType>
    {
        ContextType MakeContext();
    }
}