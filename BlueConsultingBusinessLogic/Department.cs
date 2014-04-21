using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BlueConsultingBusinessLogic
{
    public class Department
    {
        private string name;
        private const double MONTHLY_BUDGET = 10000;
        private double remainingBudget;
        private List<DepartmentSupervisorLogic> supervisors = new List<DepartmentSupervisorLogic>();
        private DatabaseAccess databaseAccess = new DatabaseAccess();
        private List<ConsultantLogic> consultants = new List<ConsultantLogic>();
        private List<Report> reports = new List<Report>();

        public string Name 
        {
            get
            {
                return name;
            }
        }

        public Department(int index)
        {
            remainingBudget = MONTHLY_BUDGET;
        }

        public Department(string departmentName)
        {
            name = departmentName;
            updateCurrentBudget();
        }

        public void updateDepartmentReports()
        {
            DataTable dataTable = databaseAccess.getDepartmentReports(name);
            foreach (DataRow row in dataTable.Rows)
            {
                Report report = new Report();
                report.ReportID = row["Id"].ToString();
                report.ReportStatus = row["ReportStatus"].ToString();
                report.Date = row["Date"].ToString();
                report.ConsultantID = row["ConsultantID"].ToString();
                //report.PDF = 
                reports.Add(report);
            }
            updateCurrentBudget();
        }

        private void updateCurrentBudget()
        {
            //LOOPS THROUGH THE REPORTS LIST AND GET NEW CURRENT BUDGET
        }

        public List<Report> getDepartmentReports()
        {
            return reports;
        }

        public List<Report> getPendingReports()
        {
            List<Report> pendingReports = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ReportStatus == "pending")
                {
                    pendingReports.Add(report);
                }
            }
            return pendingReports;
        }

        public List<Report> getApprovedReports()
        {
            List<Report> approvedReports = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ReportStatus == "approve")
                {
                    approvedReports.Add(report);
                }
            }
            return approvedReports;
        }

        public List<Report> getRejectedReports()
        {
            List<Report> rejectedReports = new List<Report>();
            //Loop through list and get rejected reports
            return rejectedReports;
        }

        public List<Report> getRejectedByAccountStaffReports()
        {
            List<Report> rejectedReports = new List<Report>();
            //Loop through list and get rejected reports
            return rejectedReports;
        }

        public string getName()
        {
            return name;
        }

        public double getTotalBudget()
        {
            return MONTHLY_BUDGET;
        }

        public double getRemainingBudget()
        {
            return remainingBudget;
        }
        public double getExpensesApproved()
        {
            return 0;
        }

        //Search a report based on the report ID
        public Report getReport(string reportID)
        {
            Report searchedReport = null;
            foreach (Report report in reports)
            {
                if (report.ReportID == reportID)
                {
                    searchedReport = report;
                }
            }
            return searchedReport;
        }
    }
}
