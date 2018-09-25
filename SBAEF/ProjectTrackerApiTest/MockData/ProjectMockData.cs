using ProjectTrackerAPI.ADO;
using ProjectTrackerAPI.Models;
using ProjectTrackerEF.Models;
using System;
using System.Collections.Generic;

namespace ProjectTrackerApiTest.MockData
{
    public class ProjectMockData
    {
        public static List<Project> GetProjectsResponse()
        {
            var lstResponse = new List<Project>();
            lstResponse.Add(new Project
            {
                Project_ID=1,
                ProjectDesc="AML",
                Priority=1,
                StartDt= DateTime.Now,
                EndDt= DateTime.Now
            });
            lstResponse.Add(new Project
            {
                Project_ID = 2,
                ProjectDesc = "USPS",
                Priority = 2,
                StartDt = DateTime.Now,
                EndDt = DateTime.Now
            });
            lstResponse.Add(new Project
            {
                Project_ID = 3,
                ProjectDesc = "UPS",
                Priority = 1,
                StartDt = DateTime.Now,
                EndDt = DateTime.Now
            });

            return lstResponse;
        }
        public static Project GetProjectResponse()
        {
            return new Project
            {
                Project_ID = 1,
                ProjectDesc = "AML",
                Priority = 1,
                StartDt = DateTime.Now,
                EndDt = DateTime.Now
            };
        }
        public static UserProject newprojectRequest()
        {
            return new UserProject
            {
                employyeId="1",
                userProject=new Project
                {
                    ProjectDesc="Test Project",
                    Priority=1,
                    StartDt= DateTime.Now,
                    EndDt= DateTime.Now
                }
            };
        }
        public static List<ProjectDTO> GetProjectAndStatus()
        {
            var lstResponse = new List<ProjectDTO>();
            lstResponse.Add(new ProjectDTO
            {
                ProjectID=1,
                ProjectDesc = "AML",
                Priority = 1,
                StartDate = "09/21/2008",
                EndDate = "10/21/2008",
                Status="OPEN",
                TaskNos=3
            });
            lstResponse.Add(new ProjectDTO
            {
                ProjectID = 2,
                ProjectDesc = "USPS",
                Priority = 1,
                StartDate = "09/21/2008",
                EndDate = "10/21/2008",
                Status = "OPEN",
                TaskNos = 0
            });
            lstResponse.Add(new ProjectDTO
            {
                ProjectID = 3,
                ProjectDesc = "UPS",
                Priority = 1,
                StartDate = "09/21/2008",
                EndDate = "10/21/2008",
                Status = "OPEN",
                TaskNos = 2
            });

            return lstResponse;
        }
    }
}
