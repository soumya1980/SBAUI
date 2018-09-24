using System;
using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerEF.Models
{
    public class Project
    {
        [Key]
        public int Project_ID { get; set; }
        public string ProjectDesc { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public int Priority { get; set; }

    }
}
