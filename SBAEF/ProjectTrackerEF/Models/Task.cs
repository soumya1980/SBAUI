using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerEF.Models
{
    public class Task
    {
        [Key]
        public int Task_ID { get; set; }
        public ParentTask ParentTask { get; set; }
        public Project Project { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDt { get; set; }
        public DateTime EndDt { get; set; }
        public int Priority { get; set; }
        public string Status { get; set; }

    }
}
