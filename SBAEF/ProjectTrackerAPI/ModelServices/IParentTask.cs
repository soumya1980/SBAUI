using ProjectTrackerEF.Models;
using System.Linq;

namespace ProjectTrackerAPI.ModelServices
{
    public interface IParentTask
    {
        IQueryable<ParentTask> AllParentTasks();
        ParentTask GetParentTask(int id);
        int PatchParentTask(int id, ParentTask parentTask);
        string CreateParentTask(ParentTask parentTask);
        int DeleteParentTask(int id);
    }
}
