using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberValidationTest
{
    [TestClass]
    public class NumberValidorTest
    {
        [TestMethod]
        public void ValidNumberStartWithAMinus()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("-2,000.00");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void InvalidNumberStartsWithAPlus()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("+2,000.00");

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidNumberStartsWithoutMinusOrPlus()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("2,000.00");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void ValidNumberStartsWithMaximumOfThreeDigits()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("200,000.00");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void InvalidNumberStartsWithFourDigits()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("20000,000.00");

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void ValidNumberLowerThan1000()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("900.00");

            // Assert
            Assert.IsTrue(isValid);
        }

        [TestMethod]
        public void InvalidNumberWithoutDecimals()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("900");

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void InvalidNumberWithoutPi()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("PI900");

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void InvalidNumberWithOneDecimal()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("900.0");

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void InvalidNumberWithThreeDecimals()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("9,000,000.000");

            // Assert
            Assert.IsFalse(isValid);
        }

        [TestMethod]
        public void InvalidNumberWithLessThanThreeNumbersInRepeatingCommaPattern()
        {
            // Arrange
            NumberValidator validator = new NumberValidator();

            // Act
            bool isValid = validator.Validate("18,00,000.67");

            // Assert
            Assert.IsFalse(isValid);
        }
    }
}
