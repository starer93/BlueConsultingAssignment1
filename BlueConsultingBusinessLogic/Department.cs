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
        private double remainingBudget = 0;
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
            switch (index)
            {
                case 0: name = "State Services"; break;
                case 1: name = "Logistics Services"; break;
                case 2: name = "Higher Education"; break;
                default: name = "none"; break;
            }
            fillReports();
        }

        public Department(string departmentName)
        {
            name = departmentName;
            fillReports();
        }

        private void fillReports()
        {
            DataTable dataTable = databaseAccess.getDepartmentReports(name);
            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["Id"].ToString();
                Report report = new Report(id);
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

        public int numberOfExpenses()
        {
            int numberOfExpenses = 0;
            foreach (Report report in reports)
            {
                if(report.ReportStatus.Equals("ApprovedByDepartmentSupervisor") || report.ReportStatus.Equals("ApprovedByAccountStaff"))
                {
                    numberOfExpenses += report.GetExpenses().Count;
                }
            }

            return numberOfExpenses;
        }

        public List<Report> getDepartmentReports(string month, string year, string status)
        {
            List<Report> listedReport = filterReport(reports, month, year);
            List<Report> newReports = new List<Report>();
            foreach (Report report in listedReport)
            {
                if (report.ReportStatus == status)
                {
                    newReports.Add(report);
                }
            }
            return newReports;
        }

        public List<Report> getDepartmentReports(string month, string year)
        {
            List<Report> listedReport = filterReport(reports, month, year);
            List<Report> newReports = new List<Report>();
            foreach (Report report in listedReport)
            {
                if (report.ReportStatus.Equals(Report.ReportStatuses.SubmittedByConsultant.ToString()) || report.ReportStatus.Equals(Report.ReportStatuses.RejectedByAccountStaff.ToString()))
                {
                    newReports.Add(report);
                }
            }
            listedReport = filterReport(listedReport, month, year);
            return newReports;
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
            int i = originalReport.Count;
            int s = originalReport.Count;
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
            remainingBudget = MONTHLY_BUDGET - TotalExpense(month, year);
            return remainingBudget;
        }

        public bool willBeOverBudget(Report report)
        {
            return (remainingBudget + report.calculateExpenseInAUD()) > MONTHLY_BUDGET;
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

        public double getTotalExpense()
        {
            double sum = 0;
            foreach (Report report in reports)
            {
                sum += report.calculateExpenseInAUD();
            }
            return sum;
        }
    }
}
