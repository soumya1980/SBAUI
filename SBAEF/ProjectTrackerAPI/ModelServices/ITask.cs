using ProjectTrackerAPI.ADO;
using ProjectTrackerAPI.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTrackerAPI.ModelServices
{
    public interface ITask
    {
        IQueryable<ProjectTrackerEF.Models.Task> AllTasks();
        ProjectTrackerEF.Models.Task GetTask(int id);
        int PatchTask(int id, ProjectTrackerEF.Models.Task task);
        string CreateTask(TaskVm Task);
        string CreateParentTask(TaskVm parentTask);
        int DeleteTask(int id);
        List<TaskDTO> GetAllTasks();
    }
}
