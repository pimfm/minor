using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FrontEnd.Test.Services
{
    [TestClass]
    public class CursusFileParserTest
    {
        [TestMethod]
        public void ParsingEmptyFileReturnsAnEmptyList()
        {
            // Arrange
            CursisFileParser parser = new CursisFileParser();

            // Act
            IEnumerable<Cursis> cursussen = parser.Parse()

            // Assert
        }
    }
}
