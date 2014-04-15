using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace BlueConsultingBusinessLogic
{
    public class Report
    {
        List<Expense> expenses = new List<Expense>();
        public String ConsultantID { get; set; } //later on, we need to get this from database
        public String DepartmentSupervisorID { get; set; }
        //public String ReportDate { get; set; }
        public String ReportStatus { get; set; }
        public Image PDF { get; set; }
        public Report(string ConsultantID, string ReportStatus, string ReceiptPdfFilePath)
        {
            this.ConsultantID = ConsultantID;
            this.ReportStatus = ReportStatus;
            if (ReceiptPdfFilePath != null)
            {
                this.PDF = Image.FromFile(ReceiptPdfFilePath);
            }
            else
            {
                this.PDF = null;
            }
            
            this.DepartmentSupervisorID = null;
        }

        public Report(ReportDataSet reportDataSet)
        {
            //this.ConsultantID=reportDataSet.
        }
        public void addExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public List<Expense> getExpenses()
        {
            //return list of expenses
            return expenses;
        }

        public double getTotalExpenses()
        {
            double sum = 0;
            foreach (Expense expense in expenses)
            {
                sum += expense.getAmount();
            }
            return sum;
        }

        //public submitReport
        /*
        public String getFormattedReport()
        {
            String header = String.Format("{0}, {1}", ConsultantID, ReportDate);
            String body = "\nExpenses: ";

            foreach (Expense expense in expenses)
            {
                body += expense.GetExpense(); //can't seem to get expenses
            }

            return header + body;
        }
         */

        
    }
}
