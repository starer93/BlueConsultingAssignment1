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

        }

        protected void btnAddExpense_Click(object sender, EventArgs e)
        {
            Expense expense = CreateExpense();
            listboxExpenses.Items.Add(expense.PrintExpense());
            Session["Expense"] = expense;
        }

        private Expense CreateExpense()
        {
            String location = "", description = "", currency = "";
            double amount = 0;
            int reportID = 5; //need to use auto increment
            //get all reports from db
            location = txtLocation.Text;
            description = txtDescription.Text;
            amount = Convert.ToDouble(txtAmount.Text);
            currency = listCurrency.SelectedItem.ToString();
            reportID = 7;

            //need to check if user skips empty fields

            Expense expense = new Expense(location, description, amount, currency, reportID);
            return expense;
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            Report report = CreateReport();
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];

            if (consultant != null)
            {
                consultant.submitReport(report);
                labelStatus.Text += " submitted successfully";
            }
            else
            {
                labelStatus.Text += " did not submit";
            }
        }

        private Report CreateReport()
        {
            String departmentSupervisorID = "", consultantID = "", reportID = "", date = "", reportStatus = "";
            Byte[] receipt = null; //receipts PDF
            Expense expense = (Expense)Session["Expense"];

            consultantID = User.Identity.Name;
            reportID = expense.ReportID.ToString();
            reportStatus = "submit"; //this needs to be a constant
            date = GetCurrentDate(); //need to format to dd/mm/yyyy
            receipt = GetReceipt();

            Report report = new Report(departmentSupervisorID, consultantID, reportID, reportStatus, date, null);
            report.AddExpense(expense);

            return report;
        }

        private String GetCurrentDate()
        {
            return DateTime.Now.ToString("dd/MM/yyyy");
        }

        private Byte[] GetReceipt()
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