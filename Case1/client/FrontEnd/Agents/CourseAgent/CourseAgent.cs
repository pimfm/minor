using Frontend.Agents;
using Frontend.Agents.Models;
using System;
using System.Collections.Generic;

namespace FrontEnd.Agents.CourseAgent
{
    public class CourseAgent : ICourseAgent
    {
        private CourseService _service;

        public CourseAgent()
        {
            _service = new CourseService();
            _service.BaseUri = new Uri(@"http://localhost:2829/");
        }

        public IEnumerable<Course> FindAll()
        {
            return _service.FindAllCourses();
        }

        public IEnumerable<Course> FindInWeek(int week, int year)
        {
            return _service.FindCoursesInWeek(week, year);
        }

        public UploadReport Save(IList<Course> courses)
        {
            return _service.AddMultipleCourses(courses);
        }
    }
}
