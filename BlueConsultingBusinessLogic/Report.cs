using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web;
namespace BlueConsultingBusinessLogic
{
    public class Report
    {
        private DatabaseAccess databaseAccess = new DatabaseAccess();
        List<Expense> expenses = new List<Expense>();

        public String ReportID { get; set; }
        public String DepartmentSupervisorID { get; set; } 
        public String ConsultantID { get; set; }
        public String ReportStatus { get; set; }
        public String Date { get; set; }
        public byte[] Receipt { get; set; } //this needs to be a byte


        public enum ReportStatuses
        {
            SubmittedByConsultant,
            ApprovedByDepartmentSupervisor, 
            RejectedByDepartmentSupervisor, 
            ApprovedByAccountStaff, 
            RejectedByAccountStaff
        };

        public Report()
        {
            //instantitate report
        }

        public Report(string id)
        {
            ReportID = id;
            LoadExpensesFromDB();
            fillReport();
        }

        public void fillReport()
        {
            SqlCommand command = new SqlCommand("Select * From Reports where Id = @id");
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = ReportID;
            DataTable dataTable = databaseAccess.getDataTable(command);
            DataRow row = dataTable.Rows[0];
            ReportStatus = row["ReportStatus"].ToString();
            Date = row["Date"].ToString();
            if (row["Receipt"] != DBNull.Value)
            {
                Receipt = (byte[])row["Receipt"];
            }
            DepartmentSupervisorID = row["DepartmentSupervisorID"].ToString();
        }

        public String PrintReport()
        {
            return String.Format("{0}, {1}, {2}", ReportID, ReportStatus, Date);
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        public void LoadExpensesFromDB()
        {
            SqlCommand command = new SqlCommand("Select * From Expenses where ReportID = @id");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = ReportID;

            DataTable dataTable = databaseAccess.getDataTable(command);
            foreach (DataRow d in dataTable.Rows)
            {
                Expense expense = new Expense();

                expense.Location = d["Location"].ToString();
                expense.Description = d["Description"].ToString();
                expense.Currency = d["Currency"].ToString();
                expense.Amount = Convert.ToDouble(d["Amount"].ToString());
                expense.ReportID = d["ReportID"].ToString();
                expenses.Add(expense);
            }
        }

        public List<Expense> GetExpenses()
        {
            return expenses;
        }

        public int numberOfExpenses()
        {
            return expenses.Count;
        }

        public double calculateExpenseInAUD()
        {
            double sum = 0;
            foreach (Expense expense in expenses)
            {
                sum += expense.calculateExpenseInAUD();
            }

            return sum;
        }

        public double getTotalReportAmount()
        {
            double sum = 0;
            foreach (Expense expense in expenses)
            {
                sum += expense.Amount;
            }

            return sum;
        }

        public byte[] GetReceipt(HttpPostedFile file)
        {
            //FileInfo fileInfo = new FileInfo(filePath);           
            int length = file.ContentLength;
            byte[] data = new byte[length];
            //FileStream fileStream = new FileStream(filePath, FileMode.Open);
            file.InputStream.Read(data, 0, length);
            return data;
        }

        public void submit()
        {
            databaseAccess.SubmitReport(DepartmentSupervisorID, ConsultantID, ReportStatus,Receipt, Date);
            //submitExpense(); 
            ReportID = databaseAccess.GetReportID();
        }

        public void submitExpense()
        {
            foreach (Expense expense in expenses)
            {
                expense.submit();
            }
        }

    }
}
