using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.DepartmentSupervisor
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DepartmentSupervisorLogic departmentSupervisor;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadUser();
            updatePage();
        }

        private void loadUser()
        {
            departmentSupervisor = new DepartmentSupervisorLogic(User.Identity.Name);
        }

        private void updatePage()
        {
            lblCurrentUser.Text = departmentSupervisor.Username;
            lblDepartmentName.Text = departmentSupervisor.Department.Name;
            lblTotalBudget.Text = "$" + departmentSupervisor.Department.getTotalBudget();
            lblRemainingBudget.Text = "$" + departmentSupervisor.Department.getCurrentBudget();
            departmentSupervisor.Department.updateDepartmentReports();

            List<Report> reports = departmentSupervisor.Department.getDepartmentReports();
            foreach (Report report in reports)
            {
                listBoxReports.Items.Add(report.ReportID);
            }
        }
    }
}