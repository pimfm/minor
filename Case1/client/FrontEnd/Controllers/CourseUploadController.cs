using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using FrontEnd.Services;
using Frontend.Agents.Models;
using Frontend.Exceptions;

namespace Frontend.Controllers
{
    [Route("cursussen/importeren")]
    public class CourseUploadController : Controller
    {
        private ICourseAgent _agent;
        private IFileService<Course> _service;

        public CourseUploadController(ICourseAgent agent, IFileService<Course> courseFileService)
        {
            _agent = agent;
            _service = courseFileService;
        }

        [HttpGet]
        public ViewResult Index()
        {
            return View();
        }

        [HttpPost]
        public ViewResult Upload(ICollection<IFormFile> files)
        {
            List<Course> uploadedCourses = new List<Course>();

            foreach (IFormFile file in files)
            {
                try
                {
                    _service.Validate(file);
                } catch (InvalidLineException exception)
                {
                    return View("Index", $"Fout gevonden in {file.FileName}. {exception.Message}");
                }

                IEnumerable<Course> courses = _service.Produce();

                uploadedCourses.AddRange(courses);
            }

            if (uploadedCourses.Count == 0)
            {
                return View("Index", $"Er zijn geen cursussen gevonden in de geimporteerde bestanden. Probeer een ander bestand.");
            }

            string message = _agent.SaveCourses(uploadedCourses);

            return View("Index", message);
        }
    }
}