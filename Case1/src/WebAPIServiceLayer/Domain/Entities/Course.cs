using System;

namespace BackendService.Domain.Entities
{
    public class Course : IEquatable<Course>
    {
        public int ID { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Required for entity framework,
        /// Use the parameterized constructor,
        /// when creating entities yourself
        /// </summary>
        public Course()
        {
            Title = "Unknown";
        }

        public Course(string title)
        {
            Title = title;
        }

        public bool Equals(Course other)
        {
            return Title == other.Title;
        }

        public override int GetHashCode()
        {
            return Title.GetHashCode();
        }
    }
}