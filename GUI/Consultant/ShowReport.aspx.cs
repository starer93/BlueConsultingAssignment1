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
            String reportID = (String)Session["ReportID"];
            List<Report> reports = new List<Report>();
            List<Expense> expenses = new List<Expense>();
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];

            lblSelectedReportID.Text += reportID;

            if (consultant != null)
            {
                reports = consultant.GetReports();
                //find all expenses that match reportID
                Report report = consultant.findReport(reportID);

                if (report != null)
                {
                    report.LoadExpensesFromDB();
                    expenses = report.GetExpenses();

                    foreach (Expense expense in expenses)
                    {
                        txtReportPreview.Text += expense.PrintExpense();
                    }
                }
                else
                {
                    lblSelectedReportID.Text += " NOT FOUND";
                }
            } 
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }        
    }
}