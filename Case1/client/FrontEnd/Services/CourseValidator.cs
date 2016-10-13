using System;
using Services;
using System.Text.RegularExpressions;
using Exceptions;
using Frontend.Agents.Models;

namespace FrontEnd.Services
{
    public class CourseValidator : ICourseValidator
    {
        public string ValidateTitle(string line)
        {
            Regex pattern = new Regex(@"^Titel: ?(.{1,300})$");

            BaseValidate(line, pattern); 

            return pattern.Match(line).Groups[1].Value;
        }

        public string ValidateCode(string line)
        {
            Regex pattern = new Regex(@"^Cursuscode: ?([A-Z]{1,10})$");

            BaseValidate(line, pattern);

            return pattern.Match(line).Groups[1].Value;
        }

        public int ValidateDuration(string line)
        {
            Regex pattern = new Regex(@"^Duur: ?(\d+) ?dagen$");

            BaseValidate(line, pattern);

            string match = pattern.Match(line).Groups[1].Value;

            return int.Parse(match);
        }

        public DateTime ValidateStartDate(string line)
        {
            Regex pattern = new Regex(@"^Startdatum: ?(\d{2})\/(\d{2})\/(\d{4})$");

            BaseValidate(line, pattern);

            int day = int.Parse(pattern.Match(line).Groups[1].Value);
            int month = int.Parse(pattern.Match(line).Groups[2].Value);
            int year = int.Parse(pattern.Match(line).Groups[3].Value);

            return new DateTime(year, month, day);
        }

        public string ValidateEmptyLine(string line)
        {
            Regex pattern = new Regex(@"^(\s*)$");

            BaseValidate(line, pattern);

            return pattern.Match(line).Groups[1].Value;
        }

        private void BaseValidate(string line, Regex pattern)
        {
            if (pattern.IsMatch(line) == false)
            {
                throw new PatternDidNotMatchException(pattern, line);
            };
        }
    }
}