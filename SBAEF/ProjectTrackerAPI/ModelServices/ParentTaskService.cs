using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectTrackerEF.Models;
using ProjectTrackerEF;

namespace ProjectTrackerAPI.ModelServices
{
    public class ParentTaskService : IParentTask
    {
        public IQueryable<ParentTask> AllParentTasks()
        {
            throw new NotImplementedException();
        }

        public string CreateParentTask(ParentTask parentTask)
        {
            try
            {
                using (ProjectTrackerContext dbcontxt = new ProjectTrackerContext())
                {
                    dbcontxt.ParentTasks.Add(parentTask);
                    dbcontxt.SaveChanges();
                }
                return "SUCCESS";
            }
            catch (Exception)
            {
                return "FAIL";
            }
        }

        public int DeleteParentTask(int id)
        {
            throw new NotImplementedException();
        }

        public ParentTask GetParentTask(int id)
        {
            throw new NotImplementedException();
        }

        public int PatchParentTask(int id, ParentTask parentTask)
        {
            throw new NotImplementedException();
        }
    }
}