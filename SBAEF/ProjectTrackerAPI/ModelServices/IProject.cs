using ProjectTrackerAPI.Models;
using ProjectTrackerEF.Models;
using System.Linq;

namespace ProjectTrackerAPI.ModelServices
{
    public interface IProject
    {
        IQueryable<Project> AllProjects();
        Project GetProject(int id);
        int PatchProject(int id, Project project);
        string CreateProject(UserProject uservmproject);
        int DeleteProject(int id);
        //int UpdateUser();
    }
}
