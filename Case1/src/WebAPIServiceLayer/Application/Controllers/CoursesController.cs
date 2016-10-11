using WebAPIServiceLayer.Domain.Entities;
using System.Collections.Generic;
using WebAPIServiceLayer.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPIServiceLayer.Domain.Comparer;
using System;
using WebAPIServiceLayer.Application.Services;

namespace WebAPIServiceLayer.Application.Controllers
{
    [Route("api/v1/courses")]
    public class CoursesController
    {
        private ICourseRepository _repository;

        public CoursesController(ICourseRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Course>), 200)]
        public IEnumerable<Course> All()
        {
            return _repository.FindAll();;
        }
        
        [HttpPost]
        [ProducesResponseType(typeof(UploadReport), 200)]
        public UploadReport AddRange([FromBody] IEnumerable<Course> courses)
        {
            IEnumerable<Course> newCourses = courses.Except(All(), new CourseComparer());
            int newCoursesCount = newCourses.Count();

            if (newCoursesCount > 0) {
                _repository.InsertRange(newCourses);
            }

            return new UploadReport(newCoursesCount, courses.Count());
        }
    }
}