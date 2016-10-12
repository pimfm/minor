using System.Collections.Generic;
using WebAPIServiceLayer.Domain.Entities;

namespace WebAPIServiceLayer.Domain.Contracts
{
    public interface ICourseRepository : IFullRepository<Course, int>
    {
        IEnumerable<Course> FindByWeek(int week, int year);
    }
}
