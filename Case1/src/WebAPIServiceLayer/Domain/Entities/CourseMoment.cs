using System;
using WebAPIServiceLayer.Domain.Entities;

namespace Domain.Entities
{
    public class CourseMoment
    {
        public int ID { get; set; }
        
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required for entity framework,
        /// Use the parameterized constructor,
        /// when creating entities yourself
        /// </summary>
        public CourseMoment()
        {

        }

        public CourseMoment(DateTime startDate)
        {
            StartDate = startDate;
        }
    }
}