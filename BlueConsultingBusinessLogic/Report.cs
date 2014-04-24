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
            DataRow d = dataTable.Rows[0];
            ReportStatus = d["ReportStatus"].ToString();
            Date = d["Date"].ToString();
        }

        public String PrintReport()
        {
            return String.Format("{0},{1},{2},{3}", ReportID, ReportStatus, Date, ConsultantID);
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
            expenses = new List<Expense>();

            foreach (DataRow d in dataTable.Rows)
            {
                Expense expense = new Expense();

                expense.Location = d["Location"].ToString();
                expense.Description = d["Description"].ToString();
                expense.Currency = d["Currency"].ToString();
                expense.Amount = Convert.ToInt32(d["Amount"].ToString());
                expense.ReportID = Convert.ToInt32(d["ReportID"].ToString());

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

        public double calculateTotalExpenses()
        {
            double sum = 0;
            foreach (Expense expense in expenses)
            {
                sum += expense.getAmount();
            }

            return sum;
        }

        public void Submit()
        {
            var insertCommand = new SqlCommand(@"INSERT Into Reports (DepartmentSupervisorID, ConsultantID, ReportStatus, Receipt, Date)
            VALUES (@DepartmentSupervisorID, @ConsultantID, @ReportStatus, @Receipt, @Date)");

            insertCommand.Parameters.Add("@DepartmentSupervisorID", SqlDbType.VarChar).Value = DepartmentSupervisorID;
            insertCommand.Parameters.Add("@ConsultantID", SqlDbType.VarChar).Value = ConsultantID;
            insertCommand.Parameters.Add("@ReportStatus", SqlDbType.VarChar).Value = ReportStatus;
            insertCommand.Parameters.Add("@Receipt", SqlDbType.VarBinary).Value = Receipt; //for testing this is null
            insertCommand.Parameters.Add("@Date", SqlDbType.VarChar).Value = Date;
            databaseAccess.insertToDatabase(insertCommand);  
            submitExpense(); 
        }

        public void submitExpense()
        {
            foreach (Expense expense in expenses)
            {
                expense.submit();
            }
        }

        public int NewReportID()
        {
            SqlCommand command = new SqlCommand("SELECT Id FROM Reports ORDER BY Id DESC");
            DataTable dt = databaseAccess.getDataTable(command); //get last id in table

            int reportID = Convert.ToInt32(dt.Rows[0]["Id"].ToString()) + 1; //get largest value

            return reportID;
        }
    }
}
