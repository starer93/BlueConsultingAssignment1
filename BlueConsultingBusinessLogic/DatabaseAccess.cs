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
        string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;

        public DataTable getDataTable(SqlCommand command)
        {
            var connection = new SqlConnection(connectionString);
            command.Connection = connection;
            var adapter = new SqlDataAdapter(command);
            var resultSet = new DataTable();
            adapter.Fill(resultSet);
            connection.Close();
            return resultSet;
        }

        public void insertToDatabase(SqlCommand command)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            command.Connection = connection;
            command.ExecuteNonQuery();
            connection.Close();
        }

        public void updateReport(string newStatus, string oldStatus)
        {
            var connection = new SqlConnection(connectionString);
            var cmd = new SqlCommand("UPDATE reports SET status = @newStatus where status = @oldStatus", connection);
            cmd.Parameters.AddWithValue("@oldstatus", oldStatus);
            cmd.Parameters.AddWithValue("@newStatus", newStatus);
            cmd.ExecuteNonQuery();
        }

        public string getDepartmentName(string username)
        {
            var connection = new SqlConnection(connectionString);
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
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("Select * From Reports Inner Join aspnet_Users on reports.ConsultantID = aspnet_users.Username where DepartmentName = @deptName", connection);
            var adapter = new SqlDataAdapter(selectCommand);
            selectCommand.Parameters.Add("@deptName", SqlDbType.NVarChar).Value = departmentName;
            var resultSet = new DataTable();
            adapter.Fill(resultSet);
            connection.Close();
            return resultSet;
        }

        public void rejectReport(string reportID)
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            var updateCommand = new SqlCommand("Update Reports Set ReportStatus = RejectedByDepartmentSupervisor where Id = @reportID", connection);
            var adapter = new SqlDataAdapter(updateCommand);
            updateCommand.Parameters.Add("@reportID", SqlDbType.NVarChar).Value = reportID;
            updateCommand.ExecuteNonQuery();
        }

    }

}
