using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.DepartmentSupervisor
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        private DepartmentSupervisorLogic departmentSupervisor;

        protected void Page_Load(object sender, EventArgs e)
        {
            loadUser();
            updatePage();
            showAllReports();
        }

        private void loadUser()
        {
            departmentSupervisor = new DepartmentSupervisorLogic(User.Identity.Name);
        }

        private void updatePage()
        {
            lblCurrentUser.Text = departmentSupervisor.Username;
            lblDepartmentName.Text = departmentSupervisor.Department.Name;
            departmentSupervisor.Department.updateDepartmentReports(ddlMonth.SelectedValue, ddlYear.SelectedValue);
            lblTotalBudget.Text = "$" + departmentSupervisor.Department.getTotalBudget();
            lblRemainingBudget.Text = "$" + departmentSupervisor.Department.getRemainingBudget(ddlMonth.SelectedValue, ddlYear.SelectedValue);
            lblExpensesApproved.Text = "$" + departmentSupervisor.Department.TotalExpense(ddlMonth.SelectedValue, ddlYear.SelectedValue);
        }

        protected void ddlMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateListBox();
        }

        protected void ddlYear_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateListBox();
        }

        protected void radioButtonReportFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            populateListBox();
        }

        private void populateListBox()
        {
            listBoxReports.Items.Clear();
            if (radioButtonReportFilter.SelectedValue == "All Reports")
            {
                showAllReports();
            }
            else if (radioButtonReportFilter.SelectedValue == "Pending Reports")
            {
                showPendingReports();
            }
            else if (radioButtonReportFilter.SelectedValue == "Approved Reports")
            {
                showApprovedReports();
            }
            else if (radioButtonReportFilter.SelectedValue == "Rejected Reports")
            {
                showRejectedReports();
            }
            else if (radioButtonReportFilter.SelectedValue == "Rejected by Account Staff")
            {
                showRejectedByAccountStaffReports();
            }
        }

        private void showAllReports()
        {
            lblReportsDescription.Text = "All Reports";
            foreach (Report report in departmentSupervisor.Department.getDepartmentReports(ddlMonth.SelectedValue, ddlYear.SelectedValue))
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showPendingReports()
        {
            lblReportsDescription.Text = "Pending Reports";
            foreach (Report report in departmentSupervisor.Department.getPendingReports(ddlMonth.SelectedValue, ddlYear.SelectedValue))
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showApprovedReports()
        {
            lblReportsDescription.Text = "Approved Reports";
            foreach (Report report in departmentSupervisor.Department.getApprovedReports(ddlMonth.SelectedValue, ddlYear.SelectedValue))
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showRejectedReports()
        {
            lblReportsDescription.Text = "Rejected by Department Reports";
            foreach (Report report in departmentSupervisor.Department.getRejectedReports(ddlMonth.SelectedValue, ddlYear.SelectedValue))
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showRejectedByAccountStaffReports()
        {
            lblReportsDescription.Text = "Rejected by Account Staff Reports";
            foreach (Report report in departmentSupervisor.Department.getRejectedByAccountStaffReports(ddlMonth.SelectedValue, ddlYear.SelectedValue))
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            string selectedReport = listBoxReports.SelectedItem.Value;
            string reportID = selectedReport.Substring(0, selectedReport.IndexOf(","));
            Report report = departmentSupervisor.Department.getReport(reportID);
            Session["Report"] = report;
            Response.Write("<script language='javascript'> window.open('ViewReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>");
            populateListBox();
        }
    }
}