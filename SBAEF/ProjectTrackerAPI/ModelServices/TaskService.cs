using System;
using System.Linq;
using ProjectTrackerEF.Models;
using ProjectTrackerEF;
using ProjectTrackerAPI.Models;
using ProjectTrackerAPI.ADO;
using System.Collections.Generic;

namespace ProjectTrackerAPI.ModelServices
{
    public class TaskService : ITask
    {
        public IQueryable<Task> AllTasks()
        {
            throw new NotImplementedException();
        }
        private string UpdateTask(int projectid, int? parentTaskId, int taskId,int userId)
        {
            var userda = new UserDAL();
            return userda.UpdateTask(projectid, parentTaskId, taskId, userId);

        }
        public string CreateTask(TaskVm task)
        {
            using (ProjectTrackerContext dbcontxt = new ProjectTrackerContext())
            {
                dbcontxt.Tasks.Add(task.task);
                dbcontxt.SaveChanges();
                //Fetch the TaskId created 
                var addedtask = dbcontxt.Tasks.OrderByDescending(t => t.Task_ID).FirstOrDefault();
                //Fetch the projectid to associate the task
                var project = dbcontxt.Projects.FirstOrDefault(p => p.Project_ID==task.projectid);
                var parentTask= dbcontxt.ParentTasks.FirstOrDefault(p => p.Parent_ID == task.parentTaskId);
                //Revisit the logic tomorrow
                if (parentTask == null)
                {
                    return UpdateTask(project.Project_ID, null, addedtask.Task_ID, task.userId);
                }
                return UpdateTask(project.Project_ID,parentTask.Parent_ID,addedtask.Task_ID, task.userId);
            }
        }
        private string UpdateTaskWithParent(int projectid, int parentTaskId,Task taskdata,int userId)
        {
            var userda = new UserDAL();
            return userda.UpdateTaskWithParent(projectid, parentTaskId, taskdata, userId);
        }
        public string CreateParentTask(TaskVm parentTask)
        {
            try
            {
                using (ProjectTrackerContext dbcontxt = new ProjectTrackerContext())
                {
                    var pTask = new ParentTask {
                        Parent_Task=parentTask.task.TaskName
                    };
                    dbcontxt.ParentTasks.Add(pTask);
                    dbcontxt.SaveChanges();
                    //Fetch the ParentTaskId created 
                    var addedparenttask = dbcontxt.ParentTasks.OrderByDescending(t => t.Parent_ID).FirstOrDefault();
                    //Fetch the projectid to associate the task
                    var project = dbcontxt.Projects.FirstOrDefault(p => p.Project_ID == parentTask.projectid);
                    return UpdateTaskWithParent(project.Project_ID,addedparenttask.Parent_ID,parentTask.task, parentTask.userId);
                }
            }
            catch (Exception)
            {
                return "FAIL";
            }
        }
        public int DeleteTask(int id)
        {
            throw new NotImplementedException();
        }

        public Task GetTask(int id)
        {
            throw new NotImplementedException();
        }

        public List<TaskDTO> GetAllTasks()
        {
            var taskDa = new TaskDAL();
            return taskDa.GetAllTasks();
        }
        public int PatchTask(int id, Task task)
        {
            throw new NotImplementedException();
        }
    }
}