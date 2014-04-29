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
            btnAddReceipt.Enabled = true;
            ClearExpenseFields();
        }

        private void ClearExpenseFields()
        {
            txtAmount.Text = "";
            txtDescription.Text = "";
            txtLocation.Text = "";
        }

        private void CreateExpense()
        {
            if (checkTextField())
            {
                Report report = (Report)Session["Report"];
                String location = txtLocation.Text;
                String description = txtDescription.Text;
                String currency = listCurrency.SelectedItem.ToString();
                string emptyID = "";
                if (isValidNumber())
                {
                    Double amount = Convert.ToDouble(txtAmount.Text);
                    Expense expense = new Expense(location, description, amount, currency, emptyID);
                    report.AddExpense(expense);
                }
                else
                {
                    showErrorMessage("Amount must be number");
                }
                Session["Report"] = report;
            }
            else
            {
                showErrorMessage("Please fill all fields");
            }
        }

        private void showErrorMessage(string message)
        {
            labErrorMessage.Text = message;
            labErrorMessage.ForeColor = Color.Red;
            labErrorMessage.Visible = true;
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            Report report = (Report)Session["Report"];
            Response.Write("<script language='javascript'> window.open('UploadReceipt.aspx','width=200px,height=100px'); </script>");
        }

        private Boolean checkTextField()
        {
            if (txtDescription.Text.Trim().Length == 0 || txtLocation.Text.Trim().Length == 0)
            {
                return false;
            }
            return true;
        }

        private Boolean isValidNumber()
        {
            string Str = txtAmount.Text.Trim();
            double Num;
            return double.TryParse(Str, out Num);
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}