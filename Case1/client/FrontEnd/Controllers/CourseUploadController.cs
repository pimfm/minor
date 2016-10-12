using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using FrontEnd.Services;
using Frontend.Agents.Models;
using Frontend.Exceptions;
using System;
using FrontEnd.ViewModel;

namespace Frontend.Controllers
{
    [Route("importeren")]
    public class CourseUploadController : Controller
    {
        private ICourseAgent _agent;
        private IFileService<CourseMoment> _service;

        public CourseUploadController(ICourseAgent agent, IFileService<CourseMoment> courseFileService)
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
            List<UploadReportViewModel> reports = new List<UploadReportViewModel>();

            foreach (IFormFile file in files)
            {
                try
                {
                    IList<CourseMoment> courses = _service.ReadFile(file, from, to);
                    UploadReport report = _agent.Upload(courses);
                    UploadReportViewModel reportViewModel = UploadReportViewModel.fromUploadReport(file.FileName, report);

                    reports.Add(reportViewModel);
                } catch (InvalidLineException exception)
                {
                    UploadReportViewModel reportViewModel = UploadReportViewModel.fromException(file.FileName, exception);

                    reports.Add(reportViewModel);
                }
            }

            return View("Index", reports);
        }
    }
}