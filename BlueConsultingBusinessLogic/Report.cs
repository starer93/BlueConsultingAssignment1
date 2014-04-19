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

        public String ConsultantID { get; set; } 
        public String ReportID { get; set; }
        public String ReportStatus { get; set; }
        public String Date { get; set; }
        public Image PDF { get; set; } //this should be in expenses

        public String DepartmentSupervisorID { get; set; } //why?

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

        public String PrintReport()
        {
            return String.Format("{0},{1},{2},{3}", ReportID, ReportStatus, Date, ConsultantID);
        }

        public void AddExpense(Expense expense)
        {
            expenses.Add(expense);
        }

        private void fillReport()
        {
            SqlCommand command = new SqlCommand("Select * From Reports where Id = @id");
            command.Parameters.Add("@id", SqlDbType.VarChar).Value = ReportID;
            DataTable dataTable = databaseAccess.getDataTable(command);
            DataRow d = dataTable.Rows[0];
            ReportStatus = d["ReportStatus"].ToString();
            Date = d["Date"].ToString();
        }
        
        public void LoadExpensesFromDB()
        {
            SqlCommand command = new SqlCommand("Select * From Expenses where ReportID = @Id");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = ReportID;

            DataTable dataTable = databaseAccess.getDataTable(command);
            expenses = new List<Expense>();

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

        public double calculateTotalExpenses()
        {
            double sum = 0;
            foreach (Expense expense in expenses)
            {
                sum += expense.getAmount();
            }

            return sum;
        }
    }
}
