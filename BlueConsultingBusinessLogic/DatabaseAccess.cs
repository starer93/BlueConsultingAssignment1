using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.IO;
using System.Configuration;
using BlueConsultingBusinessLogic.ReportDataSetTableAdapters;
using System.Data;

namespace BlueConsultingBusinessLogic
{
    public class DatabaseAccess
    {
        string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
        public ReportDataSet getReportDataSet(string consultantID)
        {
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand("Select * From Reports where ConsultantID LIKE @id", connection);
            var adapter = new SqlDataAdapter(selectCommand);

            selectCommand.Parameters.Add("@Id", SqlDbType.VarChar).Value = "%" + consultantID + "%";

            var resultSet = new ReportDataSet();
            adapter.Fill(resultSet);
            connection.Close();
            return resultSet;
        }

        

        public void insertReportToDatabase(Report report)
        {
            var connection = new SqlConnection(connectionString);
            #region CommandCreation
            var insertCommand = new SqlCommand("INSERT Into Reports VALUES (@DepartmentSupervisorID, @ConsultantID, @ReportStatus, @PDF)", connection);
            if (report.DepartmentSupervisorID == null)
            {
                insertCommand.Parameters.Add("@DepartmentSupervisorID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@DepartmentSupervisorID", SqlDbType.VarChar).Value =report.DepartmentSupervisorID;
            }

            if (report.ConsultantID == null)
            {
                insertCommand.Parameters.Add("@ConsultantID", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@ConsultantID", SqlDbType.VarChar).Value = report.ConsultantID;
            }

            if (report.ReportStatus == null)
            {
                insertCommand.Parameters.Add("@ReportStatus", SqlDbType.VarChar).Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@ReportStatus", SqlDbType.VarChar).Value =  report.ReportStatus;
            }

            if (report.PDF == null)
            {
                insertCommand.Parameters.Add("@PDF", SqlDbType.VarBinary).Value = DBNull.Value;
            }
            else
            {
                insertCommand.Parameters.Add("@PDF", SqlDbType.VarBinary).Value =  report.PDF ;
            }
            #endregion
            connection.Open();
            insertCommand.ExecuteNonQuery();
            connection.Close();
            //var adapter = new SqlDataAdapter(selectCommand);
        }

        public DataSet getReports(string CommandLine, string para)
        {
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand(CommandLine, connection);
            var adapter = new SqlDataAdapter(selectCommand);

            selectCommand.Parameters.Add("@Id", SqlDbType.VarChar).Value = "%" + para + "%";

            var resultSet = new DataSet();
            adapter.Fill(resultSet);
            connection.Close();
            return resultSet;
        }

        public void updateReport(string newStatus, string oldStatus)
        {
            var connection = new SqlConnection(connectionString);
            var cmd = new SqlCommand("UPDATE reports SET status = @newStatus where status = @oldStatus", connection);
            cmd.Parameters.AddWithValue("@oldstatus", oldStatus);
            cmd.Parameters.AddWithValue("@newStatus",newStatus);
            cmd.ExecuteNonQuery();
        }

        public DataTable getDataTable(string command)
        {
            var connection = new SqlConnection(connectionString);
            var selectCommand = new SqlCommand(command, connection);
            SqlDataAdapter da = new SqlDataAdapter();
            da.SelectCommand = selectCommand;
            DataTable dt = new DataTable();
            da.Fill(dt);
            connection.Close();
            return dt;
        }


    }

    
}
