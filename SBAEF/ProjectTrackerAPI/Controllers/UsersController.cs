using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectTrackerEF;
using ProjectTrackerEF.Models;
using log4net;
using ProjectTrackerAPI.ModelServices;
using EFModel = ProjectTrackerEF.Models;
using System.Net.Http;

namespace ProjectTrackerAPI.Controllers
{
    [RoutePrefix("api/user")]
    public class UsersController : ApiController
    {
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private ProjectTrackerContext db = new ProjectTrackerContext();
        private IUser userService;
        public UsersController()
        {
            userService = new ModelServices.User();
        }
        public UsersController(IUser user)
        {
            //userService = new ModelServices.User();
            userService = user;
        }
        [HttpGet]
        [Route("all")]
        public HttpResponseMessage GetUsers()
        {
            log.Debug("START-EXECUTE - Pull All Users");
            var response = new HttpResponseMessage();
            try
            {
                var users= userService.AllUsers();
                response = Request.CreateResponse(HttpStatusCode.OK,users);
            }
            catch (System.Exception ex)
            {
                log.ErrorFormat("Fatal Exception happened while pulling data : {0}", ex.InnerException);
            }
            return response;
        }
        [HttpGet]
        [Route("search/{id}")]
        public HttpResponseMessage GetUser(int id)
        {
            var response = new HttpResponseMessage();
            var user = userService.GetUser(id);
            if (user == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "User is not present");
            }
            response = Request.CreateResponse(HttpStatusCode.OK, user);

            return response;
        }
        [HttpPut]
        [Route("patchuser/{id}")]
        public HttpResponseMessage PutUser(int id, EFModel.User user)
        {
            var response = new HttpResponseMessage();
            log.Debug("START-EXECUTE- PutUser method");
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Please cehck the User Inputs");
            }
            if (id != user.User_ID)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please cehck the valid UserID"); ;
            }
            try
            {
                var cnt = userService.PatchUser(id, user);
                log.DebugFormat("User is Patched successfully {0}", cnt);
                response = Request.CreateResponse(HttpStatusCode.OK,cnt);
            }
            catch (System.Exception ex)
            {
                log.Error(ex.InnerException);
            }
            return response;
        }
        [HttpPost]
        [Route("newuser")]
        public HttpResponseMessage PostUser([FromBody]EFModel.User user)
        {
            var response = new HttpResponseMessage();
            log.Debug("START-EXECUTE-PostUser method");
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Please check for valid user");
            }
            try
            {
                var cnt = userService.CreateUser(user);
                log.DebugFormat("User is Created successfully {0}", cnt);
                response = Request.CreateResponse(HttpStatusCode.OK,cnt);
            }
            catch (System.Exception ex)
            {
                log.Error(ex.InnerException);
            }
            return response;
        }
        [HttpDelete]
        [Route("deleteuser")]
        [ResponseType(typeof(EFModel.User))]
        public HttpResponseMessage DeleteUser(int id)
        {
            int cnt;
            var response = new HttpResponseMessage();
            try
            {
                cnt = userService.DeleteUser(id);
                response = Request.CreateResponse(HttpStatusCode.OK,cnt);
                log.DebugFormat("User is Deleted successfully {0}", cnt);
            }
            catch (System.Exception ex)
            {
                log.Error(ex.InnerException);
            }

            return response;
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}