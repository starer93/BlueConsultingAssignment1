﻿using System;
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
        private string consultantID;

        public ConsultantLogic(string consultantID)
        {
            this.consultantID = consultantID;
        }

        public void addReport(Report report)
        {
            reports.Add(report);
        }

        public void submitReportToDatabase()
        {
            //DatabaseAccess.insertReportToDatabase(
        }

        public List<Report> loadAllReports()
        {
            var command = new SqlCommand("Select * From Reports where ConsultantID = @id");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = consultantID;
            DataTable dataTable = databaseAccess.getDataTable(command);

            foreach (DataRow d in dataTable.Rows)
            {
                Report report = new Report();
                //get report id

                report.ReportID = d["Id"].ToString();
                reports.Add(report);
            }
            return reports;
        }

    }
}