using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Demo_Test
{
    [TestClass]
    public class KaartTest
    {
        [TestMethod]
        public void InitieleSaldoSet()
        {
            // Arrange
            decimal initieelSaldo = 40.50M;
            MicroKaart kaart = new MicroKaart(initieelSaldo);

            // Act
            decimal huidigeSaldo = kaart.HuidigeSaldo();

            // Assert
            Assert.AreEqual(initieelSaldo, huidigeSaldo);
        }

        [TestMethod]
        public void BetaalVerlaagtHuidigeSaldo()
        {
            // Arrange
            decimal initieelSaldo = 40.50M;
            decimal kostenBroodjeHamburger = 2.50M;

            MicroKaart kaart = new MicroKaart(initieelSaldo);

            // Act
            kaart.Betaal(kostenBroodjeHamburger);

            // Assert
            Assert.AreEqual(38.0M, kaart.HuidigeSaldo());
        }

        [TestMethod]
        public void BetaalVerlaagtHuidigeSaldoMeerdereKerenBijMeerdereBetalingen()
        {
            // Arrange
            decimal initieelSaldo = 40.50M;
            decimal kostenBroodjeHamburger = 2.50M;
            decimal kostenNieuweSchoenen = 22.0M;

            MicroKaart kaart = new MicroKaart(initieelSaldo);

            // Act
            kaart.Betaal(kostenBroodjeHamburger);
            kaart.Betaal(kostenNieuweSchoenen);

            // Assert
            Assert.AreEqual(16.0M, kaart.HuidigeSaldo());
        }

        //[TestMethod]
        //public void BetaalStaatHetNietToeOmMetEenNegatiefSaldoTeBetalen()
        //{
        //    // Arrange
        //    decimal initieelSaldo = 40.50M;
        //    decimal kostenPlaystation = 220.0M;

        //    MicroKaart kaart = new MicroKaart(initieelSaldo);

        //    // Act
        //    Exception exception = Assert.Throws<OnvoldoendeSaldoException>(() => kaart.Betaal(kostenPlaystation));

        //    // Assert
        //    Assert.Contains("negatief saldo", exception.Message);
        //}

        [TestMethod]
        public void VipKaartWordtAangemaaktMetKortingsPercentage()
        {
            // Arrange
            decimal kortingsPercentage = 2.5M;

            VIPMicroKaart vipKaart = new VIPMicroKaart(kortingsPercentage);

            // Act
            decimal korting = vipKaart.HuidigeKortingsPercentage();

            // Assert
            Assert.AreEqual(kortingsPercentage, korting);
        }

        [TestMethod]
        public void VipKaartBetaaltMinderDoorKorting()
        {
            // Arrange
            decimal kortingsPercentage = 2.5M;
            decimal kostenHorloge = 100.0M;

            VIPMicroKaart vipKaart = new VIPMicroKaart(kortingsPercentage);

            // Act
            vipKaart.Betaal(kostenHorloge);

            // Assert
            Assert.AreEqual(-97.5M, vipKaart.HuidigeSaldo());
        }
    }
}
