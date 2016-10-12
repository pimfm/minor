using WebAPIServiceLayer.Domain.Entities;
using System.Collections.Generic;
using WebAPIServiceLayer.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPIServiceLayer.Domain.Comparer;
using System;
using System.Globalization;
using Swashbuckle.SwaggerGen.Annotations;
using Domain.Entities;

namespace WebAPIServiceLayer.Application.Controllers
{
    [Route("api/v1/courses")]
    public class CoursesController
    {
        private ICourseRepository _repository;
        private DateTimeFormatInfo _info;
        private Calendar _calendar;

        public CoursesController(ICourseRepository repository)
        {
            _repository = repository;

            _info = new DateTimeFormatInfo();
            _info.FirstDayOfWeek = DayOfWeek.Monday;

            _calendar = _info.Calendar;
        }

        [HttpGet]
        [SwaggerOperation("FindAllCourses")]
        [ProducesResponseType(typeof(IEnumerable<Course>), 200)]
        public IEnumerable<Course> FindAll()
        {
            return _repository.FindAll();
        }

        [HttpGet("week/{week}/year/{year}")]
        [SwaggerOperation("FindCoursesInWeek")]
        [ProducesResponseType(typeof(IEnumerable<Course>), 200)]
        public IEnumerable<Course> FindInWeek(int week, int year)
        {
            return _repository.FindByWeek(week, year);
        }

        [HttpPost]
        [SwaggerOperation("AddMultipleCourses")]
        [ProducesResponseType(typeof(UploadReport), 200)]
        public UploadReport AddRange([FromBody] IEnumerable<Course> courses)
        {
            IEnumerable<Course> newCourses = courses.Except(FindAll(), new CourseComparer());
            int newCoursesCount = newCourses.Count();

            if (newCoursesCount > 0) {
                _repository.InsertRange(newCourses);
            }

            return new UploadReport(newCoursesCount, courses.Count());
        }
    }
}