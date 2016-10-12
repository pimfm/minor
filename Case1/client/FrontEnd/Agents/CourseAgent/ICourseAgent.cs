using Frontend.Agents.Models;
using System.Collections.Generic;

namespace FrontEnd.Agents.CourseAgent
{
    public interface ICourseAgent
    {
        IEnumerable<Course> FindAll();
        IEnumerable<Course> FindInWeek(int week, int year);
        UploadReport Save(IList<Course> courses);
    }
}