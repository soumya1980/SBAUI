using ProjectTrackerEF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTrackerApiTest.MockData
{
    public class UserMockData
    {
        public static List<User> GetUsersResponse()
        {
            var lstResponse = new List<User>();
            lstResponse.Add(new User
            {
                Employee_ID=100,FirstName="Soumya",LastName="Moharana",IsMgr=false,User_ID=1
            });
            lstResponse.Add(new User
            {
                Employee_ID = 101,
                FirstName = "Snigdha",
                LastName = "Jena",
                IsMgr = true,
                User_ID = 2
            });
            lstResponse.Add(new User
            {
                Employee_ID = 102,
                FirstName = "Mothun",
                LastName = "Mohapatra",
                IsMgr = false,
                User_ID = 3
            });
            
            return lstResponse;
        }
    }
}
