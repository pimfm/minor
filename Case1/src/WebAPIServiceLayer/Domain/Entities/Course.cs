using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPIServiceLayer.Domain.Entities
{
    public class Course : IEquatable<Course>
    {
        public string Title { get; set; }
        [Key]
        public string Code { get; set; }
        public int DurationInDays { get; set; }

        /// <summary>
        /// Required for entity framework,
        /// Use the parameterized constructor,
        /// when creating entities yourself
        /// </summary>
        public Course()
        {
            Title = "Unknown";
        }

        public Course(string title, string code, int durationInDays)
        {
            Title = title;
            Code = code;
            DurationInDays = durationInDays;
        }

        public bool Equals(Course other)
        {
            return Title == other.Title
                && Code == other.Code
                && DurationInDays == other.DurationInDays;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode() ^ Code.GetHashCode() ^ DurationInDays.GetHashCode();
        }
    }
}