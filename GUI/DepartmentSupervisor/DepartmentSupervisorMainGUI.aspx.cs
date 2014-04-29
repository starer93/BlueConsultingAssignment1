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

            if (!IsPostBack)
            {
                populateListBox();
            }
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
            lblRemainingBudget.Text = "$" + departmentSupervisor.Department.getRemainingBudget(ddlMonth.SelectedValue, ddlYear.SelectedValue);
            lblExpensesApproved.Text = "$" + departmentSupervisor.Department.TotalExpense(ddlMonth.SelectedValue, ddlYear.SelectedValue);
        }

        private void showAllReports()
        {
            Department department = departmentSupervisor.Department;
            List<Report> reports = department.getDepartmentReports(ddlMonth.SelectedValue, ddlYear.SelectedValue); 
            foreach (Report report in reports)
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
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
            switch (radioButtonReportFilter.SelectedIndex)
            {
                case 0: showAllReports(); break;
                case 1: showReports("Pending Reports", Report.ReportStatuses.SubmittedByConsultant.ToString()); break;
                case 2: showReports("Rejected Reports", Report.ReportStatuses.RejectedByAccountStaff.ToString()); break;
                default: break;
            }
        }

        private void showReports(string text, string status)
        {
            Department department = departmentSupervisor.Department;
            List<Report> reports = department.getDepartmentReports(ddlMonth.SelectedValue, ddlYear.SelectedValue, status);

            foreach (Report report in reports)
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showPendingReports()
        {
            Department department = departmentSupervisor.Department;
            List<Report> reports = department.getDepartmentReports(ddlMonth.SelectedValue, ddlYear.SelectedValue, Report.ReportStatuses.SubmittedByConsultant.ToString());
            foreach (Report report in reports)
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        private void showRejectedByAccountStaffReports()
        {
            Department department = departmentSupervisor.Department;
            List<Report> reports = department.getDepartmentReports(ddlMonth.SelectedValue, ddlYear.SelectedValue, Report.ReportStatuses.SubmittedByConsultant.ToString());
            
            foreach (Report report in reports)
            {
                listBoxReports.Items.Add(report.PrintReport());
            }
        }

        protected void btnViewReport_Click(object sender, EventArgs e)
        {
            if (listBoxReports.SelectedItem != null)
            {
                string selectedReport = listBoxReports.SelectedItem.Value;
                string reportID = selectedReport.Substring(0, selectedReport.IndexOf(","));

                Report report = new Report(reportID);
                Session["Report"] = report;
                Session["Department Supervisor"] = departmentSupervisor;

                Response.Write("<script language='javascript'> window.open('ViewReport.aspx'); </script>");
            }
        }
    }
}