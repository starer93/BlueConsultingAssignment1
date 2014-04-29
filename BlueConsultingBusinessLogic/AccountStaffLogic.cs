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
        DatabaseAccess databaseAccess = new DatabaseAccess();

        public AccountStaffLogic()
        {
            SqlCommand command = new SqlCommand("Select RoleID From aspnet_Roles where RoleName='department supervisor'");
            DataTable da = databaseAccess.getDataTable(command);
            string supervisorId = da.Rows[0]["RoleID"].ToString();
            command = new SqlCommand("Select aspnet_Users.UserName From aspnet_Users Inner Join aspnet_UsersInRoles on aspnet_Users.UserId = aspnet_UsersInRoles.UserId where aspnet_UsersInRoles.RoleId =@Id ");
            //Select * From Reports Inner Join aspnet_Users on reports.ConsultantID = aspnet_users.Username where DepartmentName = @deptName"
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = supervisorId;
            DataTable supervisorDa = databaseAccess.getDataTable(command);
            List<string> username = new List<string>();
            foreach (DataRow row in supervisorDa.Rows)
            {
                var userId = row["UserName"].ToString();
                username.Add(userId);
            }
            foreach (string id in username)
            {
                ds.Add(new DepartmentSupervisorLogic(id));
            }

            fillDepartment();
            fillReports();
        }

        private void fillDepartment()
        {
            for (int i = 0; i < NUMBER_OF_Department; i++)
            {
                departments.Add(new Department(i));
            }
        }
        public List<Department> getDepartments()
        {
            return departments;
        }

        private void fillReports()
        {
            SqlCommand command = new SqlCommand("Select Id From Reports where ReportStatus = @status");
            command.Parameters.Add("@status", SqlDbType.VarChar).Value = Report.ReportStatuses.ApprovedByDepartmentSupervisor.ToString();
            DataTable dt = databaseAccess.getDataTable(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["Id"].ToString();
                reports.Add(new Report(id));
            }
        }

        //public List<Report> getApproveReport()
        //{
        //    SqlCommand command = new SqlCommand("Select Id From Reports where ReportStatus = @status");
        //    command.Parameters.Add("@status", SqlDbType.VarChar).Value = Report.ReportStatuses.ApprovedByDepartmentSupervisor.ToString();
        //    DataTable dt = databaseAcess.getDataTable(command);
        //    List<Report> approvedReports = new List<Report>();
        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        string id = dt.Rows[i]["Id"].ToString();
        //        approvedReports.Add(new Report(id));
        //    }
        //    return approvedReports;
        //}

        public void update(string Id, string status)
        {
            databaseAccess.updateReport(Id, status);
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
