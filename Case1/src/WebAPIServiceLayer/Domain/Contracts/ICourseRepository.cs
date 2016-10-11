using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Domain.Contracts
{
    public interface ICourseRepository : IFullRepository<Course, int>
    {
    }
}
