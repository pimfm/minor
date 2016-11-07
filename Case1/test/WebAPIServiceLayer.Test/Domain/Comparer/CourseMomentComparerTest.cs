using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using WebAPIServiceLayer.Domain.Comparer;
using WebAPIServiceLayer.Domain.Entities;

namespace BackendService.Test.Domain.Comparer
{
    [TestClass]
    public class CourseMomentComparerTest
    {
        [TestMethod]
        public void CourseMomentsAreEqual()
        {
            // Arrange
            Course course = new Course("Title", "CODE", 10);
            CourseMoment moment = new CourseMoment(course, new DateTime(2016, 10, 10));
            CourseMoment other = new CourseMoment(course, new DateTime(2016, 10, 10));
            CourseMomentComparer comparer = new CourseMomentComparer();

            // Act
            bool areEqual = comparer.Equals(moment, other);

            // Assert
            Assert.IsTrue(areEqual);
            Assert.AreEqual(moment.GetHashCode(), comparer.GetHashCode(moment));
            Assert.AreEqual(other.GetHashCode(), comparer.GetHashCode(other));
        }

        [TestMethod]
        public void CourseMomentsAreInequalInDate()
        {
            // Arrange
            Course course = new Course("Title", "CODE", 10);
            CourseMoment moment = new CourseMoment(course, new DateTime(2016, 10, 10));
            CourseMoment other = new CourseMoment(course, new DateTime(2016, 10, 11));
            CourseMomentComparer comparer = new CourseMomentComparer();

            // Act
            bool areEqual = comparer.Equals(moment, other);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.AreEqual(moment.GetHashCode(), comparer.GetHashCode(moment));
            Assert.AreEqual(other.GetHashCode(), comparer.GetHashCode(other));
        }

        [TestMethod]
        public void CourseMomentsAreInequalInCourse()
        {
            // Arrange
            Course course = new Course("Title", "CODE", 10);
            Course differentCourse = new Course("Title", "CODD", 10);
            CourseMoment moment = new CourseMoment(course, new DateTime(2016, 10, 10));
            CourseMoment other = new CourseMoment(differentCourse, new DateTime(2016, 10, 10));
            CourseMomentComparer comparer = new CourseMomentComparer();

            // Act
            bool areEqual = comparer.Equals(moment, other);

            // Assert
            Assert.IsFalse(areEqual);
            Assert.AreEqual(moment.GetHashCode(), comparer.GetHashCode(moment));
            Assert.AreEqual(other.GetHashCode(), comparer.GetHashCode(other));
        }
    }
}
