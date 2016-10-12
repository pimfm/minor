using WebAPIServiceLayer.Domain.Entities;
using System.Collections.Generic;
using WebAPIServiceLayer.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Globalization;
using Swashbuckle.SwaggerGen.Annotations;
using WebAPIServiceLayer.Domain.Comparer;

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
        [SwaggerOperation("FindAllCourseMoments")]
        [ProducesResponseType(typeof(IEnumerable<CourseMoment>), 200)]
        public IEnumerable<CourseMoment> FindAll()
        {
            return _repository.FindAll();
        }

        [HttpGet("week/{week}/year/{year}")]
        [SwaggerOperation("FindCourseMomentsInWeek")]
        [ProducesResponseType(typeof(IEnumerable<CourseMoment>), 200)]
        public IEnumerable<CourseMoment> FindInWeek(int week, int year)
        {
            return _repository.FindByWeek(week, year);
        }

        [HttpPost]
        [SwaggerOperation("AddMultipleCourseMoments")]
        [ProducesResponseType(typeof(UploadReport), 200)]
        public UploadReport AddMultipleCourseMoments([FromBody] IEnumerable<CourseMoment> courseMoments)
        {
            IEnumerable<CourseMoment> newCourseMoments = courseMoments.Except(FindAll(), new CourseMomentComparer());
            int newCoursesCount = newCourseMoments.Count();

            if (newCoursesCount > 0) {
                _repository.InsertRange(newCourseMoments);
            }

            return new UploadReport(newCoursesCount, courseMoments.Count());
        }
    }
}