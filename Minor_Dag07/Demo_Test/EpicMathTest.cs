using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Demo_Test
{
    [TestClass]
    public class EpicMathTest
    {
        [TestMethod]
        public void FactorialOneShouldEqualOne()
        {
            // Arrange
            EpicMath math = new EpicMath();

            // Act
            int result = math.Fact(1);

            // Assert
            Assert.AreEqual(1, result);
        }

        [TestMethod]
        public void FactorialThreeShouldEqualSix()
        {
            // Arrange
            EpicMath math = new EpicMath();

            // Act
            int result = math.Fact(3);

            // Assert
            Assert.AreEqual(6, result);
        }

        //[fact]
        //public void finddoublethatissameafteraddingone()
        //{
        //    // arrange
        //    epicmath math = new epicmath();

        //    // act
        //    double result = math.findstrangedouble();

        //    // assert
        //    assert.equal(result, result + 1);
        //}
    }
}
