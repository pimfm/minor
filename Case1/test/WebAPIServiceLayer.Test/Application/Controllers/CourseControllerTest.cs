using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using BackendService.Application.Controllers;
using BackendService.Domain.Entities;
using BackendService.Domain.Contracts;
using BackendService.Test.Infrastructure.Repositories.Mocks;

namespace BackendService.Test.Application.Controllers
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
                new Course("C# leren programmeren"),
                new Course("Whitespace leren programmeren"),
                new Course("Golang leren programmeren"),
                new Course("Brainfuck leren programmeren"),
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
            Assert.AreEqual("No courses provided, please check if your file contains courses", report);
        }

        [TestMethod]
        public void AddRangeAllInserted()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course("C# leren programmeren"),
                new Course("Golang leren programmeren"),
            };

            // Act
            string report = controller.AddRange(courses);

            // Assert
            Assert.AreEqual(2, repository.Count());
            Assert.AreEqual("All 2 courses were newly inserted, no duplicated!", report);
        }

        [TestMethod]
        public void AddRangeAllDuplicates()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course("PHP leren programmeren"),
                new Course("Java leren programmeren"),
            };

            // Act
            string report = controller.AddRange(courses);

            // Assert
            Assert.AreEqual(0, repository.Count());
            Assert.AreEqual("All 2 courses were duplicates, no new courses inserted.", report);
        }

        [TestMethod]
        public void AddRangeSomeInsertedSomeDuplicates()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);
            IEnumerable<Course> courses = new List<Course>()
            {
                new Course("PHP leren programmeren"),
                new Course("Golang leren programmeren"),
                new Course("Java leren programmeren"),
                new Course("C# leren programmeren"),
            };

            // Act
            string report = controller.AddRange(courses);

            // Assert
            Assert.AreEqual(2, repository.Count());
            Assert.AreEqual("2 courses inserted! 2 not inserted, due to duplication.", report);
        }
    }
}
