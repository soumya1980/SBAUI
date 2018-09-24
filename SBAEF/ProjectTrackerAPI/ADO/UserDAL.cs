using ProjectTrackerEF.Models;
using System;
using System.Data;
using System.Data.SqlClient;

namespace ProjectTrackerAPI.ADO
{
    public class UserDAL
    {
        readonly SqlConnection conn;
        SqlCommand cmd;
        string strConn = "Data Source=DOTNET;Initial Catalog=ProjectTrack;Integrated Security=True";
        public UserDAL()
        {
            conn = new SqlConnection(strConn);
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public string UpdateUser(int employeeid,int projectid)
        {
            try
            {
                var tempds = new DataSet();
                cmd.CommandText = "fsd_updateuserwithproject";
                cmd.Parameters.Add(new SqlParameter("@employeeId", employeeid));
                cmd.Parameters.Add(new SqlParameter("@projectId", projectid));
                using (conn)
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "FAIL";
            }
        }

        public string UpdateTaskWithParent(int projectid, int parentTaskId, Task taskdata,int userId)
        {
            try
            {
                cmd.CommandText = "fsd_addtaskwithparent";
                cmd.Parameters.Add(new SqlParameter("@parentTaskId", parentTaskId));
                cmd.Parameters.Add(new SqlParameter("@projectId", projectid));

                cmd.Parameters.Add(new SqlParameter("@taskName", taskdata.TaskName));
                cmd.Parameters.Add(new SqlParameter("@startDt", taskdata.StartDt));
                cmd.Parameters.Add(new SqlParameter("@endDt", taskdata.EndDt));
                cmd.Parameters.Add(new SqlParameter("@priority", taskdata.Priority));
                cmd.Parameters.Add(new SqlParameter("@status", taskdata.Status));
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                using (conn)
                {
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "FAIL";
            }
        }
        public string UpdateTask(int projectid, int? parentTaskId,int taskId,int userId)
        {
            try
            {
                int recdupdated = 0;
                var tempds = new DataSet();
                cmd.CommandText = "fsd_updatetaskwithprojectandparent";
                cmd.Parameters.Add(new SqlParameter("@taskId", taskId));
                cmd.Parameters.Add(new SqlParameter("@projectId", projectid));
                cmd.Parameters.Add(new SqlParameter("@userId", userId));
                if (parentTaskId == null)
                {
                    cmd.Parameters.Add(new SqlParameter("@parentTaskId", DBNull.Value));
                }
                else
                {
                    cmd.Parameters.Add(new SqlParameter("@parentTaskId", parentTaskId));
                }
                using (conn)
                {
                    conn.Open();
                    recdupdated = cmd.ExecuteNonQuery();
                    conn.Close();
                }
                return "SUCCESS";
            }
            catch (Exception ex)
            {
                return "FAIL";
            }
        }
    }
}