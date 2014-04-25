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
            if (!report.ReportStatus.Equals("SubmittedByConsultant"))
            {
                btnApprove.Enabled = false;
                btnReject.Enabled = false;
            }
        }

        private void fillExpense()
        {
            
        }

        protected void btnReject_Click(object sender, EventArgs e)
        {
            departmentSupervisor.rejectReport(report.ReportID);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            departmentSupervisor.approveReport(report.ReportID);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}