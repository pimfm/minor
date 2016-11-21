//using Frontend.Agents.Models;
//using Frontend.Controllers;
//using FrontEnd.Agents.CourseAgent;
//using FrontEnd.Services;
//using FrontEnd.Test.Mocks;
//using Microsoft.AspNetCore.Mvc;
//using Microsoft.VisualStudio.TestTools.UnitTesting;

//namespace FrontEnd.Test.Controllers
//{
//    [TestClass]
//    public class CourseUploadControllerTest
//    {
//        [TestMethod]
//        public void UploadControllerIsInstanceOfController()
//        {
//            // Arrange
//            ICourseAgent agent = new CourseAgentMock();
//            IFileService<Course> service = new CourseFileServiceMock();
//            CourseUploadController uploadController = new CourseUploadController(agent, service);

//            // Assert
//            Assert.IsInstanceOfType(uploadController, typeof(Controller));
//        }

//        [TestMethod]
//        public void IndexReturnsAViewResult()
//        {
//            // Arrange
//            ICourseAgent agent = new CourseAgentMock();
//            IFileService<Course> service = new CourseFileServiceMock();
//            CourseUploadController uploadController = new CourseUploadController(agent, service);

//            // Act
//            ViewResult response = uploadController.Index();

//            // Assert
//            Assert.IsInstanceOfType(response, typeof(ViewResult));
//        }
//    }
//}
