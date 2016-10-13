using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using System;
using System.Globalization;
using FrontEnd.Services;

namespace Frontend.Controllers
{
    [Route("cursussen")]
    public class CourseOverviewController : Controller
    {
        private ICourseAgent _agent;
        private IDateScheduler _scheduler;

        public CourseOverviewController(ICourseAgent agent, IDateScheduler scheduler)
        {
            _agent = agent;
            _scheduler = scheduler;
        }

        [HttpGet]
        public RedirectToActionResult Index()
        {
            DateTime now = DateTime.Now;

            var routeParameters = new {
                week = _scheduler.Week(now),
                year = _scheduler.Year(now)
            };

            return RedirectToAction("Week", "CourseOverview", routeParameters);
        }

        [HttpGet("week/{week}/jaar/{year}")]
        public ViewResult Week(int week, int year)
        {
            if (week > 52 || week < 1)
            {
                week = 1;
            }

            return View(_agent.FindInWeek(week, year));
        }
    }
}