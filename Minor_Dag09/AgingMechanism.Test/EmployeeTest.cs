using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AgeDemo.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void EmployeeIsConstructedWithTheCorrectValuesPubliclyAvailable()
        {
            // Arrange
            Employee pim = new Employee("Pim", 21, 12.50M);

            // Act
            string name = pim.Name;
            int age = pim.Age;
            decimal salary = pim.SalaryPerHour;

            // Assert
            Assert.AreEqual("Pim", name);
            Assert.AreEqual(21, age);
            Assert.AreEqual(12.50M, salary);
        }

        [TestMethod]
        public void EmployeeOverridesOnDateChanged()
        {
            // Arrange
            Employee pim = new Employee("Pim", 21, 12.50M);

            // Act

            // Assert
            Assert.IsTrue(false);
        }
    }
}
