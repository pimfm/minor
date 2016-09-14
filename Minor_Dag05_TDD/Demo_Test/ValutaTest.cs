using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo_Test
{
    [TestClass]
    public class ValutaTest
    {
        [TestMethod]
        public void ValutaKanAangemaaktWorden()
        {
            // Arrange
            Valuta euro = new Valuta(100.00M, GeldSoort.Euro);

            // Act
            string waarde = euro.ToString();

            // Assert
            StringAssert.Contains("100,00 Euro", waarde);
        }

        [TestMethod]
        public void ValutaWordtGeformatInEuro()
        {
            // Arrange
            Valuta euro = new Valuta(100.00M, GeldSoort.Euro);
            GeldSoortFormatter formatter = new GeldSoortFormatter();

            // Act
            formatter.addFormat(GeldSoort.Euro, "EUR");
            string result = euro.Format(formatter);

            // Assert
            Assert.AreEqual("100,00 EUR", result);
        }

        [TestMethod]
        public void ValutaWordtGeformat()
        {
            // Arrange
            Valuta gulden = new Valuta(100.00M, GeldSoort.Gulden);
            GeldSoortFormatter formatter = new GeldSoortFormatter();

            // Act
            formatter.addFormat(GeldSoort.Gulden, "fl");
            string result = gulden.Format(formatter);

            // Assert
            Assert.AreEqual("100,00 fl", result);
        }

        [TestMethod]
        public void ValutaKanWordenOmgerekend()
        {
            // Arrange
            Valuta euro = new Valuta(100.00M, GeldSoort.Euro);
            Bank bank = new Bank();

            // Act
            bank.VoegWisselkoersToe(GeldSoort.Euro, GeldSoort.Gulden, 2.20371M);
            Valuta waardeInGulden = bank.Converteer(euro, GeldSoort.Gulden);

            // Assert
            Assert.AreEqual("220,37 Gulden", waardeInGulden.ToString());
        }
    }
}
