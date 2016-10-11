using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using FrontEnd.Services;
using Frontend.Agents.Models;
using Frontend.Exceptions;

namespace Frontend.Controllers
{
    [Route("cursussen/overzicht")]
    public class CourseOverviewController : Controller
    {
        private ICourseAgent _agent;
        private IFileService<Course> _service;

        public CourseOverviewController(ICourseAgent agent, IFileService<Course> courseFileService)
        {
            _agent = agent;
            _service = courseFileService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View(_agent.FindAllCourses());
        }
    }
}