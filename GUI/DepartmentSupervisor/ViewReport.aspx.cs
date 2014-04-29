using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;
using System.IO;
using System.Diagnostics;
using System.Drawing;
using System.Data;

namespace GUI.DepartmentSupervisor
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Report report;
        DepartmentSupervisorLogic departmentSupervisor;
        DataTable dataTable;

        protected void Page_Load(object sender, EventArgs e)
        {
            report = (Report)Session["Report"];
            departmentSupervisor = (DepartmentSupervisorLogic)Session["Department Supervisor"];
            lblReportID.Text = report.ReportID;
            
            InitData();
            FillExpense();
            CheckOverBudgetReports();
            CheckRejectedReports();
           
        }

        //initialise data --------------------------------
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

        private void CheckRejectedReports()
        {
            if (report.ReportStatus.Equals("RejectedByAccountStaff"))
            {
                btnApprove.Visible = false;
                btnReject.Visible = false;
                lblReportInformation.Visible = false;
                lblReportInformation.Text = "This report has been rejected by account staff.";
            }
        }

        private void CheckOverBudgetReports()
        {
            if (departmentSupervisor.Department.willBeOverBudget(report))
            {
                String currentDepartment = departmentSupervisor.Department.Name;
                lblReportInformation.Text = String.Format("Accepting this report will cause {0} to be over budget.", currentDepartment);
            }
        }

        //approve or reject -------------------------------
        protected void btnReject_Click(object sender, EventArgs e)
        {
            String toRejected = Report.ReportStatuses.RejectedByDepartmentSupervisor.ToString();
            departmentSupervisor.changeReportStatus(report.ReportID, toRejected);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnApprove_Click(object sender, EventArgs e)
        {
            String toApproved = Report.ReportStatuses.ApprovedByDepartmentSupervisor.ToString();
            departmentSupervisor.changeReportStatus(report.ReportID, toApproved);
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        //view receipt method --------------------------------------
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
                lblReportInformation.Visible = true;
                lblReportInformation.Text = "Receipt not available";
            }
        }
    }
}