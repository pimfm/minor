
using Frontend.Agents.Models;
using System;

namespace FrontEnd.Factories
{
    public class CourseMomentFactory : ICourseMomentFactory
    {
        public CourseMoment MakeCourseMoment(string title, string code, int duration, DateTime startDate)
        {
            Course course = new Course(null, title, code, duration);
            return new CourseMoment(null, course, startDate);
        }
    }
}
