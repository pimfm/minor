
using Frontend.Agents.Models;
using FrontEnd.Agents.CourseAgent;
using System;

namespace FrontEnd.Factories
{
    public class CourseMomentFactory : ICourseMomentFactory
    {
        public Course Manufacture(string title, string code, int duration)
        {
            return new Course(title, code, duration);
        }

        public CourseMoment Manufacture(string title, string code, int duration, DateTime startDate)
        {
            Course course = Manufacture(title, code, duration);

            return new CourseMoment(null, null, course, startDate);
        }
    }
}
