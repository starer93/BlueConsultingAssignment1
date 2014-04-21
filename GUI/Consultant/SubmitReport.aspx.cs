using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;
using System.Drawing;

namespace GUI.Consultant
{
    public partial class SubmitReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {            
            lblConsultantID.Text = User.Identity.Name;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnAddExpense_Click(object sender, EventArgs e)
        {
            Expense expense = CreateExpense();
            listboxExpenses.Items.Add(expense.PrintExpense());
            Session["Expense"] = expense;
        }

        private Expense CreateExpense()
        {
            //int reportID; //need to use auto increment
            //get all reports from db
            //String sqlCommand = "SELECT Id FROM Reports WHERE 

            String location = txtLocation.Text;
            String description = txtDescription.Text;
            Double amount = Convert.ToDouble(txtAmount.Text);
            String currency = listCurrency.SelectedItem.ToString();
            int reportID = 7; //get last id in table

            //need to check if user skips empty fields

            Expense expense = new Expense(location, description, amount, currency, reportID);
            return expense;
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            Report report = CreateReport();
            Expense expense = (Expense)Session["Expense"];
            
            report.AddExpense(expense);

            if (consultant != null)
            {
                consultant.submitReport(report);
                lblStatus.Text += " submitted successfully";
            }
        }

        private Report CreateReport()
        {
            String departmentSupervisorID = "";
            String consultantID = User.Identity.Name;
            //String reportID = GetReportIDFromDB();
            String date = lblDate.Text;
            String reportStatus = "submit";
            System.Drawing.Image receipt = GetReceipt();

            Report report = new Report(departmentSupervisorID, consultantID, "1", reportStatus, date, null);
            return report;
        }

        private System.Drawing.Image GetReceipt()
        {
            //get file from openfiledialog
            //parse it as byte
            //return to report

            //FileStream fs = new FileStream();
            //Byte[] file = new Byte[1024];

            //fupReceipts.f
            return null;
        }
    }
}