using System;
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

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnAddExpense_Click(object sender, EventArgs e)
        {
            String location = "";
            String description = "";
            double amount = 0;
            String currency = "";
            System.Drawing.Image receipts = null; //receipts PDF

            location = txtLocation.Text;
            description = txtDescription.Text;
            amount = Convert.ToDouble(txtAmount.Text);
            currency = listCurrency.SelectedItem.ToString();
            //receipts = 

            Report report = new Report();
            Expense expense = new Expense(location, description, amount, currency, receipts);

            report.AddExpense(expense);
            listboxExpenses.Items.Add(expense.PrintExpense());
            Session["Report"] = report;
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            Report report = (Report)Session["Report"];

            if (consultant != null && report != null)
            {
                consultant.submitReport(report);
                labelStatus.Text += " submitted successfully";
            }
            else
            {
                labelStatus.Text += " did not submit";
            }
        }
    }
}