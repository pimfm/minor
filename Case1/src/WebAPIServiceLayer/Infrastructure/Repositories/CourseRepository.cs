using BackendService.Domain.Entities;
using BackendService.Domain.Contracts;
using BackendService.Infrastructure.DataAccessLayer;
using BackendService.Infrastructure.Factories;
using System.Collections.Generic;

namespace BackendService.Infrastructure.Repositories
{
    public class CourseRepository : BaseRepository<Course, CourseAdministrationDbContext>, ICourseRepository
    {
        private IManufacturesContext<CourseAdministrationDbContext> _factory;

        public CourseRepository(IManufacturesContext<CourseAdministrationDbContext> factory) : base(factory)
        {
            _factory = factory;
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
    }
}
