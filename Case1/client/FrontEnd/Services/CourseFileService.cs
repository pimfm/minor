using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using Frontend.Agents.Models;
using System.IO;
using System.Text.RegularExpressions;
using Frontend.Exceptions;
using System.Linq;

namespace FrontEnd.Services
{
    public class CourseFileService : IFileService<Course>
    {
        private List<Course> _courses;
        private int _lineNumber = 0;

        private Regex _titlePattern;
        private Regex _codePattern;
        private Regex _daysPattern;
        private Regex _startDatePattern;

        private string _titleExample;
        private string _codeExample;
        private string _daysExample;
        private string _startDateExample;
        private Regex _whiteSpacePattern;
        private string _whiteSpaceExample;

        public CourseFileService()
        {
            _courses = new List<Course>();

            _titlePattern = new Regex(@"^Titel: (.+)$");
            _codePattern = new Regex(@"^Cursuscode: ([A-Z]+)$");
            _daysPattern = new Regex(@"^Duur: (\d+) dagen$");
            _startDatePattern = new Regex(@"^Startdatum: (\d{2}\/\d{2}\/\d{4})$");
            _whiteSpacePattern = new Regex(@"^\s*$");

            _titleExample = "Titel: C# leren programmeren";
            _codeExample = "Cursuscode: CNETIN";
            _daysExample = "Duur: 5 dagen";
            _startDateExample = "Startdatum: 20/10/2014";
            _whiteSpaceExample = "Plaat een witregel na elke cursus";
        }
        
        public IEnumerable<Course> Produce()
        {
            return _courses;
        }

        public void Validate(IFormFile file)
        {
            _lineNumber = 0;
            _courses = new List<Course>();

            using (StreamReader reader = new StreamReader(file.OpenReadStream()))
            {
                while(reader.Peek() > 0)
                {
                    string title = Validate(reader.ReadLine(), _titlePattern, _titleExample);
                    string code = Validate(reader.ReadLine(), _codePattern, _codeExample);
                    string days = Validate(reader.ReadLine(), _daysPattern, _daysExample);
                    string startDate = Validate(reader.ReadLine(), _startDatePattern, _startDateExample);

                    Validate(reader.ReadLine(), _whiteSpacePattern, _whiteSpaceExample);

                    Course course = new Course(null, title, code, days, startDate);

                    _courses.Add(course);
                }
            }
        }

        /// <exception cref="InvalidLineException"></exception>
        /// <returns></returns>
        private string Validate(string line, Regex pattern, string correctExample)
        {
            _lineNumber++;

            if (pattern.IsMatch(line) == false)
            {
                throw new InvalidLineException($"De waarde op regel {_lineNumber} is niet valide. Gevonden waarde: {line}, probeer de regel op dit voorbeeld te laten lijken: {correctExample}.");
            }

            string match = pattern.Match(line).Groups[0].Value;

            return match;
        }
    }
}
