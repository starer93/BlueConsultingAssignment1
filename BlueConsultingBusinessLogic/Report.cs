using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace BlueConsultingBusinessLogic
{
    public class Report
    {
        List<Expense> expenses = new List<Expense>();
        public String ConsultantID { get; set; } //later on, we need to get this from database
        public String ReportID { get; set; }
        private DatabaseAccess databaseAccess = new DatabaseAccess();

        public String DepartmentSupervisorID { get; set; }
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

        public Report()
        {

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

        public int numberOfExpenses()
        {
            return expenses.Count;
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

        public List<Expense> GetExpensesFromDB()
        {
            var command = new SqlCommand("Select * From Expenses where ReportID = @id");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = ReportID;
            DataTable dataTable = databaseAccess.getDataTable(command);

            foreach (DataRow d in dataTable.Rows)
            {
                Expense expense = new Expense();
                //get report id

                //expense.Amount = Convert.ToDouble(d["Amount"].ToString()); //stores entire expense row
                expense.Location = d["Location"].ToString();
                expenses.Add(expense);
            }
            return expenses;
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
