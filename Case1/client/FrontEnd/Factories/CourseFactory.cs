
using Frontend.Agents.Models;
using System;
using System.Collections.Generic;

namespace FrontEnd.Factories
{
    public class CourseFactory
    {
        public Course MakeCourse(string title, string code, int duration, DateTime? startDate)
        {
            if (startDate != null)
            {
                IList<CourseMoment> moments = new CourseMoment(null, null, startDate);
                return new Course(null, title, code, duration, moments);
            }
            return new Course(null, title, code, duration);
        }
    }
}
