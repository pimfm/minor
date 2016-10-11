using System;

namespace WebAPIServiceLayer.Domain.Entities
{
    public class Course : IEquatable<Course>
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string DurationInDays { get; set; }
        public string Date { get; set; }

        /// <summary>
        /// Required for entity framework,
        /// Use the parameterized constructor,
        /// when creating entities yourself
        /// </summary>
        public Course()
        {
            Title = "Unknown";
        }

        public Course(string title, string code, string durationInDays, string date)
        {
            Title = title;
            Code = code;
            DurationInDays = durationInDays;
            Date = date;
        }

        public bool Equals(Course other)
        {
            return Title == other.Title
                && Code == other.Code
                && DurationInDays == other.DurationInDays
                && Date == other.Date;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() | Code.GetHashCode() | DurationInDays.GetHashCode() | Date.GetHashCode();
        }
    }
}