using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.Account_Staff
{
    public partial class AccountStaffMainGUI : System.Web.UI.Page
    {
        AccountStaffLogic accountStaff = new AccountStaffLogic();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            Chart1.Titles.Add("Monthly Budget");
            string seriesName = "Budget";
            Chart1.Series.Add(seriesName);
            Chart1.Series[seriesName].BorderWidth = 2;
            List<DepartmentSupervisorLogic> supervisors = accountStaff.getSupervisor();

            foreach (DepartmentSupervisorLogic supervisor in supervisors)
            {
                string columnName = supervisor.Username;
                double YValue = supervisor.getApproveAmount();
                Chart1.Series[seriesName].Points.AddXY(columnName, YValue);
            }

        }
    }
}