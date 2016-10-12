using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Contracts;
using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Factories;
using System.Collections.Generic;
using System.Linq;
using Domain.Entities;
using System.Globalization;
using System;

namespace WebAPIServiceLayer.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course, CourseAdministrationDbContext>, ICourseRepository
    {
        private Calendar _calendar;
        private IManufacturesContext<CourseAdministrationDbContext> _factory;
        private DateTimeFormatInfo _info;

        public CourseRepository(IManufacturesContext<CourseAdministrationDbContext> factory) : base(factory)
        {
            _factory = factory;

            _info = new DateTimeFormatInfo();
            _info.FirstDayOfWeek = DayOfWeek.Monday;

            _calendar = _info.Calendar;
        }

        public Course Find(int key)
        {
            Course course = FindOneBy(c => c.ID == key);

            if (course == null)
            {
                throw new KeyNotFoundException();
            }

            return course;
        }

        public IEnumerable<Course> FindByWeek(int week, int year)
        {
            using (var context = _factory.ManufactureContext())
            {
                return context.CourseMoments.Where(moment => IsInWeek(moment, week, year)).Select(moment => moment.Course);
            }
        }
        
        private bool IsInWeek(CourseMoment moment, int week, int year)
        {
            int courseWeek = _calendar.GetWeekOfYear(moment.StartDate, _info.CalendarWeekRule, _info.FirstDayOfWeek);
            int courseYear = _calendar.GetYear(moment.StartDate);

            return courseWeek == week && courseYear == year;
        }
    }
}
