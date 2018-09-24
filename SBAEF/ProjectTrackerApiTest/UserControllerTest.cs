using Moq;
using NUnit.Framework;
using ProjectTrackerAPI.Controllers;
using ProjectTrackerAPI.ModelServices;
using ProjectTrackerApiTest.MockData;
using System.Linq;
using System.Net;
using System.Net.Http;

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
            Assert.AreEqual(((StreamContent)lstResponse).ReadAsStringAsync().Result, 3);
        }
    }
}
