using System;

namespace WebAPIServiceLayer.Domain.Entities
{
    public class CourseMoment : IEquatable<CourseMoment>
    {
        public int ID { get; set; }
        public int CourseID { get; set; }
        public virtual Course Course { get; set; }
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required for entity framework,
        /// Use the parameterized constructor,
        /// when creating entities yourself
        /// </summary>
        public CourseMoment()
        {

        }

        public CourseMoment(Course course, DateTime startDate)
        {
            Course = course;
            StartDate = startDate;
        }

        public bool Equals(CourseMoment other)
        {
            if (Course.Equals(other.Course) == false)
            {
                return false;
            }

            return StartDate == other.StartDate;
        }

        public override int GetHashCode()
        {
            return Course.GetHashCode() ^ StartDate.GetHashCode();
        }
    }
}