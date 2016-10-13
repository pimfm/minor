using System;
using System.Globalization;

namespace FrontEnd.Services
{
    public class DateScheduler : IDateScheduler
    {
        private DateTimeFormatInfo _format;
        private Calendar _calendar;

        public DateScheduler()
        {
            _format = new DateTimeFormatInfo();
            _format.CalendarWeekRule = CalendarWeekRule.FirstFullWeek;
            _format.FirstDayOfWeek = DayOfWeek.Monday;

            _calendar = _format.Calendar;
        }

        public int Week(DateTime date)
        {
            return _calendar.GetWeekOfYear(date, _format.CalendarWeekRule, _format.FirstDayOfWeek);
        }

        public int Year(DateTime date)
        {
            return _calendar.GetWeekOfYear(date, _format.CalendarWeekRule, _format.FirstDayOfWeek);
        }

        public bool CanScheduleEvent(DateTime startDate, int durationInDays, DateTime? from = null, DateTime? to = null)
        {
            DateTime endDate = startDate.AddDays(durationInDays);

            if (from == null && to == null)
            {
                return true;
            }
            else if (from == null)
            {
                return startDate <= to || endDate < to;
            }
            else if (to == null)
            {
                return from <= startDate || from < endDate;
            }

            bool startDateInRange = startDate >= from && startDate <= to;
            bool endDateInRange = endDate > from && endDate < to;
            bool fromAndToBetweenRange = startDate <= from && endDate > to;

            return startDateInRange || endDateInRange || fromAndToBetweenRange;
        }

        public bool IsInWeek(DateTime date, int week, int year)
        {
            int courseWeek = _calendar.GetWeekOfYear(date, _format.CalendarWeekRule, _format.FirstDayOfWeek);
            int courseYear = _calendar.GetYear(date);

            return courseWeek == week && courseYear == year;
        }
    }
}
