using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BlueConsultingBusinessLogic;

namespace GUI.Account_Staff
{
    public partial class AccountStaffMainGUI : System.Web.UI.Page
    {
        AccountStaffLogic accountStaff = new AccountStaffLogic();
        List<Report> reports;
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dataTable = new DataTable();
            fillListBox();
            fillListExpense();
            Response.Write("Page Loaded");
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            Chart1.Titles.Add("Monthly Budget");
            string seriesName = "Budget";
            Chart1.Series.Add(seriesName);
            Chart1.Series[seriesName].BorderWidth = 2;
            List<DepartmentSupervisorLogic> supervisors = accountStaff.getSupervisor();

            foreach (DepartmentSupervisorLogic supervisor in supervisors)
            {
                string columnName = supervisor.Username;
                double YValue = supervisor.getApproveAmount();
                Chart1.Series[seriesName].Points.AddXY(columnName, YValue);
            }

        }

        private void fillListBox()
        {
            reports = accountStaff.getReports();
            foreach(Report report in reports)
            {
                ListBoxReport.Items.Add(report.ReportID);
            }
            if (reports.Count > 0)
            {
                ListBoxReport.SelectedIndex = 0;
            }
        }

        private void fillListExpense()
        {
            if (ListBoxReport.SelectedIndex != -1)
            {
                int reportIndex = ListBoxReport.SelectedIndex;
                Report currentReport = reports.ElementAt(reportIndex);
                DataTable dataTable = new DataTable();
                dataTable.Columns.Add("ID");
                dataTable.Columns.Add("amount");
                dataTable.Columns.Add("description");
                dataTable.Columns.Add("location");
                dataTable.Columns.Add("currency");
                List<Expense> expenses = new List<Expense>();
                expenses = currentReport.GetExpenses();
                foreach (Expense expense in expenses)
                {
                    dataTable.Rows.Add("1", expense.Amount, expense.Description, expense.Location, expense.Currency);
                }
                ListViewReport.DataSource = dataTable;
                ListViewReport.DataBind();
            }
        }

        private void fillDataTable()
        {
            DataTable dataTable = new DataTable();
        }

    }
}