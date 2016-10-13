using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPIServiceLayer.Application.Controllers;
using WebAPIServiceLayer.Domain.Contracts;
using WebAPIServiceLayer.Domain.Entities;
using WebAPIServiceLayer.Test.Infrastructure.Repositories.Mocks;

namespace WebAPIServiceLayer.Test.Application.Controllers
{
    [TestClass]
    public class CourseControllerTest
    {
        [TestMethod]
        public void FindAll()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);

            // Act
            IEnumerable<CourseMoment> courses = controller.FindAll();

            // Arrange
            Assert.IsTrue(repository.FindAllIsCalled);
        }

        [TestMethod]
        public void FindInWeek()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);

            // Act
            IEnumerable<CourseMoment> courses = controller.FindInWeek(11, 2016);

            // Arrange
            Assert.IsTrue(repository.FindByWeekIsCalled);
            Assert.AreEqual(11, repository.FindByWeekParameterWeek);
            Assert.AreEqual(2016, repository.FindByWeekParameterYear);
        }

        [TestMethod]
        public void AddMultipleCourseMoments()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);

            // Act
            List<CourseMoment> moments = new List<CourseMoment>()
            {
                new CourseMoment(new Course("", "", 0), DateTime.Now)
            };
            UploadReport report = controller.AddMultipleCourseMoments(moments);

            // Arrange
            Assert.IsTrue(repository.InsertRangeIsCalled);
        }

        [TestMethod]
        public void AddMultipleCourseMomentsNoNewCourseMoments()
        {
            // Arrange
            CourseRepositoryMock repository = new CourseRepositoryMock();
            CoursesController controller = new CoursesController(repository);

            // Act
            UploadReport report = controller.AddMultipleCourseMoments(new List<CourseMoment>());

            // Arrange
            Assert.IsFalse(repository.InsertRangeIsCalled);
        }
    }
}
