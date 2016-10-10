
using FrontEnd.Controllers;
using FrontEnd.Test.Mocks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace FrontEnd.Test.Controllers
{
    [TestClass]
    public class CursusUploadControllerTest
    {
        private HostingEnvironmentMock _environment;
        private List<IFormFile> _file;
        private List<IFormFile> _files;
        private string _folder;

        [TestInitialize]
        public void Initialize()
        {
            _environment = new HostingEnvironmentMock();
            _folder = Path.Combine(_environment.WebRootPath, "uploads");

            _file = new List<IFormFile>();
            _files = new List<IFormFile>();

            _file.Add(new FormFileMock());

            _files.Add(new FormFileMock());
            _files.Add(new FormFileMock());
            _files.Add(new FormFileMock());
        }

        [TestMethod]
        public void ItIsAnInstanceOfController()
        {
            // Arrange
            CursusUploadController controller = new CursisUploadController(_environment);

            // Assert
            Assert.IsInstanceOfType(controller, typeof(Controller));
        }

        [TestMethod]
        public void SavingASingleFile()
        {
            // Arrange
            CursusUploadController controller = new CursisUploadController(_environment);
            FormFileMock file = _file.First() as FormFileMock;

            // Act
            controller.Upload(_file);

            // Assert
            Assert.IsTrue(file.CopyToHasBeenCalled);
            Assert.AreEqual(1, Directory.GetFiles(_folder).Length);
        }

        [TestMethod]
        public void SavingMultipleFiles()
        {
            // Arrange
            CursusUploadController controller = new CursisUploadController(_environment);

            // Act
            controller.Upload(_files);

            // Assert
            foreach (IFormFile formFile in _files)
            {
                FormFileMock file = formFile as FormFileMock;

                Assert.IsTrue(file.CopyToHasBeenCalled);
            }

            Assert.AreEqual(_files.Count, Directory.GetFiles(_folder).Length);
        }

        [TestCleanup]
        public void DeInitialize()
        {
            DirectoryInfo directory = new DirectoryInfo(_folder);

            foreach (FileInfo file in directory.GetFiles())
            {
                file.Delete();
            }
        }
    }
}
