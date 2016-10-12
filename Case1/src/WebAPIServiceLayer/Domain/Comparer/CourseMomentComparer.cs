using WebAPIServiceLayer.Domain.Entities;
using System.Collections.Generic;
using System;

namespace WebAPIServiceLayer.Domain.Comparer
{
    public class CourseMomentComparer : IEqualityComparer<CourseMoment>
    {
        public bool Equals(CourseMoment courseMoment, CourseMoment other)
        {
            return courseMoment.Equals(other);
        }

        public int GetHashCode(CourseMoment obj)
        {
            return obj.GetHashCode();
        }
    }
}
