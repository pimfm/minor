using BackendService.Domain.Entities;

namespace BackendService.Domain.Contracts
{
    public interface ICourseRepository : IFullRepository<Course, int>
    {
    }
}
