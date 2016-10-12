//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using System.Collections.Generic;
//using System.Linq;
//using WebAPIServiceLayer.Application.Controllers;
//using WebAPIServiceLayer.Domain.Entities;
//using WebAPIServiceLayer.Domain.Contracts;
//using WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks;
//using System;

//namespace WebAPIServiceLayer.Test.Application.Controllers
//{
//    [TestClass]
//    public class CourseControllerTest
//    {
//        [TestMethod]
//        public void All()
//        {
//            Arrange
//           ICourseRepository repository = new CourseRepositoryMock();
//            CoursesController controller = new CoursesController(repository);

//            Act
//            IEnumerable<Course> courses = controller.FindAll();

//            Assert
//            Assert.AreEqual(2, courses.Count());
//        }

//        [TestMethod]
//        public void AddRange()
//        {
//            Arrange
//           CourseRepositoryMock repository = new CourseRepositoryMock();
//            CoursesController controller = new CoursesController(repository);
//            IEnumerable<Course> courses = new List<Course>()
//            {
//                new Course("C# leren programmeren", "CNETIN", 5),
//                new Course("Whitespace leren programmeren", "CNETIN", 5),
//                new Course("Golang leren programmeren", "CNETIN", 5),
//                new Course("Brainfuck leren programmeren", "CNETIN", 5)
//            };

//            Act
//            controller.AddRange(courses);

//            Assert
//            Assert.AreEqual(4, repository.Count());
//        }

//        [TestMethod]
//        public void AddRangeEmptyList()
//        {
//            Arrange
//           CourseRepositoryMock repository = new CourseRepositoryMock();
//            CoursesController controller = new CoursesController(repository);
//            IEnumerable<Course> courses = new List<Course>();

//            Act
//           UploadReport report = controller.AddRange(courses);

//            Assert
//            Assert.AreEqual(0, repository.Count());
//        }

//        [TestMethod]
//        public void AddRangeAllInserted()
//        {
//            Arrange
//           CourseRepositoryMock repository = new CourseRepositoryMock();
//            CoursesController controller = new CoursesController(repository);
//            IEnumerable<Course> courses = new List<Course>()
//            {
//                new Course("C# leren programmeren", "CNETIN", 5),
//                new Course("Golang leren programmeren", "CNETIN", 5),
//            };

//            Act
//           UploadReport report = controller.AddRange(courses);

//            Assert
//            Assert.AreEqual(2, repository.Count());
//        }

//        [TestMethod]
//        public void AddRangeAllDuplicates()
//        {
//            Arrange
//           CourseRepositoryMock repository = new CourseRepositoryMock();
//            CoursesController controller = new CoursesController(repository);
//            IEnumerable<Course> courses = new List<Course>()
//            {
//                new Course("PHP leren programmeren", "CNETIN", 5),
//                new Course("Java leren programmeren", "CNETIN", 5),
//            };

//            Act
//           UploadReport report = controller.AddRange(courses);

//            Assert
//            Assert.AreEqual(0, repository.Count());
//        }

//        [TestMethod]
//        public void AddRangeSomeInsertedSomeDuplicates()
//        {
//            Arrange
//           CourseRepositoryMock repository = new CourseRepositoryMock();
//            CoursesController controller = new CoursesController(repository);
//            IEnumerable<Course> courses = new List<Course>()
//            {
//                new Course("PHP leren programmeren", "CNETIN", 5),
//                new Course("Golang leren programmeren", "CNETIN", 5),
//                new Course("Java leren programmeren", "CNETIN", 5),
//                new Course("C# leren programmeren", "CNETIN", 5),
//            };

//            Act
//           UploadReport report = controller.AddRange(courses);

//            Assert
//            Assert.AreEqual(2, repository.Count());
//            Assert.AreEqual("2 cursussen toegevoegd! 2 cursussen niet toegevoegd, omdat ze al aanwezig waren.", report.Message);
//        }
//    }
//}
