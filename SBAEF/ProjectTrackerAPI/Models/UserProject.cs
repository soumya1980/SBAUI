using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectTrackerAPI.Models
{
    public class UserProject
    {
        public ProjectTrackerEF.Models.Project userProject { get; set; }
        public string employyeId { get; set; }
    }
}