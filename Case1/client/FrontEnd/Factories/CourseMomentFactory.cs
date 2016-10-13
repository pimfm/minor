
using Frontend.Agents.Models;
using FrontEnd.Agents.CourseAgent;
using System;

namespace FrontEnd.Factories
{
    public class CourseMomentFactory : ICourseMomentFactory
    {
        private ICourseAgent _agent;

        public CourseMomentFactory(ICourseAgent agent)
        {
            _agent = agent;
        }

        public CourseMoment Manufacture(string title, string code, int duration, DateTime startDate)
        {
            Course course = _agent.FindOrCreateCourse(title, code, duration);

            return new CourseMoment(null, null, course, startDate);
        }
    }
}
