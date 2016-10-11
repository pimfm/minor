using FrontEnd.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Frontend.Agents.Models;

namespace FrontEnd.Test.Mocks
{
    public class CourseFileServiceMock : IFileService<Course>
    {
        public IEnumerable<Course> Produce()
        {
            return new List<Course>()
            {
                new Course(null, "Title"),
                new Course(null, "Kitle"),
            };
        }

        public void Validate(IFormFile file)
        {
            // Uber valid
        }
    }
}
