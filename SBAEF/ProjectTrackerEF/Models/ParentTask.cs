using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerEF.Models
{
    public class ParentTask
    {
        [Key]
        public int Parent_ID { get; set; }
        public string Parent_Task { get; set; }
    }
}
