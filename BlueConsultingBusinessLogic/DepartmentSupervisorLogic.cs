using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingBusinessLogic
{
    public class DepartmentSupervisorLogic
    {
        private string username;
        private Department department;
        private DatabaseAccess databaseAccess = new DatabaseAccess();

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
        }

        private void loadDepartment()
        {
            department = new Department(databaseAccess.getDepartmentName(username));
        }
    }
}
