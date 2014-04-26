using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using BlueConsultingBusinessLogic;
using System.Data;

namespace BlueConsultingBusinessLogic
{
    public class DatabaseAccess
    {
        private static string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        private SqlConnection connection = new SqlConnection(connectionString);

        public DataTable getDataTable(SqlCommand command)
        {
            command.Connection = connection;
            var adapter = new SqlDataAdapter(command);
            var resultSet = new DataTable();
            adapter.Fill(resultSet);
            connection.Close();
            return resultSet;
        }

        public void updateReport(string newStatus, string oldStatus)
        {
            var cmd = new SqlCommand("UPDATE reports SET status = @newStatus where status = @oldStatus", connection);
            cmd.Parameters.AddWithValue("@oldstatus", oldStatus);
            cmd.Parameters.AddWithValue("@newStatus", newStatus);
            cmd.ExecuteNonQuery();
        }

        public string getDepartmentName(string username)
        {
            var selectCommand = new SqlCommand("Select DepartmentName From aspnet_Users where UserName = @username", connection);
            var adapter = new SqlDataAdapter(selectCommand);
            selectCommand.Parameters.Add("@username", SqlDbType.NVarChar).Value = username;
            var resultSet = new DataTable();
            adapter.Fill(resultSet);
            connection.Close();

            foreach (DataRow row in resultSet.Rows)
            {
                return row["DepartmentName"].ToString();
            }

            return "Department Name Unavailable";
        }

        public DataTable getDepartmentReports(string departmentName)
        {
            var selectCommand = new SqlCommand("Select * From Reports Inner Join aspnet_Users on reports.ConsultantID = aspnet_users.Username where DepartmentName = @deptName", connection);
            var adapter = new SqlDataAdapter(selectCommand);
            selectCommand.Parameters.Add("@deptName", SqlDbType.NVarChar).Value = departmentName;
            var resultSet = new DataTable();
            adapter.Fill(resultSet);
            connection.Close();
            return resultSet;
        }

        public void changeReportStatus(string reportID, string status)
        {
            connection.Open();
            var updateCommand = new SqlCommand("Update Reports Set ReportStatus = @status where Id = @reportID", connection);
            updateCommand.Parameters.Add("@reportID", SqlDbType.NVarChar).Value = reportID;
            updateCommand.Parameters.Add("@status", SqlDbType.NVarChar).Value = status;
            updateCommand.ExecuteNonQuery();
        }

        public DataTable getReport(string consultantID)
        {
            SqlCommand command = new SqlCommand("Select * From Reports where ConsultantID = @id");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = consultantID;
            return getDataTable(command);
        }

        public void SubmitReport(string departmentSupervisorId, string consultantId, string status,  byte[] receipt, string date)
        {
            var insertCommand = new SqlCommand(@"INSERT Into Reports (DepartmentSupervisorID, ConsultantID, ReportStatus, Receipt, Date)
            VALUES (@DepartmentSupervisorID, @ConsultantID, @ReportStatus, @Receipt, @Date)", connection);

            insertCommand.Parameters.Add("@DepartmentSupervisorID", SqlDbType.VarChar).Value = departmentSupervisorId;
            insertCommand.Parameters.Add("@ConsultantID", SqlDbType.VarChar).Value = consultantId;
            insertCommand.Parameters.Add("@ReportStatus", SqlDbType.VarChar).Value = status;
            insertCommand.Parameters.Add("@Receipt", SqlDbType.VarBinary).Value = receipt; //for testing this is null
            insertCommand.Parameters.Add("@Date", SqlDbType.VarChar).Value = date;

            connection.Open();
            insertCommand.ExecuteScalar();
            connection.Close();

        }

        public void submitExpense(string Id, string description, string location, double amount, string currency)
        {
            var insertCommand = new SqlCommand(@"INSERT Into Expenses (ReportID, Description, Location, Amount, Currency) 
                    VALUES (@ReportID, @Description, @Location, @Amount, @Currency)",connection);

            insertCommand.Parameters.Add("@ReportID", SqlDbType.Int).Value = Id;
            insertCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = description;
            insertCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = location;
            insertCommand.Parameters.Add("@Amount", SqlDbType.Real).Value = amount;
            insertCommand.Parameters.Add("@Currency", SqlDbType.VarChar).Value = currency;
            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
        }

        public string GetReportID()
        {
            var insertCommand = new SqlCommand("SELECT Id From Reports ORDER BY Id Desc");
            DataTable data = getDataTable(insertCommand);
            return data.Rows[0]["Id"].ToString(); 
        }

        public void insertExpense(Expense expense)
        {
            var insertCommand = new SqlCommand(@"INSERT Into Expenses (ReportID, Description, Location, Amount, Currency) 
                    VALUES (@ReportID, @Description, @Location, @Amount, @Currency)", connection);

            insertCommand.Parameters.Add("@ReportID", SqlDbType.VarChar).Value = expense.ReportID;
            insertCommand.Parameters.Add("@Description", SqlDbType.VarChar).Value = expense.Description;
            insertCommand.Parameters.Add("@Location", SqlDbType.VarChar).Value = expense.Location;
            insertCommand.Parameters.Add("@Amount", SqlDbType.Real).Value = expense.Amount;
            insertCommand.Parameters.Add("@Currency", SqlDbType.VarChar).Value = expense.Currency;

            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();

        }

        public DataTable GetExpensesByReportID(string reportID)
        {
            var connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand("SELECT all FROM Expenses Where ReportID = @ReportID");
            command.Parameters.Add("@ReportID", SqlDbType.Int).Value = reportID;
            var adapter = new SqlDataAdapter(command);
            var resultSet = new DataTable();
            connection.Open();
            adapter.Fill(resultSet);
            connection.Close();
            return resultSet;
        }
    }


}
