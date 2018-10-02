using ProjectTrackerEF.Models;
using System.Collections.Generic;

namespace PerformanceTest
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
        public static User GetUserResponse()
        {
            return new User
            {
                Employee_ID = 100,
                FirstName = "Soumya",
                LastName = "Moharana",
                IsMgr = false,
                User_ID = 1
            };
        }
        public static User userRequest()
        {
            return new User
            {
                Employee_ID = 100,
                FirstName = "Soumya",
                LastName = "Moharana",
                IsMgr = false,
                User_ID = 1
            };
        }
        public static User newUserRequest()
        {
            return new User
            {
                Employee_ID = 100,
                FirstName = "Soumya",
                LastName = "Moharana"
            };
        }
    }
}
