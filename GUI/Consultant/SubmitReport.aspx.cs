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

namespace GUI.Consultant
{
    public partial class SubmitReport : System.Web.UI.Page
    {
        Report report = new Report();

        protected void Page_Load(object sender, EventArgs e)
        {       
            lblConsultantID.Text = User.Identity.Name;
            lblDate.Text = DateTime.Now.ToString("dd/MM/yyyy");
        }

        protected void btnAddExpense_Click(object sender, EventArgs e)
        {
            report = CreateReport();
            Expense expense = CreateExpense();
            report.AddExpense(expense); //add to report
            listboxExpenses.Items.Add(expense.PrintExpense());
        }

        private Report CreateReport()
        {
            String departmentSupervisorID = "";
            String consultantID = User.Identity.Name;
            String date = lblDate.Text;
            String reportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
            System.Drawing.Image receipt = GetReceipt();

            Report report = new Report(departmentSupervisorID, consultantID, , reportStatus, date, null);
            return report;
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

            DatabaseAccess db = new DatabaseAccess();
            SqlCommand command = new SqlCommand("SELECT Id FROM Reports ORDER BY Id DESC LIMIT 1");
            DataTable dt = db.getDataTable(command); //get last id in table
            int reportID = Convert.ToInt32(dt.Rows[0]["Id"].ToString());
            //need to check if user skips empty fields

            Expense expense = new Expense(location, description, amount, currency, reportID);
            return expense;
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            //Report report = CreateReport();
            
            if (consultant != null)
            {
                consultant.submitReport(report);
                lblStatus.Text += " submitted successfully";
            }
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