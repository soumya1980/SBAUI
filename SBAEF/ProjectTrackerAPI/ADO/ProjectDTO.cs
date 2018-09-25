using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackerAPI.ADO
{
    public class ProjectDTO
    {
        public int ProjectID { get; set; }
        public string ProjectDesc { get; set; }
        public String StartDate { get; set; }
        public String EndDate { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }
        public int TaskNos { get; set; }
        
    }
}