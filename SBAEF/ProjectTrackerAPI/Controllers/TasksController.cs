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
using ProjectTrackerAPI.ModelServices;
using ProjectTrackerAPI.Models;

namespace ProjectTrackerAPI.Controllers
{
    [RoutePrefix("api/tasks")]
    public class TasksController : ApiController
    {
        private ProjectTrackerContext db = new ProjectTrackerContext();
        private ITask taskService;
        
        public TasksController()
        {
            taskService = new TaskService();
        }
        [Route("tasks")]
        [HttpGet]
        public HttpResponseMessage GetTasks()
        {
            var response = new HttpResponseMessage();
            try
            {
                response = Request.CreateResponse(HttpStatusCode.OK, db.Tasks);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex.InnerException);
            }
            return response;
        }

       
       [Route("search/{id}")]
       [HttpGet]
        public HttpResponseMessage GetTask(int id)
        {
            var response = new HttpResponseMessage();
            try
            {
                var task = db.Tasks.Find(id);
                if (task == null)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Task not found");
                }
                response = Request.CreateResponse(HttpStatusCode.OK,task);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
            return response;
        }

        // PUT: api/Tasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTask(int id, Task task)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != task.Task_ID)
            {
                return BadRequest();
            }

            db.Entry(task).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

       [Route("newtask")]
       [HttpPost]
        public HttpResponseMessage PostTask([FromBody]TaskVm taskvm)
        {
            var response = new HttpResponseMessage();
            try
            {
                var res = taskService.CreateTask(taskvm);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
            return response;
        }
        [Route("viewtasks")]
        [HttpGet]
        public HttpResponseMessage ViewAllTasks()
        {
            var response = new HttpResponseMessage();
            try
            {
                var res = taskService.GetAllTasks();
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
            return response;
        }
        [Route("newtaskasparent")]
        [HttpPost]
        public HttpResponseMessage PostTaskAsParent(TaskVm parentTaskVm)
        {
            var response = new HttpResponseMessage();
            try
            {
                var res = taskService.CreateParentTask(parentTaskVm);
                response = Request.CreateResponse(HttpStatusCode.OK, res);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.InnerException);
            }
            return response;
        }
        // DELETE: api/Tasks/5
        [ResponseType(typeof(Task))]
        public IHttpActionResult DeleteTask(int id)
        {
            Task task = db.Tasks.Find(id);
            if (task == null)
            {
                return NotFound();
            }

            db.Tasks.Remove(task);
            db.SaveChanges();

            return Ok(task);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool TaskExists(int id)
        {
            return db.Tasks.Count(e => e.Task_ID == id) > 0;
        }
    }
}