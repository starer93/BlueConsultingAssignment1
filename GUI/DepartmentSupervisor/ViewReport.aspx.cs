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
            departmentSupervisor.changeReportStatus(report.ReportID, Report.ReportStatuses.RejectedByDepartmentSupervisor.ToString());
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            if(departmentSupervisor.Department.willBeOverBudget(report))
            {
                //POP A MESSAGE BOX HERE. NEED MORE RESEARCH
            }
            departmentSupervisor.changeReportStatus(report.ReportID, Report.ReportStatuses.ApprovedByDepartmentSupervisor.ToString());
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}