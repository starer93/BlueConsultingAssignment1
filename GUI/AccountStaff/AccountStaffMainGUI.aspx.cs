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
        DataTable dataTable;
        List<Report> reports;

        protected void Page_Load(object sender, EventArgs e)
        {
            initData();
            if (!IsPostBack) //if page loads for the first time
            {
                fillListBox();
                ListBoxReport.SelectedIndex = 0;
                fillListExpense(0);
            }
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
            ListBoxReport.Items.Clear();
            foreach (Report report in reports)
            {
                ListBoxReport.Items.Add(report.ReportID);
            }
        }

        private void fillListExpense(int index)
        {
            if (ListBoxReport.SelectedIndex != -1)
            {
                Report currentReport = reports.ElementAt(index);
                List<Expense> expenses = new List<Expense>();
                expenses = currentReport.GetExpenses();
                updateExpense(expenses);
            }
        }

        private void initData()
        {
            reports = accountStaff.getReports();
            dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("amount");
            dataTable.Columns.Add("description");
            dataTable.Columns.Add("location");
            dataTable.Columns.Add("currency");
        }

        protected void ListBoxReport_SelectedIndexChanged(object sender, EventArgs e)
        {
            updateTable(ListBoxReport.SelectedItem.ToString());
        }

        private void updateTable(string reportID)
        {
            List<Expense> expenses = new List<Expense>();
            foreach (Report report in reports)
            {
                if (report.ReportID.Equals(reportID))
                {
                    expenses = report.GetExpenses();
                }
            }
            updateExpense(expenses);
        }

        private void updateExpense(List<Expense> expenses)
        {
            int index = 1;
            foreach (Expense expense in expenses)
            {
                dataTable.Rows.Add(index, expense.Amount, expense.Description, expense.Location, expense.Currency);
                index++;
            }
            ListViewReport.DataSource = dataTable;
            ListViewReport.DataBind();
        }

    }
}