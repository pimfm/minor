
using FrontEnd.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Globalization;

namespace FrontEnd.Test.Services
{
    [TestClass]
    public class SchedulerTest
    {
        private Calendar _calendar;
        private DateTimeFormatInfo _format;

        [TestInitialize]
        public void Initialize()
        {
            _format = new DateTimeFormatInfo();
            _calendar = _format.Calendar;
            _format.CalendarWeekRule = CalendarWeekRule.FirstFullWeek;
            _format.FirstDayOfWeek = DayOfWeek.Monday;
        }

        [TestMethod]
        public void InstanceOfIDateScheduler()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();

            // Assert
            Assert.IsInstanceOfType(scheduler, typeof(IDateScheduler));
        }

        [TestMethod]
        public void WeekOfNowGivesCorrectWeekNumber()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime now = DateTime.Now;
            int expectedWeek = _calendar.GetWeekOfYear(now, _format.CalendarWeekRule, _format.FirstDayOfWeek);

            // Act
            int actualWeek = scheduler.Week(now);

            // Assert
            Assert.AreEqual(expectedWeek, actualWeek);
        }

        [TestMethod]
        public void YearOfNowGivesCorrectWeekNumber()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime now = DateTime.Now;
            int expectedYear = _calendar.GetYear(now);

            // Act
            int actualYear = scheduler.Year(now);

            // Assert
            Assert.AreEqual(expectedYear, actualYear);
        }

        [TestMethod]
        public void CanScheduleAnyDateWithoutFromAndTo()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void StartDateAfterFrom()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime from = DateTime.Now;
            DateTime startDate = DateTime.Now.AddDays(5);

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, from);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void StartDateOnFrom()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime from = DateTime.Now;
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, from);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void EndDateAfterFrom()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime from = DateTime.Now.AddDays(9);
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, from);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void EndDateOnFrom()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime from = DateTime.Now.AddDays(10);
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, from);

            // Assert
            Assert.IsFalse(canSchedule);
        }

        [TestMethod]
        public void EndDateBeforeTo()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime to = DateTime.Now.AddDays(11);
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void EndDateOnTo()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime to = DateTime.Now.AddDays(10);
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void StartDateOnTo()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime to = DateTime.Now;
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void StartDateBeforeTo()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime to = DateTime.Now.AddDays(1);
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void StartDateBeforeFrom()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime to = DateTime.Now.AddDays(1);
            DateTime startDate = DateTime.Now;

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void StartDateAfterFromAndBeforeTo()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime from = DateTime.Now;
            DateTime startDate = DateTime.Now.AddDays(1);
            DateTime to = DateTime.Now.AddDays(2);

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 10, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void EndDateAfterFromAndBeforeTo()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime from = DateTime.Now.AddDays(1);
            DateTime startDate = DateTime.Now;
            DateTime to = DateTime.Now.AddDays(3);

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 2, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void FromAndToBetweenRange()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime from = DateTime.Now.AddDays(1);
            DateTime startDate = DateTime.Now;
            DateTime to = DateTime.Now.AddDays(3);

            // Act
            bool canSchedule = scheduler.CanScheduleEvent(startDate, 4, null, to);

            // Assert
            Assert.IsTrue(canSchedule);
        }

        [TestMethod]
        public void DateInWeek()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime date = new DateTime(2016, 10, 10);

            // Act
            bool isInWeek = scheduler.IsInWeek(date, 41, 2016);

            // Assert
            Assert.IsTrue(isInWeek);
        }

        [TestMethod]
        public void SundayInWeek()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime date = new DateTime(2016, 10, 9);

            // Act
            bool isInWeek = scheduler.IsInWeek(date, 40, 2016);

            // Assert
            Assert.IsTrue(isInWeek);
        }

        [TestMethod]
        public void TuesdayInWeek()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime date = new DateTime(2016, 10, 11);

            // Act
            bool isInWeek = scheduler.IsInWeek(date, 41, 2016);

            // Assert
            Assert.IsTrue(isInWeek);
        }

        [TestMethod]
        public void NextMondayInWeek()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime date = new DateTime(2016, 10, 17);

            // Act
            bool isInWeek = scheduler.IsInWeek(date, 42, 2016);

            // Assert
            Assert.IsTrue(isInWeek);
        }

        [TestMethod]
        public void NotInWeek()
        {
            // Arrange
            IDateScheduler scheduler = new DateScheduler();
            DateTime date = new DateTime(2016, 10, 17);

            // Act
            bool isInWeek = scheduler.IsInWeek(date, 41, 2016);

            // Assert
            Assert.IsFalse(isInWeek);
        }
    }
}
