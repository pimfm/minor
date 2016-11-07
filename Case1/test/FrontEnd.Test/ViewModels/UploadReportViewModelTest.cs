
using Frontend.Agents.Models;
using FrontEnd.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace FrontEnd.Test.ViewModels
{
    [TestClass]
    public class UploadReportViewModelTest
    {
        [TestMethod]
        public void SetsConstructorDataProperly()
        {
            // Arrange
            string expected = "file.txt";
            string expected2 = "success";
            string expected3 = "Inserted 5 courses";
            UploadReportViewModel report = new UploadReportViewModel(expected, expected2, expected3);

            // Act
            string actual = report.FileName;
            string actual2 = report.Label;
            string actual3 = report.Message;

            // Assert
            Assert.AreEqual(expected, actual);
            Assert.AreEqual(expected2, actual2);
            Assert.AreEqual(expected3, actual3);
        }

        [TestMethod]
        public void SuccessReport()
        {
            // Arrange
            UploadReport report = new UploadReport(10, 10, 0, "success.txt");

            // Act
            UploadReportViewModel viewModel = UploadReportViewModel.fromUploadReport(report);

            // Assert
            Assert.AreEqual("success", viewModel.Label);
            Assert.AreEqual("success.txt", viewModel.FileName);
            Assert.AreEqual("Alle 10 cursussen zijn nieuw toegevoegd!", viewModel.Message);
        }

        [TestMethod]
        public void InfoReport()
        {
            // Arrange
            UploadReport report = new UploadReport(0, 0, 0, "info.txt");

            // Act
            UploadReportViewModel viewModel = UploadReportViewModel.fromUploadReport(report);

            // Assert
            Assert.AreEqual("info", viewModel.Label);
            Assert.AreEqual("info.txt", viewModel.FileName);
            Assert.AreEqual("Dit bestand bevat geen cursussen, controleer of het goede bestand is geselecteerd.", viewModel.Message);
        }

        [TestMethod]
        public void WarningReport()
        {
            // Arrange
            UploadReport report = new UploadReport(0, 10, 10, "warning.txt");

            // Act
            UploadReportViewModel viewModel = UploadReportViewModel.fromUploadReport(report);

            // Assert
            Assert.AreEqual("warning", viewModel.Label);
            Assert.AreEqual("warning.txt", viewModel.FileName);
            Assert.AreEqual("Geen nieuwe cursussen gevonden. Alle 10 cursussen waren al aanwezig. Controleer of het goede bestand is geselecteerd.", viewModel.Message);
        }

        [TestMethod]
        public void SomeDuplicatesSuccessReport()
        {
            // Arrange
            UploadReport report = new UploadReport(5, 10, 5, "success.txt");

            // Act
            UploadReportViewModel viewModel = UploadReportViewModel.fromUploadReport(report);

            // Assert
            Assert.AreEqual("success", viewModel.Label);
            Assert.AreEqual("success.txt", viewModel.FileName);
            Assert.AreEqual("5 cursussen toegevoegd! 5 cursussen niet toegevoegd, omdat ze al aanwezig waren.", viewModel.Message);
        }
    }
}
