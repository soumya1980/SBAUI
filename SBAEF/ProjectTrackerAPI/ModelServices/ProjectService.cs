using System;
using System.Linq;
using ProjectTrackerEF.Models;
using ProjectTrackerEF;
using ProjectTrackerAPI.Models;
using System.Data.Entity;
using System.Web.Http.ModelBinding;
using ProjectTrackerAPI.ADO;

namespace ProjectTrackerAPI.ModelServices
{
    public class ProjectService : IProject
    {
        private ProjectTrackerContext db;
        public ProjectService()
        {
            db = new ProjectTrackerContext();
        }
        public IQueryable<Project> AllProjects()
        {
            return db.Projects;
        }
        private string UpdateUser(int employeeid,int projectid)
        {
            var userda = new UserDAL();
            return userda.UpdateUser(employeeid, projectid);
            
        }
        public string CreateProject(UserProject uservmproject)
        {
            using (ProjectTrackerContext dbcontxt=new ProjectTrackerContext())
            {
                dbcontxt.Projects.Add(uservmproject.userProject);
                dbcontxt.SaveChanges();
                var project = db.Projects.OrderByDescending(p => p.Project_ID).FirstOrDefault();
                return UpdateUser(Convert.ToInt32(uservmproject.employyeId), project.Project_ID);
            }
        }

        public int DeleteProject(int id)
        {
            throw new NotImplementedException();
        }

        public Project GetProject(int id)
        {
            return db.Projects.Find(id);
        }

        public int PatchProject(int id, Project project)
        {
            throw new NotImplementedException();
        }
    }
}