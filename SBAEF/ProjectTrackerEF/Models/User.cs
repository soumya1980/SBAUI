using System.ComponentModel.DataAnnotations;

namespace ProjectTrackerEF.Models
{
    public class User
    {
        [Key]
        public int User_ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Employee_ID { get; set; }
        public Project Project { get; set; }
        public Task Task { get; set; }
        public bool IsMgr { get; set; }
    }
}
