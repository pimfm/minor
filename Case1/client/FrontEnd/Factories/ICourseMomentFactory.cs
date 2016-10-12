using Frontend.Agents.Models;
using System;

namespace FrontEnd.Factories
{
    public interface ICourseMomentFactory
    {
        CourseMoment MakeCourseMoment(string title, string code, int duration, DateTime startDate);
    }
}