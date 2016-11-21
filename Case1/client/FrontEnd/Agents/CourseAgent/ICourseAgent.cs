using Frontend.Agents.Models;
using System.Collections.Generic;

namespace FrontEnd.Agents.CourseAgent
{
    public interface ICourseAgent
    {
        IEnumerable<CourseMoment> FindAll();
        IEnumerable<CourseMoment> FindInWeek(int week, int year);
        UploadReport Upload(IList<CourseMoment> courses);
    }
}