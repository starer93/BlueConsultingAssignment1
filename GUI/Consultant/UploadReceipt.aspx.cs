using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.Consultant
{
    public partial class UploadReceipt : System.Web.UI.Page
    {
        Report report;
        protected void Page_Load(object sender, EventArgs e)
        {
            report = (Report)Session["Report"];
            report.ReportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            report = (Report)Session["Report"];
            if (isPdf())
            {
                CreateReport();
                report.submit();
                AddReportIDToExpenses();
                report.submitExpense();
                ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
            }
            else
            {
                lblFileUpload.Text = "Make sure you are uploading pdf file, check your reciept";
                lblFileUpload.Visible = true;
            }
        }

        private void CreateReport()
        {
            Report report = (Report)Session["Report"];
            report.DepartmentSupervisorID = " ";
            report.ConsultantID = User.Identity.Name;
            report.Date = DateTime.Now.ToString("dd/MM/yyyy");
            report.Receipt = report.GetReceipt(fupReceipts.PostedFile);
            Session["Report"] = report;
        }

        private void AddReportIDToExpenses()
        {
            Report report = (Report)Session["Report"];
            List<Expense> expenses = report.GetExpenses();

            foreach (Expense expense in expenses)
            {
                //expense.ReportID = report.NewReportID();
                DatabaseAccess da = new DatabaseAccess();
                expense.ReportID = report.ReportID;
            }

            Session["Report"] = report;
        }

        private Boolean isPdf()
        {
            if (fupReceipts.HasFile)
            {
                string fileName = Server.HtmlEncode(fupReceipts.FileName);
                string extension = System.IO.Path.GetExtension(fileName);
                Session["Receipt"] = fupReceipts.FileName;
                if (extension == ".pdf")
                {
                    return true;
                }
            }
            return false;
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}