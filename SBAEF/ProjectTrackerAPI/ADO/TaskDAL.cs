using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProjectTrackerAPI.ADO
{
    public class TaskDAL
    {
        readonly SqlConnection conn;
        SqlCommand cmd;
        string strConn = "Data Source=DOTNET;Initial Catalog=ProjectTrack;Integrated Security=True";
        public TaskDAL()
        {
            conn = new SqlConnection(strConn);
            cmd = conn.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
        }
        public List<TaskDTO> GetAllTasks()
        {
            var taskList = new List<TaskDTO>();
            try
            {
                cmd.CommandText = "fsd_gettasks";
                using (conn)
                {
                    conn.Open();
                    var rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        taskList.Add(new TaskDTO
                        {
                            EndDate=(DateTime)rdr["StartDt"],
                            ParentTaskID= rdr["Parent_ID"].ToString() ==string.Empty?0:(Int32)rdr["Parent_ID"],
                            Priority=(Int32)rdr["Priority"],
                            ProjectDesc=(String)rdr["ProjectDesc"],
                            ProjectID=(Int32)rdr["Project_ID"],
                            StartDate=(DateTime)rdr["EndDt"],
                            Status=(String)rdr["Status"],
                            TaskID=(Int32)rdr["Task_ID"],
                            TaskName=(String)rdr["TaskName"],
                            ParentTask=rdr["Parent_Task"].ToString() == string.Empty?string.Empty:(String)rdr["Parent_Task"]
                        });
                    }
                    conn.Close();
                }
                return taskList;
            }
            catch (Exception ex)
            {
                
            }
            return taskList;
        }
    }
}