using ProjectTrackerAPI.ADO;
using ProjectTrackerAPI.Models;
using ProjectTrackerEF.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProjectTrackerAPI.ModelServices
{
    public interface IProject
    {
        List<Project> AllProjects();
        Project GetProject(int id);
        int PatchProject(int id, Project project);
        string CreateProject(UserProject uservmproject);
        int DeleteProject(int id);
        List<ProjectDTO> GetAllProjectsAndStatus();
    }
}
