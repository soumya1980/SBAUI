﻿using System;
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

namespace ProjectTrackerAPI.Controllers
{
    [RoutePrefix("api/parenttasks")]
    public class ParentTasksController : ApiController
    {
        private ProjectTrackerContext db = new ProjectTrackerContext();

        [Route("all")]
        public IQueryable<ParentTask> GetParentTasks()
        {
            return db.ParentTasks;
        }

        // GET: api/ParentTasks/5
        [ResponseType(typeof(ParentTask))]
        public IHttpActionResult GetParentTask(int id)
        {
            ParentTask parentTask = db.ParentTasks.Find(id);
            if (parentTask == null)
            {
                return NotFound();
            }

            return Ok(parentTask);
        }

        // PUT: api/ParentTasks/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutParentTask(int id, ParentTask parentTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != parentTask.Parent_ID)
            {
                return BadRequest();
            }

            db.Entry(parentTask).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParentTaskExists(id))
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

        // POST: api/ParentTasks
        [ResponseType(typeof(ParentTask))]
        public IHttpActionResult PostParentTask(ParentTask parentTask)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ParentTasks.Add(parentTask);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = parentTask.Parent_ID }, parentTask);
        }

        // DELETE: api/ParentTasks/5
        [ResponseType(typeof(ParentTask))]
        public IHttpActionResult DeleteParentTask(int id)
        {
            ParentTask parentTask = db.ParentTasks.Find(id);
            if (parentTask == null)
            {
                return NotFound();
            }

            db.ParentTasks.Remove(parentTask);
            db.SaveChanges();

            return Ok(parentTask);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ParentTaskExists(int id)
        {
            return db.ParentTasks.Count(e => e.Parent_ID == id) > 0;
        }
    }
}