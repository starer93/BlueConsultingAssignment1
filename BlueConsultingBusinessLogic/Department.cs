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
        private const double MONTHLY_BUDGET = 10000;
        private double remainingBudget = 0;
        internal DatabaseAccess databaseAccess = new DatabaseAccess();
        private List<ConsultantLogic> consultants = new List<ConsultantLogic>();
        private List<Report> reports = new List<Report>();
        public string Name {get; private set;}
        
        //Initialization ---------------------------------

        public Department(int index)
        {
            remainingBudget = MONTHLY_BUDGET;
            switch (index)
            {
                case 0: Name = "State Services"; break;
                case 1: Name = "Logistics Services"; break;
                case 2: Name = "Higher Education"; break;
                default: Name = "None"; break;
            }
            fillReports();
        }

        public Department(int index, DatabaseAccess databaseAccess)
        {
            remainingBudget = MONTHLY_BUDGET;
            switch (index)
            {
                case 0: Name = "State Services"; break;
                case 1: Name = "Logistics Services"; break;
                case 2: Name = "Higher Education"; break;
                default: Name = "None"; break;
            }
            this.databaseAccess = databaseAccess;
            fillReports();
        }

        public Department(string departmentName)
        {
            Name = departmentName;
            fillReports();
        }

        private void fillReports()
        {
            DataTable dataTable = databaseAccess.getDepartmentReports(Name);
            foreach (DataRow row in dataTable.Rows)
            {
                string id = row["Id"].ToString();
                Report report = new Report(id);
                report.fillReport();
                reports.Add(report);
            }
        }

        //Expense calculation ----------------------------

        public double TotalExpense(string month, string year)
        {
            List<Report> filteredReport = filterReport(reports, month, year);
            double sum = 0;
            foreach (Report report in filteredReport)
            {
                if (IsApproved(report))
                {
                    sum += report.calculateExpenseInAUD();
                }
            }
            return sum;
        }

        private bool IsApproved(Report report)
        {
            return report.ReportStatus.Equals("ApprovedByDepartmentSupervisor") || report.ReportStatus.Equals("ApprovedByAccountStaff");
        }

        //Report filters --------------------------------

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
                if (IsSubmittedOrRejected(report))
                {
                    newReports.Add(report);
                }
            }
            return newReports;
        }

        private bool IsSubmittedOrRejected(Report report)
        {
            bool isSubmittedByConsultant = report.ReportStatus.Equals(Report.ReportStatuses.SubmittedByConsultant.ToString());
            bool isRejectedByAccountStaff = report.ReportStatus.Equals(Report.ReportStatuses.RejectedByAccountStaff.ToString());
            return isSubmittedByConsultant || isRejectedByAccountStaff;
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

        //Budgeting -------------------------------------

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
            return (remainingBudget < report.calculateExpenseInAUD());
        }

        private bool isApproved(string status)
        {
            return status.Equals(Report.ReportStatuses.ApprovedByAccountStaff.ToString()) || status.Equals(Report.ReportStatuses.ApprovedByDepartmentSupervisor.ToString());
        }

        public double getTotalExpense()
        {
            double sum = 0;
            foreach (Report report in reports)
            {
                if (isApproved(report.ReportStatus))
                {
                    sum += report.calculateExpenseInAUD();
                }
            }
            return sum;
        }
    }
}
