using WebAPIServiceLayer.Domain.Entities;
using System.Collections.Generic;

namespace WebAPIServiceLayer.Domain.Contracts
{
    public interface ICourseRepository : IFullRepository<CourseMoment, int>
    {
        IEnumerable<CourseMoment> FindByWeek(int week, int year);
        Course FindCourse(string code);
    }
}
