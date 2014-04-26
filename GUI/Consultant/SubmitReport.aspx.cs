using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;
using System.Drawing;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GUI.Consultant
{
    public partial class SubmitReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            lblConsultantID.Text = User.Identity.Name;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");

            if (!IsPostBack)
            {
                Report report = new Report();
                Session["Report"] = report;
            }
        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            CreateReport();
            EnableExpenseFields();
            //enable expenses input fields
        }

        private void EnableExpenseFields()
        {
            txtAmount.Enabled = true;
            txtDescription.Enabled = true;
            txtLocation.Enabled = true;
            listCurrency.Enabled = true;
            btnAddExpense.Enabled = true;
        }

        private void CreateReport()
        {
            Report report = (Report)Session["Report"];

            report.DepartmentSupervisorID = "";
            report.ConsultantID = User.Identity.Name;
            report.Date = lblDate.Text;
            report.ReportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
            report.Receipt = report.GetReceipt(fupReceipts.PostedFile);
            Session["Report"] = report;
        }

        protected void btnAddExpense_Click(object sender, EventArgs e)
        {
            CreateExpense();
            Report report = (Report)Session["Report"];
            List<Expense> expenses = report.GetExpenses();

            listboxExpenses.Items.Clear();

            foreach (Expense expense in expenses)
            {
                listboxExpenses.Items.Add(expense.PrintExpense());
            }

            btnSubmitReport.Enabled = true;
        }

        private void CreateExpense()
        {
            Report report = (Report)Session["Report"];

            String location = txtLocation.Text;
            String description = txtDescription.Text;
            Double amount = Convert.ToDouble(txtAmount.Text);
            String currency = listCurrency.SelectedItem.ToString();
            //int reportID = report.NewReportID();
            string emptyID = "";

            Expense expense = new Expense(location, description, amount, currency, emptyID);

            report.AddExpense(expense);

            Session["Report"] = report;
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            Report report = (Report)Session["Report"];

            report.submit();
            AddReportIDToExpenses();
            report.submitExpense();

            btnSubmitReport.Enabled = false;
            lblStatus.Text = "Report submitted successfully. Please close this window.";

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

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}