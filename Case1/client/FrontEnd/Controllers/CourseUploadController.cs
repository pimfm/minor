using Microsoft.AspNetCore.Mvc;
using FrontEnd.Agents.CourseAgent;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using FrontEnd.Services;
using Frontend.Agents.Models;
using Frontend.Exceptions;
using System;
using System.Linq;
using FrontEnd.ViewModel;

namespace Frontend.Controllers
{
    [Route("importeren")]
    public class CourseUploadController : Controller
    {
        private ICourseAgent _agent;
        private IFileService<CourseMoment> _service;

        public CourseUploadController(ICourseAgent agent, IFileService<CourseMoment> fileService)
        {
            _agent = agent;
            _service = fileService;
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
                    IList<CourseMoment> extractedCourses = _service.ExtractCoursesFromFile(file, from, to);

                    UploadReport report = _agent.Upload(extractedCourses);
                    report.FileName = file.FileName;
                    UploadReportViewModel reportViewModel = UploadReportViewModel.fromUploadReport(report);

                    reports.Add(reportViewModel);
                } catch (InvalidLineException exception)
                {
                    UploadReportViewModel reportViewModel = UploadReportViewModel.fromException(exception);

                    reports.Add(reportViewModel);
                }
            }

            return View("Index", reports);
        }
    }
}