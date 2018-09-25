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
    [TestFixture]
    public class TaskControllerTest
    {
        private TasksController _tasksController;
        private Mock<ITask> _taskService;
        [SetUp]
        public void Init()
        {
            _taskService = new Mock<ITask>();
            _tasksController = new TasksController(_taskService.Object);
            _tasksController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _tasksController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
        }
        [Test]
        public void ViewAllTasks()
        {
            _taskService.Setup(d => d.GetAllTasks()).Returns(TaskMockData.GetTasks());
            HttpResponseMessage apiResponse = _tasksController.ViewAllTasks();
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void CreateTask()
        {
            _taskService.Setup(d => d.CreateTask(It.IsAny<TaskVm>())).Returns("SUCCESS");
            HttpResponseMessage apiResponse = _tasksController.PostTask(TaskMockData.newTaskRequest());
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void CreateTaskAsParent()
        {
            _taskService.Setup(d => d.CreateParentTask(It.IsAny<TaskVm>())).Returns("SUCCESS");
            HttpResponseMessage apiResponse = _tasksController.PostTask(TaskMockData.newTaskRequest());
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
    }
}
