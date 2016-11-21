using FrontEnd.Agents.CourseAgent;
using System.Collections.Generic;
using Frontend.Agents.Models;
using System;

namespace FrontEnd.Test.Mocks
{
    public class CourseAgentMock : ICourseAgent
    {
        public bool FindAllCalled { get; private set; }
        public bool FindInWeekCalled { get; private set; }
        public int FindParameterWeek { get; private set; }
        public int FindParameterYear { get; private set; }
        public bool UploadCalled { get; private set; }
        public IList<CourseMoment> UploadParameter { get; private set; }

        public IEnumerable<CourseMoment> FindAll()
        {
            FindAllCalled = true;

            return null;
        }

        public IEnumerable<CourseMoment> FindInWeek(int week, int year)
        {
            FindInWeekCalled = true;
            FindParameterWeek = week;
            FindParameterYear = year;

            return null;
        }

        public UploadReport Upload(IList<CourseMoment> courseMoments)
        {
            UploadCalled = true;
            UploadParameter = courseMoments;

            return null;
        }
    }
}
