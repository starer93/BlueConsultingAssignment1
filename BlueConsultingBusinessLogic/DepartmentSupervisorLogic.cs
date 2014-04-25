using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Configuration;

namespace BlueConsultingBusinessLogic
{
    public class DepartmentSupervisorLogic
    {
        private string username;
        private Department department;
        private DatabaseAccess databaseAccess = new DatabaseAccess();
        List<Report> reports = new List<Report>();

        public string Username 
        {
            get
            {
                return username;
            }
        }
        public Department Department 
        {
            get
            {
                return department;
            }
        }

        public DepartmentSupervisorLogic(string username)
        {
            this.username = username;
            loadDepartment();
            loadPassReport();
        }

        private void loadDepartment()
        {
            department = new Department(databaseAccess.getDepartmentName(username));
        }

        public double getApproveAmount()
        {
            double sum = 0;
            foreach (Report report in reports)
            {
                if (report.ReportStatus.Equals("submit"))
                {
                    sum += report.calculateTotalExpenses();
                }
            }
            return sum;
        }

        private void loadPassReport()
        {
            SqlCommand command = new SqlCommand("Select Id From Reports where DepartmentSupervisorID = @Id ");
            command.Parameters.Add("@Id", SqlDbType.VarChar).Value = username;
            DataTable dt = databaseAccess.getDataTable(command);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string id = dt.Rows[i]["Id"].ToString();
                reports.Add(new Report(id));
            }
        }

        private void loadAllReport()
        {
            // loading everyreport in the department
            // list report = deportment.getreport();
        }

        public void rejectReport(string reportID)
        {
            databaseAccess.rejectReport(reportID);
        }
    }
}
