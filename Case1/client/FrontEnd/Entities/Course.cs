using System;

namespace Entities
{
    public class Course
    {
        public string Title { get; set; }
        public string Code { get; set; }
        public int DurationInDays { get; set; }
        public DateTime StartDate { get; set; }

        public Course(string title, string code, int durationInDays, DateTime startDate)
        {
            Title = title;
            Code = code;
            DurationInDays = durationInDays;
            StartDate = startDate;
        }
    }
}