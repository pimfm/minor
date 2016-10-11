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

        public IEnumerable<Course> FindAllCourses()
        {
            return _service.ApiV1CoursesGet();
        }

        public string SaveCourses(IList<Course> courses)
        {
            return _service.ApiV1CoursesPost(courses);
        }
    }
}
