using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;

namespace BlueConsultingBusinessLogic
{
    public class AccountStaff
    {
        List<Report> reports = new List<Report>();
        List<Department> departments = new List<Department>();
        DatabaseAccess da = new DatabaseAccess();
        DataSet dataset = new DataSet();
        private const int NUMBER_OF_Department = 3;
        DatabaseAccess databaseAcess = new DatabaseAccess();

        public AccountStaff()
        {
            DataTable da = databaseAcess.getDataTable("Select RoleID From aspnet_Roles where RoleName='Account Staff'");
            string Id = da.Rows[0]["RoleID"].ToString();

          ////  DataTable supervisorDa = databaseAcess.getUserId("Select UserId From aspnet_UsersInRoles where RoleID=@Id", Id);
          //  List<string> superivsorID = new List<string>();
          //  foreach (DataRow row in supervisorDa.Rows)
          //  {
          //      var userId = row["UserID"].ToString();
          //      superivsorID.Add(userId);
          //  }


            for (int i = 0; i < NUMBER_OF_Department; i++)
            {
                departments.Add(new Department(i));
            }

        }


        private void fillReports()
        {
            string command = "Select * From Reports where ReportStatus LIKE @status";
            string para = "ok";
            DataTable dt = new DataTable();
            dataset= da.getReports(command, para);
            dt = dataset.Tables[0];
            for (int i = 0; i < dataset.Tables[0].Rows.Count; i++)
            {
                var data = dataset.Tables[0].Rows[i]["ID"].ToString();
            }
        }

        public List<Department> getDepartments()
        {
            return departments;
        }

    }
}
