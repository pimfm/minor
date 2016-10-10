using BackendService.Domain.Entities;
using System.Collections.Generic;
using System;

namespace BackendService.Domain.Comparer
{
    public class CourseComparer : IEqualityComparer<Course>
    {
        public bool Equals(Course course, Course other)
        {
            return course.Equals(other);
        }

        public int GetHashCode(Course course)
        {
            return course.GetHashCode();
        }
    }
}
