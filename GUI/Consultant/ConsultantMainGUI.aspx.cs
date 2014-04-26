using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;

namespace GUI.Consultant
{
    public partial class ConsultantMainGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblUsername.Text = User.Identity.Name;
            ConsultantLogic consultant;
            if (!IsPostBack)
            {
                consultant = new ConsultantLogic(User.Identity.Name);
                LoadReports(consultant);
            }
        }

        protected void rblReportFilter_Init(object sender, EventArgs e)
        {
            if (rblReportFilter.SelectedItem == null) rblReportFilter.SelectedIndex = 0;
        }

        private void LoadReports(ConsultantLogic consultant)
        {           
            ShowAllReports(consultant.GetReports());
            Session["Consultant"] = consultant;
        }

        private void ShowAllReports(List<Report> reports)
        {
            listboxReports.Items.Clear();
            foreach (Report report in reports)
            {
                listboxReports.Items.Add(report.PrintReport());
            }
        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            //Response.Write("<script language='javascript'> window.open('SubmitReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");
            Response.Write("<script language='javascript'> window.open('SubmitReport.aspx'); </script>");
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            String selectedReport = "", reportID = "";

            if (listboxReports.SelectedItem != null)
            {
                selectedReport = listboxReports.SelectedItem.ToString();
                reportID = selectedReport.Substring(0, selectedReport.IndexOf(",")); //get first set of char as reportID
                Session["ReportID"] = reportID;
            }

            OpenShowReportsForm();
        }

        private void OpenShowReportsForm()
        {
            Response.Write("<script language='javascript'> window.open('ShowReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void rblReportFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            List<Report> reports = consultant.GetReports();
            int selectedIndex = rblReportFilter.SelectedIndex;

            if (reports.Count > 0 && selectedIndex != -1) //if reports list not empty, and user has selected filter
            {
                switch (selectedIndex)
                {
                    case 0: ShowAllReports(reports); break;
                    case 1: FilterReports(Report.ReportStatuses.ApprovedByDepartmentSupervisor.ToString()); break;
                    case 2: FilterReports(Report.ReportStatuses.ApprovedByAccountStaff.ToString()); break;
                    case 3: FilterReports(Report.ReportStatuses.RejectedByDepartmentSupervisor.ToString()); break;
                    case 4: FilterReports(Report.ReportStatuses.RejectedByAccountStaff.ToString()); break;
                    default: ShowAllReports(reports); break;
                }
            }
        }

        private void FilterReports(String reportStatus)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            listboxReports.Items.Clear();

            foreach (Report report in consultant.GetReports())
            {
                if (report.ReportStatus.Equals(reportStatus))
                {
                    listboxReports.Items.Add(report.PrintReport());
                }
            }
        }
    }
}