
using System;

namespace FrontEnd.Services
{
    public interface IDateScheduler
    {
        int Week(DateTime date);
        int Year(DateTime date);
        bool IsInWeek(DateTime date, int week, int year);
        bool CanScheduleEvent(DateTime startDate, int durationInDays, DateTime? from = null, DateTime? to = null);
    }
}
