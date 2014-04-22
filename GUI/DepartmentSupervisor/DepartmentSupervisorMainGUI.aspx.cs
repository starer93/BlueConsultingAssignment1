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
            lblTotalBudget.Text = "$" + departmentSupervisor.Department.getTotalBudget();
            lblRemainingBudget.Text = "$" + departmentSupervisor.Department.getRemainingBudget();
            lblExpensesApproved.Text = "$" + departmentSupervisor.Department.getExpensesApproved();
            departmentSupervisor.Department.updateDepartmentReports();
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

            }
            else if (radioButtonReportFilter.SelectedValue == "Rejected by Account Staff")
            {

            }
        }

        private void showAllReports()
        {
            foreach (Report report in departmentSupervisor.Department.getDepartmentReports())
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showPendingReports()
        {
            foreach (Report report in departmentSupervisor.Department.getPendingReports())
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showApprovedReports()
        {
            foreach (Report report in departmentSupervisor.Department.getApprovedReports())
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