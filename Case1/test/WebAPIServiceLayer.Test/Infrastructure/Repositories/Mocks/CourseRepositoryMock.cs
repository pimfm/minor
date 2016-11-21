using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Contracts;
using System.Linq;

namespace WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks
{
    internal class CourseRepositoryMock : ICourseRepository
    {
        public bool CountIsCalled { get; private set; }
        public bool DeleteIsCalled { get; private set; }
        public CourseMoment DeleteParameter { get; private set; }
        public bool FindAllIsCalled { get; private set; }
        public bool FindByIsCalled { get; private set; }
        public Expression<Func<CourseMoment, bool>> FindByParameter { get; private set; }
        public bool FindByWeekIsCalled { get; private set; }
        public int FindByWeekParameterWeek { get; private set; }
        public int FindByWeekParameterYear { get; private set; }
        public bool FindCourseIsCalled { get; private set; }
        public string FindCourseParameter { get; private set; }
        public bool FindIsCalled { get; private set; }
        public bool FindOneByIsCalled { get; private set; }
        public Expression<Func<CourseMoment, bool>> FindOneByParameter { get; private set; }
        public int FindParameter { get; private set; }
        public bool InsertIsCalled { get; private set; }
        public CourseMoment InsertParameter { get; private set; }
        public bool InsertRangeIsCalled { get; private set; }
        public IEnumerable<CourseMoment> InsertRangeParameter { get; private set; }
        public bool UpdateIsCalled { get; private set; }
        public CourseMoment UpdateParameter { get; private set; }

        public int Count()
        {
            CountIsCalled = true;

            return 0;
        }

        public void Delete(CourseMoment entity)
        {
            DeleteIsCalled = true;
            DeleteParameter = entity;
        }

        public CourseMoment Find(int key)
        {
            FindIsCalled = true;
            FindParameter = key;

            return null;
        }

        public IEnumerable<CourseMoment> FindAll()
        {
            FindAllIsCalled = true;

            return new List<CourseMoment>();
        }

        public IEnumerable<CourseMoment> FindBy(Expression<Func<CourseMoment, bool>> filter)
        {
            FindByIsCalled = true;
            FindByParameter = filter;

            return null;
        }

        public IEnumerable<CourseMoment> FindByWeek(int week, int year)
        {
            FindByWeekIsCalled = true;
            FindByWeekParameterWeek = week;
            FindByWeekParameterYear = year;

            return null;
        }

        public Course FindCourse(string code)
        {
            FindCourseIsCalled = true;
            FindCourseParameter = code;

            return null;
        }

        public CourseMoment FindOneBy(Expression<Func<CourseMoment, bool>> filter)
        {
            FindOneByIsCalled = true;
            FindOneByParameter = filter;

            return null;
        }

        public void Insert(CourseMoment entity)
        {
            InsertIsCalled = true;
            InsertParameter = entity;
        }

        public void InsertRange(IEnumerable<CourseMoment> entities)
        {
            InsertRangeIsCalled = true;
            InsertRangeParameter = entities;
        }

        public void Update(CourseMoment entity)
        {
            UpdateIsCalled = true;
            UpdateParameter = entity;
        }
    }
}