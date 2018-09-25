using Moq;
using NUnit.Framework;
using ProjectTrackerAPI.Controllers;
using ProjectTrackerAPI.ModelServices;
using ProjectTrackerApiTest.MockData;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Hosting;
using ProjectTrackerAPI.Models;

namespace ProjectTrackerApiTest
{
    /// <summary>
    /// Summary description for ProjectTest
    /// </summary>
    [TestFixture]
    public class ProjectTest
    {
        private ProjectsController _projectsController;
        private Mock<IProject> _projectService;

        [SetUp]
        public void Init()
        {
            _projectService = new Mock<IProject>();
            _projectsController = new ProjectsController(_projectService.Object);
            _projectsController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _projectsController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
        }
        [Test]
        public void GetProjects()
        {
            _projectService.Setup(d => d.AllProjects()).Returns(ProjectMockData.GetProjectsResponse());
            HttpResponseMessage apiResponse = _projectsController.GetProjects();
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void GetProjectById()
        {
            _projectService.Setup(d => d.GetProject(1)).Returns(ProjectMockData.GetProjectResponse());
            HttpResponseMessage apiResponse = _projectsController.GetProject(1);
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        
        [Test]
        public void CreateProject()
        {
            _projectService.Setup(d => d.CreateProject(It.IsAny<UserProject>())).Returns("SUCCESS");
            HttpResponseMessage apiResponse = _projectsController.PostProject(ProjectMockData.newprojectRequest());
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void ViewAllProjectsAndStatus()
        {
            _projectService.Setup(d => d.GetAllProjectsAndStatus()).Returns(ProjectMockData.GetProjectAndStatus());
            HttpResponseMessage apiResponse = _projectsController.ViewAllProjectsAndStatus();
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
    }
}
