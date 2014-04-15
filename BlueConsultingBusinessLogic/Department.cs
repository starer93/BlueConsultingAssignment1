using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlueConsultingBusinessLogic
{
    public class Department
    {
        private string name;
        private const double MONTHLY_BUDGET = 10000;
        private double currentBudget;
        private List<DepartmentSupervisorLogic> supervisors = new List<DepartmentSupervisorLogic>();

        public Department(int index)
        {
            currentBudget = MONTHLY_BUDGET;
        }

        public string getName()
        {
            return name;
        }

        public double getBudget()
        {
            return MONTHLY_BUDGET;
        }

        public double getCurrentBudget()
        {
            return currentBudget;
        }
    }
}
