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
            try
            {
                LoadReportsFromDB();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("An error has occurred: '{1}', :'{0}'", sqlEx, sqlEx.Number);
            }
        }

        //test constructor
        public ConsultantLogic(String consultantID, DatabaseAccess databaseAccess)
        {
            this.ConsultantID = consultantID;
            this.databaseAccess = databaseAccess;
            try
            {
                LoadReportsFromDB();
            }
            catch (SqlException sqlEx)
            {
                Console.WriteLine("An error has occurred: '{1}', :'{0}'", sqlEx, sqlEx.Number);
            }
        }

        public void LoadReportsFromDB()
        {
            DataTable dataTable = databaseAccess.getReport(ConsultantID);
            foreach (DataRow row in dataTable.Rows)
            { 
                Report report = new Report();
                report.ReportID = row["Id"].ToString();
                report.ReportStatus = row["ReportStatus"].ToString();
                report.Date = row["Date"].ToString();
                report.ConsultantID = row["ConsultantID"].ToString();

                if (row["Receipt"] != DBNull.Value)
                {
                    report.Receipt = (byte[])row["Receipt"];
                }

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

        public void addReport(Report report)
        {
            reports.Add(report);
        }

    }
}
