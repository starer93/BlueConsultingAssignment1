using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;
using System.IO;

namespace GUI.Consultant
{
    public partial class ShowReport : System.Web.UI.Page
    {
        Report report;
        DataTable dataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            report = (Report)Session["Report"];
            lblSelectedReportID.Text = report.ReportID;
            
            InitData();
            FillExpense();
        }

        private void InitData()
        {
            dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("amount");
            dataTable.Columns.Add("description");
            dataTable.Columns.Add("location");
            dataTable.Columns.Add("currency");
        }

        private void FillExpense()
        {
            List<Expense> expenses = report.GetExpenses();

            foreach (Expense expense in expenses)
            {
                dataTable.Rows.Add(expense.ReportID, expense.Amount, expense.Description, expense.Location, expense.Currency);
            }

            listViewExpenses.DataSource = dataTable;
            listViewExpenses.DataBind();
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnViewReceipt_Click(object sender, EventArgs e)
        {
            byte[] receipt = report.Receipt;

            if (receipt.Length > 0)
            {
                Session["Receipt"] = receipt;
                Response.Write("<script language='javascript'> window.open('../Receipt.aspx'); </script>");
            }
            else
            {
                lblReportInformation.Text = "Receipt not available";
            }
        }
    }
}