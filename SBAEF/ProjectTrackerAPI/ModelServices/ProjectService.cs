using System;
using System.Linq;
using ProjectTrackerEF.Models;
using ProjectTrackerEF;
using ProjectTrackerAPI.Models;
using System.Data.Entity;
using System.Web.Http.ModelBinding;
using ProjectTrackerAPI.ADO;
using System.Collections.Generic;

namespace ProjectTrackerAPI.ModelServices
{
    public class ProjectService : IProject
    {
        private ProjectTrackerContext db;
        public ProjectService()
        {
            db = new ProjectTrackerContext();
        }
        public List<Project> AllProjects()
        {
            try
            {
                var lstProject = new List<Project>();
                foreach (var item in db.Projects)
                {
                    lstProject.Add(new Project
                    {
                        Project_ID=item.Project_ID,
                        ProjectDesc=item.ProjectDesc,
                        Priority=item.Priority,
                        StartDt=item.StartDt,
                        EndDt=item.EndDt
                    });
                }
                return lstProject;
            }
            catch (Exception ex)
            {
                throw ex.InnerException;
            }
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
        public List<ProjectDTO> GetAllProjectsAndStatus()
        {
            var projectDa = new ProjectDAL();
            return projectDa.GetAllProjectsAndStatus();
        }
        public int PatchProject(int id, Project project)
        {
            throw new NotImplementedException();
        }
    }
}