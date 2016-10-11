using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using WebAPIServiceLayer.Application.Controllers;
using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Domain.Contracts;
using WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks;
using System;

namespace WebAPIServiceLayer.Test.Application.Controllers
{
    [TestClass]
    public class CourseControllerTest
    {
        [TestMethod]
        public void All()
        {
            // Arrange
            ICourseRepository repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);

            // Act
            IEnumerable<Course> courses = controller.All();

            // Assert
            Assert.AreEqual(2, courses.Count());
        }

        [TestMethod]
        public void AddRange()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course("C# leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("Whitespace leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("Golang leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("Brainfuck leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12))
            };

            // Act
            controller.AddRange(courses);

            // Assert
            Assert.AreEqual(4, repository.Count());
        }

        [TestMethod]
        public void AddRangeEmptyList()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>();

            // Act
            string report = controller.AddRange(courses);

            // Assert
            Assert.AreEqual(0, repository.Count());
            Assert.AreEqual("Dit bestand bevat geen cursussen, controleer of het goede bestand is geselecteerd.", report);
        }

        [TestMethod]
        public void AddRangeAllInserted()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course("C# leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("Golang leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
            };

            // Act
            string report = controller.AddRange(courses);

            // Assert
            Assert.AreEqual(2, repository.Count());
            Assert.AreEqual("Alle 2 cursussen zijn nieuw toegevoegd!", report);
        }

        [TestMethod]
        public void AddRangeAllDuplicates()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course("PHP leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("Java leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
            };

            // Act
            string report = controller.AddRange(courses);

            // Assert
            Assert.AreEqual(0, repository.Count());
            Assert.AreEqual("Geen nieuwe cursussen gevonden. Alle 2 cursussen waren al aanwezig. Controleer of het goede bestand is geselecteerd.", report);
        }

        [TestMethod]
        public void AddRangeSomeInsertedSomeDuplicates()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course("PHP leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("Golang leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("Java leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
                new Course("C# leren programmeren", "CNETIN", 5, new DateTime(1995, 04, 12)),
            };

            // Act
            string report = controller.AddRange(courses);

            // Assert
            Assert.AreEqual(2, repository.Count());
            Assert.AreEqual("2 cursussen toegevoegd! 2 cursussen niet toegevoegd, omdat ze al aanwezig waren.", report);
        }
    }
}
