using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectTrackerAPI.ADO
{
    public class ProjectDAL
    {
        readonly SqlConnection conn;
        SqlCommand cmd;
        string strConn = "Data Source=DOTNET;Initial Catalog=ProjectTrack;Integrated Security=True";
        public ProjectDAL()
        {
            conn = new SqlConnection(strConn);
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public List<ProjectDTO> GetAllProjectsAndStatus()
        {
            var projectList = new List<ProjectDTO>();
            try
            {
                cmd.CommandText = "fsd_getprojectsandstatus";
                using (conn)
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        projectList.Add(new ProjectDTO
                        {
                            EndDate = ((DateTime)rdr["EndDt"]).ToString("MM/dd/yyyy"),
                            ProjectID = (Int32)rdr["Project_Project_ID"],
                            Priority = (Int32)rdr["Priority"],
                            ProjectDesc = (String)rdr["ProjectDesc"],
                            StartDate = ((DateTime)rdr["StartDt"]).ToString("MM/dd/yyyy"),
                            Status = (String)rdr["Status"],
                            TaskNos = (Int32)rdr["TaskNos"]
                        });
                    }
                    conn.Close();
                }
                return projectList;
            }
            catch (Exception ex)
            {

            }
            return projectList;
        }
    }
}