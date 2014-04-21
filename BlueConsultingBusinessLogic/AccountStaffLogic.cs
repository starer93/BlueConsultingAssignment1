using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BlueConsultingBusinessLogic
{

    public class AccountStaffLogic
    {
        List<Report> reports = new List<Report>();
        List<Department> departments = new List<Department>();
        List<DepartmentSupervisorLogic> ds = new List<DepartmentSupervisorLogic>();
        DatabaseAccess da = new DatabaseAccess();
        private const int NUMBER_OF_Department = 3;
        DatabaseAccess databaseAcess = new DatabaseAccess();

        public AccountStaffLogic()
        {
            SqlCommand command = new SqlCommand("Select RoleID From aspnet_Roles where RoleName='department supervisor'");
            DataTable da = databaseAcess.getDataTable(command);
            string supervisorId = da.Rows[0]["RoleID"].ToString();
            command = new SqlCommand("Select UserId From aspnet_UsersInRoles where RoleID=@Id");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = supervisorId;
            DataTable supervisorDa = databaseAcess.getDataTable(command);
            List<string> userID = new List<string>();
            foreach (DataRow row in supervisorDa.Rows)
           {
               var userId = row["UserID"].ToString();
               userID.Add(userId);
           }
            foreach (string id in userID)
            {
                ds.Add(new DepartmentSupervisorLogic(id));
            }


            fillReports();
        }


        private void fillReports()
        {
            SqlCommand command = new SqlCommand("Select Id From Reports where ReportStatus = @status");
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = "submit";
            DataTable dt = databaseAcess.getDataTable(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["Id"].ToString();
                reports.Add(new Report(id));
                
            }
        }

        public List<DepartmentSupervisorLogic> getSupervisor()
        {
            return ds;
        }

        public List<Report> getReports()
        {
            return reports;
        }

    }
}
