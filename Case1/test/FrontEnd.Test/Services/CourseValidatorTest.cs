using Exceptions;
using FrontEnd.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Services;
using System;

namespace FrontEnd.Test.Services
{
    [TestClass]
    public class CourseValidatorTest
    {
        [TestMethod]
        public void ItIsACourseValidator()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Assert
            Assert.IsInstanceOfType(validator, typeof(ICourseValidator));
        }

        [TestMethod]
        public void ValidTitle()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            string title = validator.ValidateTitle("Titel: C# Programmeren");
            string title2 = validator.ValidateTitle("Titel:C# Programmeren");
            string title3 = validator.ValidateTitle("Titel:C# Programmeren    ");

            // Assert
            Assert.AreEqual("C# Programmeren", title);
            Assert.AreEqual("C# Programmeren", title2);
            Assert.AreEqual("C# Programmeren    ", title3);
        }

        [TestMethod]
        public void ValidCode()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            string code = validator.ValidateCode("Cursuscode: CNETIN");
            string code2 = validator.ValidateCode("Cursuscode: CNETINDDDD");
            string code3 = validator.ValidateCode("Cursuscode:C");

            // Assert
            Assert.AreEqual("CNETIN", code);
            Assert.AreEqual("CNETINDDDD", code2);
            Assert.AreEqual("C", code3);
        }

        [TestMethod]
        public void ValidDuration()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            int code = validator.ValidateDuration("Duur:5dagen");
            int code2 = validator.ValidateDuration("Duur:10 dagen");
            int code3 = validator.ValidateDuration("Duur: 110 dagen");
            int code4 = validator.ValidateDuration("Duur: 130dagen");

            // Assert
            Assert.AreEqual(5, code);
            Assert.AreEqual(10, code2);
            Assert.AreEqual(110, code3);
            Assert.AreEqual(130, code4);
        }

        [TestMethod]
        public void ValidStartDate()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();
            DateTime actual = new DateTime(2014, 10, 20);
            DateTime actual2 = new DateTime(2016, 10, 20);

            // Act
            DateTime startDate = validator.ValidateStartDate("Startdatum: 20/10/2014");
            DateTime startDate2 = validator.ValidateStartDate("Startdatum:20/10/2016");

            // Assert
            Assert.AreEqual(actual, startDate);
            Assert.AreEqual(actual2, startDate2);
        }

        [TestMethod]
        public void ValidEmptyLine()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            string emptyLine = validator.ValidateEmptyLine("");
            string emptyLine2 = validator.ValidateEmptyLine("    ");
            string emptyLine3 = validator.ValidateEmptyLine("  ");

            // Assert
            Assert.AreEqual("", emptyLine);
            Assert.AreEqual("    ", emptyLine2);
            Assert.AreEqual("  ", emptyLine3);
        }

        [TestMethod]
        public void InvalidTitle()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            Action title = () => validator.ValidateTitle("Title:");
            Action title2 = () => validator.ValidateTitle("Tilte:");
            Action title3 = () => validator.ValidateTitle("Title:   Leren programmeren");
            Action title4 = () => validator.ValidateTitle(" Title:   Leren programmeren");

            // Assert
            Assert.ThrowsException<PatternDidNotMatchException>(title);
            Assert.ThrowsException<PatternDidNotMatchException>(title2);
            Assert.ThrowsException<PatternDidNotMatchException>(title3);
            Assert.ThrowsException<PatternDidNotMatchException>(title4);
        }

        [TestMethod]
        public void InvalidCode()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            Action code = () => validator.ValidateCode("Cursuscode:");
            Action code2 = () => validator.ValidateCode("Cursuscode: TTTTTTTTTTT");
            Action code3 = () => validator.ValidateCode("Cursuscode: C0DE");
            Action code4 = () => validator.ValidateCode("Curscode: CNETIN");
            Action code5 = () => validator.ValidateCode(" Curscode: CNETIN");

            // Assert
            Assert.ThrowsException<PatternDidNotMatchException>(code);
            Assert.ThrowsException<PatternDidNotMatchException>(code2);
            Assert.ThrowsException<PatternDidNotMatchException>(code3);
            Assert.ThrowsException<PatternDidNotMatchException>(code4);
            Assert.ThrowsException<PatternDidNotMatchException>(code5);
        }

        [TestMethod]
        public void InvalidDuration()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            Action duration = () => validator.ValidateDuration("Duur: 5 dagon");
            Action duration2 = () => validator.ValidateDuration("Deur: 5 dagen");
            Action duration3 = () => validator.ValidateDuration("Duur: 5 dagens");
            Action duration4 = () => validator.ValidateDuration(" Duur: 5 dagen");
            Action duration5 = () => validator.ValidateDuration("Duur: 5");

            // Assert
            Assert.ThrowsException<PatternDidNotMatchException>(duration);
            Assert.ThrowsException<PatternDidNotMatchException>(duration2);
            Assert.ThrowsException<PatternDidNotMatchException>(duration3);
            Assert.ThrowsException<PatternDidNotMatchException>(duration4);
            Assert.ThrowsException<PatternDidNotMatchException>(duration5);
        }

        [TestMethod]
        public void InvalidStartDate()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            Action startDate = () => validator.ValidateStartDate("Startdatum:20-10-2016");
            Action startDate2 = () => validator.ValidateStartDate("Startdatum:20/10-2016");
            Action startDate3 = () => validator.ValidateStartDate("Startdatum:2016/10/10");
            Action startDate4 = () => validator.ValidateStartDate("Startdatum:2016/10/10/10");
            Action startDate5 = () => validator.ValidateStartDate("Startdatum:2016");
            Action startDate6 = () => validator.ValidateStartDate("Startdtum:10/10/2016");
            Action startDate7 = () => validator.ValidateStartDate(" Startdatum:10/10/2016");

            // Assert
            Assert.ThrowsException<PatternDidNotMatchException>(startDate);
            Assert.ThrowsException<PatternDidNotMatchException>(startDate2);
            Assert.ThrowsException<PatternDidNotMatchException>(startDate3);
            Assert.ThrowsException<PatternDidNotMatchException>(startDate4);
            Assert.ThrowsException<PatternDidNotMatchException>(startDate5);
            Assert.ThrowsException<PatternDidNotMatchException>(startDate6);
            Assert.ThrowsException<PatternDidNotMatchException>(startDate7);
        }

        [TestMethod]
        public void InvalidEmptyLine()
        {
            // Arrange
            ICourseValidator validator = new CourseValidator();

            // Act
            Action emptyLine = () => validator.ValidateStartDate("NOT SO EMPTY");
            Action emptyLine2 = () => validator.ValidateStartDate(" NOT SO EMPTY");
            Action emptyLine3 = () => validator.ValidateStartDate(".");

            // Assert
            Assert.ThrowsException<PatternDidNotMatchException>(emptyLine);
            Assert.ThrowsException<PatternDidNotMatchException>(emptyLine2);
            Assert.ThrowsException<PatternDidNotMatchException>(emptyLine3);
        }
    }
}
