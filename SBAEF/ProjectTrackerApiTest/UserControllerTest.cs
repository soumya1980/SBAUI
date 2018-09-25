using Moq;
using NUnit.Framework;
using ProjectTrackerAPI.Controllers;
using ProjectTrackerAPI.ModelServices;
using ProjectTrackerApiTest.MockData;
using System.Linq;
using System.Net;
using System.Net.Http;
using EFModel = ProjectTrackerEF.Models;
using System.Web.Http;
using System.Web.Http.Hosting;

namespace ProjectTrackerApiTest
{
    [TestFixture]
    public class UserControllerTest
    {
        private UsersController _userController;
        private Mock<IUser> _userService;
        [SetUp]
        public void Init()
        {
            _userService = new Mock<IUser>();
            _userController = new UsersController(_userService.Object);
            _userController.Request = new HttpRequestMessage();
            var config = new HttpConfiguration();
            _userController.Request.Properties.Add(HttpPropertyKeys.HttpConfigurationKey, config);
        }
        [Test]
        public void GetUsers()
        {
            _userService.Setup(d => d.AllUsers()).Returns(UserMockData.GetUsersResponse());
            HttpResponseMessage apiResponse = _userController.GetUsers();
            var lstResponse = apiResponse.Content;
            
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void GetUserById()
        {
            _userService.Setup(d => d.GetUser(1)).Returns(UserMockData.GetUserResponse());
            HttpResponseMessage apiResponse = _userController.GetUser(1);
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void PatchUser()
        {
            _userService.Setup(d => d.PatchUser(1,It.IsAny<EFModel.User>())).Returns(1);
            HttpResponseMessage apiResponse = _userController.PutUser(1,UserMockData.userRequest());
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void CreateUser()
        {
            _userService.Setup(d => d.CreateUser(It.IsAny<EFModel.User>())).Returns(1);
            HttpResponseMessage apiResponse = _userController.PostUser(UserMockData.newUserRequest());
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
        [Test]
        public void DeleteUser()
        {
            _userService.Setup(d => d.DeleteUser(1)).Returns(1);
            HttpResponseMessage apiResponse = _userController.DeleteUser(1);
            var lstResponse = apiResponse.Content;
            Assert.AreEqual(apiResponse.StatusCode, HttpStatusCode.OK);
        }
    }
}
