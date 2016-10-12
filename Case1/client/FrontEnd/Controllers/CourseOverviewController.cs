using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using System;
using System.Globalization;

namespace Frontend.Controllers
{
    [Route("cursussen")]
    public class CourseOverviewController : Controller
    {
        private ICourseAgent _agent;
        private DateTimeFormatInfo _info;

        public CourseOverviewController(ICourseAgent agent)
        {
            _agent = agent;

            _info = new DateTimeFormatInfo();
            _info.FirstDayOfWeek = DayOfWeek.Monday;
        }

        [HttpGet]
        public ActionResult Index()
        {
            DateTime now = DateTime.Now;
            
            Calendar calendar = _info.Calendar;

            int week = calendar.GetWeekOfYear(now, _info.CalendarWeekRule, _info.FirstDayOfWeek);
            int year = calendar.GetYear(now);

            return RedirectToAction("Week", "CourseOverview", new { week = week, year = year });
        }

        [HttpGet("week/{week}/jaar/{year}")]
        public ViewResult Week(int week, int year)
        {
            return View(_agent.FindInWeek(week, year));
        }
    }
}