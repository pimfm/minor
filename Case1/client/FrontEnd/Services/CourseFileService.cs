using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Frontend.Agents.Models;
using System.IO;
using System;
using FrontEnd.Factories;
using Services;
using Exceptions;
using Frontend.Exceptions;

namespace FrontEnd.Services
{
    public class CourseFileService : IFileService<CourseMoment>
    {
        private ICourseMomentFactory _factory;
        private ICourseValidator _validator;
        private IDateScheduler _scheduler;

        public CourseFileService(ICourseMomentFactory factory, ICourseValidator validator, IDateScheduler scheduler)
        {
            _factory = factory;
            _validator = validator;
            _scheduler = scheduler;
        }

        public IList<CourseMoment> ExtractCoursesFromFile(IFormFile file, DateTime? from, DateTime? to)
        {
            int lineNumber = 1;
            List<CourseMoment> courseMoments = new List<CourseMoment>();

            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                while(reader.Peek() > 0)
                {
                    try
                    {
                        CourseMoment courseMoment = ValidateBlock(reader);
                        lineNumber += 5;

                        DateTime startDate = (DateTime) courseMoment.StartDate;
                        int duration = (int) courseMoment.Course.DurationInDays;

                        if (_scheduler.CanScheduleEvent(startDate, duration, from, to))
                        {
                            courseMoments.Add(courseMoment);
                        }
                    } catch (PatternDidNotMatchException exception)
                    {
                        throw new InvalidLineException($"Incorrecte waarde gevonden tussen regel {lineNumber} en {lineNumber + 5}: {exception.Line}", file.FileName);
                    }
                }
            }

            return courseMoments;
        }

        private CourseMoment ValidateBlock(StreamReader reader)
        {
            string title = _validator.ValidateTitle(reader.ReadLine());
            string code = _validator.ValidateCode(reader.ReadLine());
            int days = _validator.ValidateDuration(reader.ReadLine());
            DateTime startDate = _validator.ValidateStartDate(reader.ReadLine());
            _validator.ValidateEmptyLine(reader.ReadLine());

            return _factory.Manufacture(title, code, days, startDate);
        }
    }
}
