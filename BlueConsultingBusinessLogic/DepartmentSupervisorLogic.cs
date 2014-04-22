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
            if (username.Length> 10)
            { 
                SqlCommand command = new SqlCommand("Select UserName From aspnet_Users where UserId = @Id");
                command.Parameters.Add("@Id", SqlDbType.VarChar).Value = username;
                DataTable dt = databaseAccess.getDataTable(command);
                foreach (DataRow row in dt.Rows)
                {
                    this.username = row["UserName"].ToString();
                }
            }
            else
            {
                this.username = username;
            }
            loadDepartment();
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
                if (report.ReportStatuses.Equals("submit"))
                {
                    sum += report.calculateTotalExpenses();
                }
            }
            return sum;
        }

    }
}
