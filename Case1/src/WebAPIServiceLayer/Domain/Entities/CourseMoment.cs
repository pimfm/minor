using System;
using WebAPIServiceLayer.Domain.Entities;

namespace Domain.Entities
{
    public class CourseMoment
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
    }
}