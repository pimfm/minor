using Domain.Entities;
using System;
using System.Collections.Generic;

namespace WebAPIServiceLayer.Domain.Entities
{
    public class Course : IEquatable<Course>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DurationInDays { get; set; }

        public virtual ICollection<CourseMoment> Moments { get; set; }

        /// <summary>
        /// Required for entity framework,
        /// Use the parameterized constructor,
        /// when creating entities yourself
        /// </summary>
        public Course()
        {
            Title = "Unknown";
            Moments = new List<CourseMoment>();
        }

        public Course(string title, string code, int durationInDays)
        {
            Title = title;
            Code = code;
            DurationInDays = durationInDays;
            Moments = new List<CourseMoment>();
        }

        public void AddMoment(DateTime startDate)
        {
            Moments.Add(new CourseMoment(this, startDate));
        }

        public bool Equals(Course other)
        {
            return Title == other.Title
                && Code == other.Code
                && DurationInDays == other.DurationInDays;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() | Code.GetHashCode() | DurationInDays.GetHashCode();
        }
    }
}