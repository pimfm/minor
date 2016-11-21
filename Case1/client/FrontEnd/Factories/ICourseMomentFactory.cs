using Frontend.Agents.Models;
using System;

namespace FrontEnd.Factories
{
    public interface ICourseMomentFactory
    {
        Course Manufacture(string title, string code, int duration);
        CourseMoment Manufacture(string title, string code, int duration, DateTime startDate);
    }
}