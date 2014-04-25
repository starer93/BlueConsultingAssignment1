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
        //private double remainingBudget = 0;
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
        /*
        public Department(int index)
        {
            remainingBudget = MONTHLY_BUDGET;
        }*/

        public Department(string departmentName)
        {
            name = departmentName;
        }

        public void updateDepartmentReports(string month, string year)
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
                report.LoadExpensesFromDB();
                reports.Add(report);
            }
        }

        public double TotalExpense(string month, string year)
        {
            List<Report> filteredReport = filterReport(reports, month, year);
            double sum = 0;
            foreach (Report report in filteredReport)
            {
                if (report.ReportStatus.Equals("ApprovedByDepartmentSupervisor") || report.ReportStatus.Equals("ApprovedByAccountStaff"))
                {
                    sum += report.calculateExpenseInAUD();
                }
            }
            return sum;
        }

        public List<Report> getDepartmentReports(string month, string year)
        {
            List<Report> filteredReport = filterReport(reports, month, year);
            return filteredReport;
        }

        public List<Report> getPendingReports(string month, string year)
        {
            List<Report> pendingReports = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ReportStatus == "SubmittedByConsultant")
                {
                    pendingReports.Add(report);
                }
            }

            List<Report> filteredReport = filterReport(pendingReports, month, year);
            return filteredReport;
        }

        public List<Report> getApprovedReports(string month, string year)
        {
            List<Report> approvedReports = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ReportStatus == "ApprovedByDepartmentSupervisor")
                {
                    approvedReports.Add(report);
                }
            }
            List<Report> filteredReport = filterReport(approvedReports, month, year);
            return filteredReport;
        }

        public List<Report> getRejectedReports(string month, string year)
        {
            List<Report> rejectedReports = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ReportStatus == "RejectedByDepartmentSupervisor")
                {
                    rejectedReports.Add(report);
                }
            }
            List<Report> filteredReport = filterReport(rejectedReports, month, year);
            return filteredReport;
        }

        public List<Report> getRejectedByAccountStaffReports(string month, string year)
        {
            List<Report> rejectedReports = new List<Report>();
            foreach (Report report in reports)
            {
                if (report.ReportStatus == "RejectedByAccountStaff")
                {
                    rejectedReports.Add(report);
                }
            }
            List<Report> filteredReport = filterReport(rejectedReports, month, year);
            return filteredReport;
        }

        private List<Report> filterReport(List<Report> originalReport, string month, string year)
        {
            List<Report> filteredReport = new List<Report>();
            string period = month + "/" + year;
            foreach (Report report in originalReport)
            {
                if (report.Date.Substring(3).Equals(period))
                {
                    filteredReport.Add(report);
                }
            }
            return filteredReport;
        }

        public string getName()
        {
            return name;
        }

        public double getTotalBudget()
        {
            return MONTHLY_BUDGET;
        }

        public double getRemainingBudget(string month, string year)
        {
            return MONTHLY_BUDGET - TotalExpense(month, year);
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
