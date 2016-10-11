using Frontend.Agents.Models;
using System.Collections.Generic;

namespace FrontEnd.Agents.CourseAgent
{
    public interface ICourseAgent
    {
        IEnumerable<Course> FindAllCourses();
        string SaveCourses(IList<Course> courses);
    }
}