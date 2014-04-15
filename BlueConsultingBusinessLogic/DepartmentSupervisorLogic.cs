using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingBusinessLogic
{
    public class DepartmentSupervisorLogic
    {
        private string username;
        private Department department;
        private DatabaseAccess databaseAccess = new DatabaseAccess();

        public string Username 
        {
            get
            {
                return username;
            }
        }
        public Department Department 
        {
            get
            {
                return department;
            }
        }

        public DepartmentSupervisorLogic(string username)
        {
            this.username = username;
            loadDepartment();
        }

        private void loadDepartment()
        {
            department = new Department(databaseAccess.getDepartmentName(username));
        }

        public List<Report> loadAllReports()
        {
            DataTable dataTable = databaseAccess.getDepartmentReports(department.Name);
            List<Report> reports = new List<Report>();
            foreach (DataRow d in dataTable.Rows)
            {
                Report report = new Report();
                //get report id

                report.ReportID = d["Id"].ToString();
                reports.Add(report);
            }
            return reports;
        }

    }
}
