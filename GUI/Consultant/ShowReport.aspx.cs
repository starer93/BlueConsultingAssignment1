using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.Consultant
{
    public partial class ShowReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            String reportID = (String)Session["ReportID"];
            lblSelectedReportID.Text = reportID;

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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }        
    }
}