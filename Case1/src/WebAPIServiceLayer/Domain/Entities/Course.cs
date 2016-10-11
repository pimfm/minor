using System;

namespace WebAPIServiceLayer.Domain.Entities
{
    public class Course : IEquatable<Course>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Required for entity framework,
        /// Use the parameterized constructor,
        /// when creating entities yourself
        /// </summary>
        public Course()
        {
            Title = "Unknown";
        }

        public Course(string title, string code, int durationInDays, DateTime startDate)
        {
            Title = title;
            Code = code;
            DurationInDays = durationInDays;
            StartDate = startDate;
        }

        public bool Equals(Course other)
        {
            return Title == other.Title
                && Code == other.Code
                && DurationInDays == other.DurationInDays
                && StartDate == other.StartDate;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() | Code.GetHashCode() | DurationInDays.GetHashCode() | StartDate.GetHashCode();
        }
    }
}