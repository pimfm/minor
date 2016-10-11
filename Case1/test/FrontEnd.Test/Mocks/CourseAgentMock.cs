using FrontEnd.Agents.CourseAgent;
using System.Collections.Generic;
using Frontend.Agents.Models;

namespace FrontEnd.Test.Mocks
{
    public class CourseAgentMock : ICourseAgent
    {
        public bool FindAllCoursesCalled { get; private set; }
        public bool SaveCoursesCalled { get; private set; }
        public IList<Course> SaveCoursesParameter { get; private set; }

        public IEnumerable<Course> FindAllCourses()
        {
            FindAllCoursesCalled = true;
           
            return new List<Course>()
            {
                new Course(12, "Title"),
                new Course(13, "Kitle"),
            };
        }

        public void SaveCourses(IList<Course> courses)
        {
            SaveCoursesCalled = true;
            SaveCoursesParameter = courses;
        }
    }
}
