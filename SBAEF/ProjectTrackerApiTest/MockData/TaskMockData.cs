using ProjectTrackerAPI.ADO;
using ProjectTrackerAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerApiTest.MockData
{
    public class TaskMockData
    {
        public static List<TaskDTO> GetTasks()
        {
            var lstResponse = new List<TaskDTO>();
            lstResponse.Add(new TaskDTO
            {
                ProjectID = 1,
                ProjectDesc = "AML",
                Priority = 1,
                StartDate = "09/21/2008",
                EndDate = "10/21/2008",
                Status = "OPEN",
                ParentTask="",
                ParentTaskID=1,
                TaskID=1,
                TaskName="Test Task One"
            });
            lstResponse.Add(new TaskDTO
            {
                ProjectID = 1,
                ProjectDesc = "AML",
                Priority = 1,
                StartDate = "09/21/2008",
                EndDate = "10/21/2008",
                Status = "OPEN",
                ParentTask = "",
                ParentTaskID = 1,
                TaskID = 1,
                TaskName = "Test Task Two"
            });
            lstResponse.Add(new TaskDTO
            {
                ProjectID = 1,
                ProjectDesc = "AML",
                Priority = 1,
                StartDate = "09/21/2008",
                EndDate = "10/21/2008",
                Status = "OPEN",
                ParentTask = "",
                ParentTaskID = 1,
                TaskID = 1,
                TaskName = "Test Task Three"
            });
            return lstResponse;
        }
        public static TaskVm newTaskRequest()
        {
            return new TaskVm
            {
                parentTaskId=1,
                projectid=1,
                userId=1,
                task=new ProjectTrackerEF.Models.Task
                {
                    TaskName="TaskOne",
                    Priority=1,
                    ParentTask=new ProjectTrackerEF.Models.ParentTask { },
                    Project=new ProjectTrackerEF.Models.Project { },
                    StartDt=DateTime.Now,
                    EndDt=DateTime.Now,
                    Status="Open"
                }
            };
        }
    }
}
