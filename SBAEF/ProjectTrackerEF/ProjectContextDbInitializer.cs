using System.Data.Entity;

namespace ProjectTrackerEF
{
    public class ProjectContextDbInitializer : DropCreateDatabaseAlways<ProjectTrackerContext>
    {
        protected override void Seed(ProjectTrackerContext context)
        {
            base.Seed(context);
        }
    }
}
