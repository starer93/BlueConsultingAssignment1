using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace BlueConsultingBusinessLogic
{
    public class Department
    {
        private string name;
        private const double MONTHLY_BUDGET = 10000;
        private double currentBudget;
        private List<DepartmentSupervisorLogic> supervisors = new List<DepartmentSupervisorLogic>();
        private DatabaseAccess databaseAccess = new DatabaseAccess();
        private List<Report> reports = new List<Report>();

        public string Name 
        {
            get
            {
                return name;
            }
        }

        public Department(int index)
        {
            currentBudget = MONTHLY_BUDGET;
        }

        public Department(string departmentName)
        {
            name = departmentName;
            updateCurrentBudget();
        }

        public void updateDepartmentReports()
        {
            string a;
            //CALL A METHOD THAT PERFORMS AN INNER JOIN IN THE DATABASE AND STORES IT IN THE REPORTSLIST
            DataTable dataTable = databaseAccess.getDepartmentReports(Name);
            foreach(DataRow row in dataTable.Rows)
            {
                a = row["ConsultantID"].ToString();
            }
            updateCurrentBudget();
        }

        private void updateCurrentBudget()
        {
            //LOOPS THROUGH THE REPORTS LIST AND GET NEW CURRENT BUDGET
        }

        public List<Report> getDepartmentReports()
        {
            return reports;
        }

        public List<Report> getApprovedReports()
        {
            List<Report> approvedReports = new List<Report>();
            //Loop through list and get approved reports
            return approvedReports;
        }

        public List<Report> getRejectedReports()
        {
            List<Report> rejectedReports = new List<Report>();
            //Loop through list and get rejected reports
            return rejectedReports;
        }

        public string getName()
        {
            return name;
        }

        public double getTotalBudget()
        {
            return MONTHLY_BUDGET;
        }

        public double getCurrentBudget()
        {
            return currentBudget;
        }

    }
}
