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
                Report report = consultant.findReport(reportID);

                if (report != null)
                {
                    ShowExpensesInReport(report);
                }
            }
        }

        private void ShowExpensesInReport(Report report)
        {
            txtReportPreview.Text = String.Empty;
            report.LoadExpensesFromDB();
            List<Expense> expenses = report.GetExpenses();

            foreach (Expense expense in expenses)
            {
                txtReportPreview.Text += expense.PrintExpense();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnViewReceipt_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            String reportID = (String)Session["ReportID"];

            DatabaseAccess da = new DatabaseAccess();

            //open file from database
        }

       
    }
}