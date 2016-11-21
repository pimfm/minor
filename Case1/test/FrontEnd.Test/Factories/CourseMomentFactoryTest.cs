using Frontend.Agents.Models;
using FrontEnd.Factories;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrontEnd.Test.Factories
{
    [TestClass]
    public class CourseMomentFactoryTest
    {
        [TestMethod]
        public void IsInstanceOfICourseMomentFactory()
        {
            // Arrange
            ICourseMomentFactory factory = new CourseMomentFactory();

            // Assert
            Assert.IsInstanceOfType(factory, typeof(ICourseMomentFactory));
        }

        [TestMethod]
        public void CanMakeACourse()
        {
            // Arrange
            ICourseMomentFactory factory = new CourseMomentFactory();
            string title = "C# programmeren";
            string code = "CODE";
            int duration = 5;

            // Act
            Course course = factory.Manufacture(title, code, duration);

            // Assert
            Assert.AreEqual(title, course.Title);
            Assert.AreEqual(code, course.Code);
            Assert.AreEqual(duration, course.DurationInDays);
        }

        [TestMethod]
        public void CanMakeACourseMoment()
        {
            // Arrange
            ICourseMomentFactory factory = new CourseMomentFactory();
            string title = "C# programmeren";
            string code = "CODE";
            int duration = 5;
            DateTime startDate = DateTime.Now;

            // Act
            CourseMoment courseMoment = factory.Manufacture(title, code, duration, startDate);

            // Assert
            Assert.AreEqual(title, courseMoment.Course.Title);
            Assert.AreEqual(code, courseMoment.Course.Code);
            Assert.AreEqual(duration, courseMoment.Course.DurationInDays);
            Assert.AreEqual(startDate, courseMoment.StartDate);
        }
    }
}
