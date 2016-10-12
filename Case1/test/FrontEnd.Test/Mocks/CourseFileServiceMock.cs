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
        public IList<Course> ReadFile(IFormFile file, DateTime? from, DateTime? to)
        {
            return new List<Course>();
        }
    }
}
