using ProjectTrackerEF.Models;

namespace ProjectTrackerAPI.Models
{
    public class TaskVm
    {
        public Task task { get; set; }
        public int projectid { get; set; }
        public int parentTaskId { get; set; }
        public int userId { get; set; }
    }
}