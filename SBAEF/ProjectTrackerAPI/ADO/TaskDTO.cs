using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackerAPI.ADO
{
    public class TaskDTO
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public int? ParentTaskID { get; set; }
        public string ParentTask { get; set; }
        public int ProjectID { get; set; }
        public string ProjectDesc { get; set; }
    }
}