using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Contracts;
using WebAPIServiceLayer.Infrastructure.DataAccessLayer;
using WebAPIServiceLayer.Infrastructure.Factories;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System;
using Microsoft.EntityFrameworkCore;

namespace WebAPIServiceLayer.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<CourseMoment, CourseAdministrationDbContext>, ICourseRepository
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

        public CourseMoment Find(int key)
        {
            CourseMoment courseMoment = FindOneBy(c => c.ID == key);

            if (courseMoment == null)
            {
                throw new KeyNotFoundException();
            }

            return courseMoment;
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
                return context.CourseMoments.Where(moment => IsInWeek(moment, week, year)).Include(courseMoment => courseMoment.Course);
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
