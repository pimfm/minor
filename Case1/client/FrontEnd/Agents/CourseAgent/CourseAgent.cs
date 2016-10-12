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

        public IEnumerable<CourseMoment> FindAll()
        {
            return _service.FindAllCourseMoments();
        }

        public IEnumerable<CourseMoment> FindInWeek(int week, int year)
        {
            return _service.FindCourseMomentsInWeek(week, year);
        }

        public UploadReport Upload(IList<CourseMoment> coursesMoments)
        {
            return _service.AddMultipleCourseMoments(coursesMoments);
        }
    }
}
