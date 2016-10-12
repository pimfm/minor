using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Frontend.Agents.Models;
using System.IO;
using System.Text.RegularExpressions;
using Frontend.Exceptions;
using System.Linq;
using System;
using FrontEnd.Factories;

namespace FrontEnd.Services
{
    public class CourseFileService : IFileService<Course>
    {
        private int _lineNumber;
        private CourseFactory _factory = new CourseFactory();
        
        private bool DateInRange(DateTime startDate, DateTime endDate, DateTime? from, DateTime? to)
        {
            if (from == null && to == null)
            {
                return true;
            } else if (from == null)
            {
                return startDate < to || endDate < to;
            } else if (to == null)
            {
                return startDate >= from || endDate >= from;
            }

            bool startDateInRange = startDate >= from && startDate < to;
            bool endDateInRange = endDate >= from && endDate < to;

            return startDateInRange || endDateInRange;
        }

        public IList<Course> ReadFile(IFormFile file, DateTime? from, DateTime? to)
        {
            _lineNumber = 0;
            List<Course> courses = new List<Course>();

            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                while(reader.Peek() > 0)
                {
                    string title = ValidateTitle(reader.ReadLine());
                    string code = ValidateCode(reader.ReadLine());
                    int days = ValidateDays(reader.ReadLine());
                    DateTime startDate = ValidateStartDate(reader.ReadLine());

                    BaseValidate(reader.ReadLine(), new Regex(@"^\s*$"), "Plaats een witregel na elke cursus");

                    if (DateInRange(startDate, startDate.AddDays(days), from, to))
                    {
                        Course course = _factory.MakeCourse(title, code, days, startDate);

                        courses.Add(course);
                    }
                }
            }

            return courses;
        }
        private string ValidateTitle(string line)
        {
            Regex pattern = new Regex(@"^Titel: (.+)$");
            string example = "Titel: C# leren programmeren";

            BaseValidate(line, pattern, example);

            return pattern.Match(line).Groups[1].Value;
        }

        private string ValidateCode(string line)
        {
            Regex pattern = new Regex(@"^Cursuscode: ([A-Z]+)$");
            string example = "Cursuscode: CNETIN";

            BaseValidate(line, pattern, example);

            return pattern.Match(line).Groups[1].Value;
        }

        private int ValidateDays(string line)
        {
            Regex pattern = new Regex(@"^Duur: (\d+) dagen$");
            string example = "Duur: 5 dagen";

            BaseValidate(line, pattern, example);

            string match = pattern.Match(line).Groups[1].Value;

            return int.Parse(match);
        }

        private DateTime ValidateStartDate(string line)
        {
            Regex pattern = new Regex(@"^Startdatum: (\d{2})\/(\d{2})\/(\d{4})$");
            string example = "Startdatum: 20/10/2014";

            BaseValidate(line, pattern, example);

            int day = int.Parse(pattern.Match(line).Groups[1].Value);
            int month = int.Parse(pattern.Match(line).Groups[2].Value);
            int year = int.Parse(pattern.Match(line).Groups[3].Value);

            return new DateTime(year, month, day);
        }

        /// <exception cref="InvalidLineException"></exception>
        /// <returns></returns>
        private void BaseValidate(string line, Regex pattern, string correctExample)
        {
            _lineNumber++;

            if (pattern.IsMatch(line) == false)
            {
                throw new InvalidLineException($"De waarde op regel {_lineNumber} is niet valide. Gevonden waarde: {line}, probeer de regel op dit voorbeeld te laten lijken: {correctExample}.");
            };
        }
    }
}
