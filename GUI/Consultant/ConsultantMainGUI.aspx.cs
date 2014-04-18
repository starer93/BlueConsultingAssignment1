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
            //loading labels
            if (listboxReports.SelectedItem != null) lblSelectedReport.Text = listboxReports.SelectedItem.ToString();
            else lblSelectedReport.Text = "NOTHING SELECTED";

            lblDate.Text = DateTime.Now.ToString();
            lblUsername.Text = User.Identity.Name;

            if (!IsPostBack) //if page loads for the first time
            {
                ConsultantLogic consultant = new ConsultantLogic(User.Identity.Name);
                List<Report> reports = new List<Report>();
                consultant.loadAllReports();
                reports = consultant.GetReports();
                
                if (reports != null)
                {
                    ShowDefaultReport(reports); //load list of reports
                    Session["Reports"] = reports;
                }

                Session["Consultant"] = consultant;
            }
        }

        protected void rblReportFilter_Init(object sender, EventArgs e)
        {
            //default to first option when nothing is selected
            if (rblReportFilter.SelectedItem == null) rblReportFilter.SelectedIndex = 0;
        }

        private void ShowDefaultReport(List<Report> reports)
        {
            listboxReports.Items.Clear();
            foreach (Report report in reports) listboxReports.Items.Add(report.PrintReport());
        }

        private void FilterReports(String filter, List<Report> reports)
        {
            listboxReports.Items.Clear();
            foreach (Report report in reports)
            {
                if (report.ReportStatus.Equals(filter)) listboxReports.Items.Add(report.PrintReport());
            }
        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            Response.Write(" <script language='javascript'> window.open('SubmitReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            txtReportPreview.Text = String.Empty;
            String selectedReport = "", reportID = "";

            if (listboxReports.SelectedItem != null)
            {
                lblSelectedReport.Text = listboxReports.SelectedItem.ToString();
                selectedReport = listboxReports.SelectedItem.ToString();
                reportID = selectedReport.Substring(0, selectedReport.IndexOf(",")); //get first set of char as reportID
            }

            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];

            if (consultant != null)
            {
                List<Report> reports = consultant.GetReports();
                Report report = consultant.findReport(reportID);

                if (report != null)
                {
                    report.LoadExpensesFromDB();
                    List<Expense> expenses = report.GetExpenses();
                    txtReportPreview.Text = String.Empty;
                    foreach (Expense expense in expenses) txtReportPreview.Text += expense.PrintExpense();
                }
            } 
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            txtReportPreview.Text = String.Empty;
            List<Report> reports = (List<Report>)Session["Reports"];
            String submit = "submit", approve = "approve", pending = "pending";

            if (reports != null && rblReportFilter.SelectedItem != null)
            {
                switch (rblReportFilter.SelectedIndex)
                {
                    case 0: ShowDefaultReport(reports); break;
                    case 1: FilterReports(submit, reports); break;
                    case 2: FilterReports(approve, reports); break;
                    case 3: FilterReports(pending, reports); break;
                    default: ShowDefaultReport(reports); break;
                }
            }
        }

    }
}