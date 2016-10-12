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

        public CourseFileService(ICourseMomentFactory factory, ICourseValidator validator)
        {
            _factory = factory;
            _validator = validator;
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

                        if (MomentInRange(courseMoment, from, to) == true)
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

        private bool MomentInRange(CourseMoment courseMoment, DateTime? from, DateTime? to)
        {
            DateTime startDate = (DateTime) courseMoment.StartDate;
            int days = (int) courseMoment.Course.DurationInDays;

            return _validator.ValidateDateInRange(startDate, startDate.AddDays(days), from, to);
        }

        private CourseMoment ValidateBlock(StreamReader reader)
        {
            string title = _validator.ValidateTitle(reader.ReadLine());
            string code = _validator.ValidateCode(reader.ReadLine());
            int days = _validator.ValidateDuration(reader.ReadLine());
            DateTime startDate = _validator.ValidateStartDate(reader.ReadLine());
            _validator.ValidateEmptyLine(reader.ReadLine());

            return _factory.MakeCourseMoment(title, code, days, startDate);
        }
    }
}
