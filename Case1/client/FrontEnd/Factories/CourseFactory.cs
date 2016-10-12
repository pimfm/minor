
using Frontend.Agents.Models;
using System;
using System.Collections.Generic;

namespace FrontEnd.Factories
{
    public class CourseFactory
    {
        public Course ManufactureCourse(string title, string code, int duration)
        {
            return new Course(null, title, code, duration);
        }

        public CourseMoment ManufactureCourseMoment(Course course, DateTime startDate)
        {
            return new CourseMoment(null, null, course, startDate);
        }

        public Course ManufactureCourse(string title, string code, int duration, DateTime startDate)
        {
            Course course = ManufactureCourse(title, code, duration);
            CourseMoment moment = ManufactureCourseMoment(course, startDate);

            course.Moments = new List<CourseMoment>();
            course.Moments.Add(moment);

            return course;
        }
    }
}
