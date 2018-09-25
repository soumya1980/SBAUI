using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ProjectTrackerEF;
using ProjectTrackerEF.Models;
using log4net;
using ProjectTrackerAPI.ModelServices;
using ProjectTrackerAPI.Models;

namespace ProjectTrackerAPI.Controllers
{
    [RoutePrefix("api/projects")]
    public class ProjectsController : ApiController
    {
        private ProjectTrackerContext db = new ProjectTrackerContext();
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        
        private IProject projectService;
        public ProjectsController()
        {
            projectService = new ProjectService();
        }
        public ProjectsController(IProject pService)
        {
            projectService = pService;
        }
        [Route("all")]
        [HttpGet]
        public HttpResponseMessage GetProjects()
        {
            log.Debug("START-EXECUTE - Pull All Projects");
            var response = new HttpResponseMessage();
            try
            {
                var projects = projectService.AllProjects();
                response = Request.CreateResponse(HttpStatusCode.OK, projects);
            }
            catch (Exception ex)
            {
                log.ErrorFormat("Fatal Exception happened while pulling data : {0}", ex.InnerException);
            }
            return response;
        }

        // GET: api/Projects/5
        [Route("search/{id}")]
        [HttpGet]
        public HttpResponseMessage GetProject(int id)
        {
            var response = new HttpResponseMessage();
            var project = projectService.GetProject(id);
            if (project == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Project not present");
            }
            response = Request.CreateResponse(HttpStatusCode.OK, project);
            return response;
        }

        [HttpPut]
        [Route("patchproject")]
        public HttpResponseMessage PutProject(int id, Project project)
        {
            var response = new HttpResponseMessage();
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest,"Please check the request object");
            }

            if (id != project.Project_ID)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please check the project id in the request object"); 
            }
            db.Entry(project).State = EntityState.Modified;
            try
            {
                return Request.CreateResponse(HttpStatusCode.OK, db.SaveChanges());
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectExists(id))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,"Project is not found");
                }
                else
                {
                    throw;
                }
            }
        }
        [Route("newproject")]
        [HttpPost]
        public HttpResponseMessage PostProject(UserProject uservmproject)
        {
            var response = new HttpResponseMessage();
            log.Debug("START-EXECUTE-PostProject method");
            if (!ModelState.IsValid)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Please check for valid user");
            }
            try
            {
                var res = projectService.CreateProject(uservmproject);
                log.DebugFormat("User is Created successfully {0}", res);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                log.Error(ex.InnerException);
            }
            return response;
        }
        [Route("viewprojects")]
        [HttpGet]
        public HttpResponseMessage ViewAllProjectsAndStatus()
        {
            var response = new HttpResponseMessage();
            try
            {
                var res = projectService.GetAllProjectsAndStatus();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
            return response;
        }
        // DELETE: api/Projects/5
        [ResponseType(typeof(Project))]
        public IHttpActionResult DeleteProject(int id)
        {
            Project project = db.Projects.Find(id);
            if (project == null)
            {
                return NotFound();
            }

            db.Projects.Remove(project);
            db.SaveChanges();

            return Ok(project);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ProjectExists(int id)
        {
            return db.Projects.Count(e => e.Project_ID == id) > 0;
        }
    }
}