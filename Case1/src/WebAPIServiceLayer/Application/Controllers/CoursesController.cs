using WebAPIServiceLayer.Domain.Entities;
using System.Collections.Generic;
using WebAPIServiceLayer.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebAPIServiceLayer.Domain.Comparer;
using System;

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
        [ProducesResponseType(typeof(string), 200)]
        public string AddRange([FromBody] IEnumerable<Course> courses)
        {
            IEnumerable<Course> newCourses = courses.Except(All(), new CourseComparer());
            int newCoursesCount = newCourses.Count();

            if (newCoursesCount > 0) {
                _repository.InsertRange(newCourses);
            }

            return ProvideInsertionReport(newCoursesCount, courses.Count());
        }

        private string ProvideInsertionReport(int insertedCount, int allCount)
        {
            int duplicateCount = allCount - insertedCount;

            if (allCount == 0)
            {
                return "Dit bestand bevat geen cursussen, controleer of het goede bestand is geselecteerd.";
            }

            if (insertedCount == 0)
            {
                return $"Geen nieuwe cursussen gevonden. Alle {allCount} cursussen waren al aanwezig. Controleer of het goede bestand is geselecteerd.";
            }

            if (duplicateCount == 0)
            {
                return $"Alle {insertedCount} cursussen zijn nieuw toegevoegd!";
            }

            return $"{insertedCount} cursussen toegevoegd! {duplicateCount} cursussen niet toegevoegd, omdat ze al aanwezig waren.";
        }
    }
}