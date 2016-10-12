//using System;
//using System.Collections.Generic;
//using System.Linq.Expressions;
//using WebAPIServiceLayer.Domain.Entities;
//using WebAPIServiceLayer.Domain.Contracts;
//using System.Linq;

//namespace WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks
//{
//    internal class CourseRepositoryMock : ICourseRepository
//    {
//        private int _count;

//        public Course InsertParameter { get; private set; }
//        public IEnumerable<Course> InsertRangeParameter { get; private set; }

//        public int Count()
//        {
//            return _count;
//        }

//        public void Delete(Course item)
//        {
//            throw new NotImplementedException();
//        }

//        public Course Find(int key)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Course> FindAll()
//        {
//            List<Course> courses = new List<Course>()
//            {
//                new Course("PHP leren programmeren", "CNETIN", 5),
//                new Course("Java leren programmeren", "CNETIN", 5)
//            };

//            return courses;
//        }

//        public IEnumerable<Course> FindBy(Expression<Func<Course, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public IEnumerable<Course> FindByWeek(int week, int year)
//        {
//            throw new NotImplementedException();
//        }

//        public Course FindOneBy(Expression<Func<Course, bool>> filter)
//        {
//            throw new NotImplementedException();
//        }

//        public void Insert(Course item)
//        {
//            InsertParameter = item;
//            _count++;
//        }

//        public void InsertRange(IEnumerable<Course> entities)
//        {
//            InsertRangeParameter = entities;
//            _count += entities.Count();
//        }

//        public void Update(Course item)
//        {
//            throw new NotImplementedException();
//        }
//    }
//}