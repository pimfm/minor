using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Contracts;
using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Factories;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPIServiceLayer.Infrastructure.Services;
using System;

namespace WebAPIServiceLayer.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<CourseMoment, CourseAdministrationDbContext>, ICourseRepository
    {
        private IManufacturesContext<CourseAdministrationDbContext> _factory;
        private IDateScheduler _scheduler;

        public CourseRepository(IManufacturesContext<CourseAdministrationDbContext> factory, IDateScheduler scheduler) : base(factory)
        {
            _factory = factory;
            _scheduler = scheduler;
        }

        public CourseMoment Find(int key)
        {
            using (var context = _factory.ManufactureContext())
            {
                return context.CourseMoments
                            .Where(c => c.ID == key)
                            .FirstOrDefault();
            }
        }

        public Course FindCourse(string code)
        {
            using (var context = _factory.ManufactureContext())
            {
                return context.CourseMoments
                            .Where(c => c.Course.Code == code)
                            .Select(c => c.Course)
                            .FirstOrDefault();
            }
        }

        public override IEnumerable<CourseMoment> FindAll()
        {
            using (var context = _factory.ManufactureContext())
            {
                return context.CourseMoments.Include(courseMoment => courseMoment.Course).ToList();
            }
        }

        public IEnumerable<CourseMoment> FindByWeek(int week, int year)
        {
            using (var context = _factory.ManufactureContext())
            {
                return context.CourseMoments
                        .Where(moment => _scheduler.IsInWeek(moment.StartDate, week, year))
                        .Include(courseMoment => courseMoment.Course);
            }
        }

        public void InsertCourse(Course course)
        {
            using (var context = _factory.ManufactureContext())
            {
                context.Courses.Add(course);
                context.SaveChanges();
            }
        }
    }
}
