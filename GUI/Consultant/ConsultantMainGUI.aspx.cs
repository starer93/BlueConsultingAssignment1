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
        }

        protected void rblReportFilter_Init(object sender, EventArgs e)
        {
            if (rblReportFilter.SelectedItem == null) rblReportFilter.SelectedIndex = 0;
        }

        protected void btnLoadReports_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = new ConsultantLogic(User.Identity.Name);
            List<Report> reports = new List<Report>();

            consultant.loadAllReports();
            reports = consultant.GetReports();
            ShowAllReports(reports); //load list of reports

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
            Response.Write("<script language='javascript'> window.open('SubmitReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");
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

            Response.Write("<script language='javascript'> window.open('ShowReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            List<Report> reports = new List<Report>();
            String approve = "approve", pending = "pending";
            int selectedIndex = rblReportFilter.SelectedIndex;

            reports = consultant.GetReports();

            if (reports.Count > 0 && selectedIndex != -1) //if reports list not empty, and user has selected filter
            {
                switch (selectedIndex)
                {
                    case 0: ShowAllReports(reports); break;
                    case 1: FilterReports(approve, reports); break;
                    case 2: FilterReports(pending, reports); break;
                    default: ShowAllReports(reports); break;
                }
            }
        }

        private void FilterReports(String filter, List<Report> reports)
        {
            listboxReports.Items.Clear();
            foreach (Report report in reports)
            {
                if (report.ReportStatus.Equals(filter))
                {
                    listboxReports.Items.Add(report.PrintReport());
                }
            }
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}