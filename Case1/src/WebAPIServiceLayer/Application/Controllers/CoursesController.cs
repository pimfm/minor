using BackendService.Domain.Entities;

using System.Collections.Generic;
using BackendService.Domain.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using BackendService.Domain.Comparer;
using System;

namespace BackendService.Application.Controllers
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
        public IEnumerable<Course> All()
        {
            return _repository.FindAll();
        }
        
        [HttpPost]
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
                return "No courses provided, please check if your file contains courses";
            }

            if (insertedCount == 0)
            {
                return $"All {allCount} courses were duplicates, no new courses inserted.";
            }

            if (duplicateCount == 0)
            {
                return $"All {insertedCount} courses were newly inserted, no duplicated!";
            }

            return $"{insertedCount} courses inserted! {duplicateCount} not inserted, due to duplication.";
        }
    }
}