using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using FrontEnd.Services;
using Frontend.Agents.Models;

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