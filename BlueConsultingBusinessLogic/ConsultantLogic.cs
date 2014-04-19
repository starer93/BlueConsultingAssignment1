using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BlueConsultingBusinessLogic
{
    public class ConsultantLogic
    {
        private DatabaseAccess databaseAccess = new DatabaseAccess();
        private List<Report> reports = new List<Report>();
        public String ConsultantID { get; set; }

        public ConsultantLogic(String consultantID)
        {
            this.ConsultantID = consultantID;
        }

        public void loadAllReports()
        {
            SqlCommand command = new SqlCommand("Select * From Reports where ConsultantID = @id");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = ConsultantID;

            DataTable dataTable = databaseAccess.getDataTable(command);

            foreach (DataRow row in dataTable.Rows)
            {
                Report report = new Report();

                //storing each row in the report table as a report into the list

                report.ReportID = row["Id"].ToString();
                report.ReportStatus = row["ReportStatus"].ToString();
                report.Date = row["Date"].ToString();
                report.ConsultantID = row["ConsultantID"].ToString();
                //report.PDF = 

                reports.Add(report); //add to the list
            }
        }

        public List<Report> GetReports()
        {
            return reports;
        }

        public Report findReport(String reportID)
        {
            foreach (Report report in reports)
            {
                if (report.ReportID == reportID)
                {
                    return report;
                }
            }
            return null;
        }

        public void submitReport(Report report)
        {
            reports.Add(report);
            submitReportToDatabase(report);
        }

        private void submitReportToDatabase(Report report)
        {
            databaseAccess.insertReportToDatabase(report);
        }

    }
}
