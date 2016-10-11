using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using FrontEnd.Services;
using Frontend.Agents.Models;
using Frontend.Exceptions;
using System;

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
        public ViewResult Upload(ICollection<IFormFile> files, DateTime? from = null, DateTime? to = null)
        {
            List<UploadReport> reports = new List<UploadReport>();

            foreach (IFormFile file in files)
            {
                try
                {
                    _service.Validate(file);
                    List<Course> courses = (List<Course>)_service.Produce(from, to);
                    UploadReport report = _agent.SaveCourses(courses);

                    report.FileName = file.FileName;
                    reports.Add(report);
                } catch (InvalidLineException exception)
                {
                    UploadReport errorReport = new UploadReport("danger", exception.Message, file.FileName);
                    reports.Add(errorReport);
                }
            }

            return View("Index", reports);
        }
    }
}