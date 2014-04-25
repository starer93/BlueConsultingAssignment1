using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.DepartmentSupervisor
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Report report;
        DepartmentSupervisorLogic departmentSupervisor;
        protected void Page_Load(object sender, EventArgs e)
        {
            report = (Report) Session["Report"];
            departmentSupervisor = (DepartmentSupervisorLogic)Session["Department Supervisor"];
            lblReportID.Text = report.ReportID;
            
        }

        private void fillExpense()
        {
            
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            departmentSupervisor.rejectReport(report.ReportID);
        }
    }
}