using Frontend.Controllers;
using FrontEnd.Agents.CourseAgent;
using FrontEnd.Services;
using FrontEnd.Test.Mocks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace FrontEnd.Test.Controllers
{
    [TestClass]
    public class CourseOverviewControllerTest
    {
        [TestMethod]
        public void ItCanBeInstantiatedAsController()
        {
            // Arrange
            ICourseAgent agent = new CourseAgentMock();
            IDateScheduler scheduler = new DateScheduler();
            CourseOverviewController controller = new CourseOverviewController(agent, scheduler);

            // Assert
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }

        [TestMethod]
        public void WeekActionReturnsAViewResult()
        {
            // Arrange
            ICourseAgent agent = new CourseAgentMock();
            IDateScheduler scheduler = new DateScheduler();
            CourseOverviewController controller = new CourseOverviewController(agent, scheduler);

            // Act
            ViewResult response = controller.Week(10, 2016);

            // Assert
            Assert.IsInstanceOfType(response, typeof(ViewResult));
        }

        [TestMethod]
        public void WeekActionUsesTheAgentToFindCourseMomentsInWeek()
        {
            // Arrange
            CourseAgentMock agent = new CourseAgentMock();
            IDateScheduler scheduler = new DateScheduler();
            CourseOverviewController controller = new CourseOverviewController(agent, scheduler);

            // Act
            controller.Week(10, 2016);

            // Assert
            Assert.IsTrue(agent.FindInWeekCalled);
            Assert.AreEqual(10, agent.FindParameterWeek);
            Assert.AreEqual(2016, agent.FindParameterYear);
        }

        [TestMethod]
        public void TooHighWeekNumberWillResetWeek()
        {
            // Arrange
            CourseAgentMock agent = new CourseAgentMock();
            IDateScheduler scheduler = new DateScheduler();
            CourseOverviewController controller = new CourseOverviewController(agent, scheduler);

            // Act
            controller.Week(70, 2016);

            // Assert
            Assert.IsTrue(agent.FindInWeekCalled);
            Assert.AreEqual(1, agent.FindParameterWeek);
            Assert.AreEqual(2016, agent.FindParameterYear);
        }

        [TestMethod]
        public void TooLowWeekNumberWillResetWeek()
        {
            // Arrange
            CourseAgentMock agent = new CourseAgentMock();
            IDateScheduler scheduler = new DateScheduler();
            CourseOverviewController controller = new CourseOverviewController(agent, scheduler);

            // Act
            controller.Week(-2, 2016);

            // Assert
            Assert.IsTrue(agent.FindInWeekCalled);
            Assert.AreEqual(1, agent.FindParameterWeek);
            Assert.AreEqual(2016, agent.FindParameterYear);
        }

        [TestMethod]
        public void IndexRedirectsToTheWeekAction()
        {
            // Arrange
            CourseAgentMock agent = new CourseAgentMock();
            IDateScheduler scheduler = new DateScheduler();
            CourseOverviewController controller = new CourseOverviewController(agent, scheduler);
            DateTime now = DateTime.Now;

            // Act
            RedirectToActionResult response = controller.Index();
            int week = scheduler.Week(now);
            int year = scheduler.Year(now);

            // Assert
            Assert.IsInstanceOfType(response, typeof(RedirectToActionResult));
            Assert.AreEqual(week, response.RouteValues["week"]);
            Assert.AreEqual(year, response.RouteValues["year"]);
        }
    }
}
