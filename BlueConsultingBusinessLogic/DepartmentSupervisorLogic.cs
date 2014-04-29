using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BlueConsultingBusinessLogic
{
    public class DepartmentSupervisorLogic
    {
        private DatabaseAccess databaseAccess = new DatabaseAccess();
        List<Report> reports = new List<Report>();
        public string Username { get; private set; }
        public Department Department { get; private set; }

        public DepartmentSupervisorLogic(string username)
        {
            this.Username = username;
            loadDepartment();
            fillReport();
        }

        private void loadDepartment()
        {
            Department = new Department(databaseAccess.getDepartmentName(Username));
        }

        public double getApproveAmount()
        {
            double sum = 0;
            String approved = Report.ReportStatuses.ApprovedByDepartmentSupervisor.ToString();
            String finalApproved = Report.ReportStatuses.ApprovedByAccountStaff.ToString();
            
            foreach (Report report in reports)
            {
                if (report.ReportStatus.Equals(approved) || report.ReportStatus.Equals(finalApproved))
                {
                    sum += report.calculateExpenseInAUD();
                }
            }
            return sum;
        }

        public void changeReportStatus(string Id, string status)
        {
            databaseAccess.changeReportStatus(Id, status);
            databaseAccess.updateSupervisorName(Id, Username); 
        }

        private void fillReport()
        {
            DataTable dt = databaseAccess.loadReportForDepartment(Username);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["Id"].ToString();
                reports.Add(new Report(id));
            }
        }
    }
}
