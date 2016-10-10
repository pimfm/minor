using Entities;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace FrontEnd.Services
{
    public class CourseFactory
    {
        public IEnumerable<Course> ManufactureCourses(IFormFile blueprint)
        {
            return new List<Course>();
        }
    }
}
