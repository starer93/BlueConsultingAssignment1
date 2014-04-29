using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BlueConsultingBusinessLogic;
using System.Drawing;

namespace GUI.Account_Staff
{
    public partial class AccountStaffMainGUI : System.Web.UI.Page
    {
        private AccountStaffLogic accountStaff = new AccountStaffLogic();
        private DataTable dataTable;
        private List<Report> reports;
        private string month, year;

        protected void Page_Load(object sender, EventArgs e)
        {
            initData();
            if (!IsPostBack) //if page loads for the first time
            {
                fillReportId();
                loadReportDropBox();
            }
        }
        private void initData()
        {
            reports = accountStaff.getReports();
            month = DateTime.Now.ToString("MM");
            year = DateTime.Now.ToString("yyyy");
            dataTable = new DataTable();
            dataTable.Columns.Add("ID");
            dataTable.Columns.Add("amount");
            dataTable.Columns.Add("description");
            dataTable.Columns.Add("location");
            dataTable.Columns.Add("currency");
        }

        private void fillReportId()
        {
            foreach (Report report in reports)
            {
                ListBoxReport.Items.Add(report.ReportID);
            }
        }

        private void loadReportDropBox()
        {
            List<Report> submitReports = accountStaff.getReports();
            List<string> months = getListItems(submitReports, 7, 2);
            List<string> years = getListItems(submitReports, 4, 4);
            foreach (string month in months)
            {
                DropDownListMonthReport.Items.Add(new ListItem(month));
            }
            foreach (string year in years)
            {
                DropDownListYearReport.Items.Add(new ListItem(year));
            }
        }

        private List<string> getListItems(List<Report> submitReports, int x, int y)
        {
            List<string> listItems = new List<string>();
            foreach (Report report in submitReports)
            {
                string date = report.Date;
                string month = date.Substring(date.Length - x, y);
                if (listItems.Count == 0 || !isExist(listItems, month))
                {
                    listItems.Add(month);
                }
            }
            return listItems;
        }

        private Boolean isExist(List<string> list, string input)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list.ElementAt(i).Equals(input))
                {
                    return true;
                }
            }
            return false;
        }

        protected void Chart1_Load(object sender, EventArgs e)
        {
            Chart1.Titles.Add("Monthly Budget - Supervisor");
            string seriesName = "Budget";
            Chart1.Series.Add(seriesName);
            Chart1.Series[seriesName].BorderWidth = 2;
            Chart1.Series[seriesName].IsValueShownAsLabel = true;
            Chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            Chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;
            List<DepartmentSupervisorLogic> supervisors = accountStaff.getSupervisor();

            foreach (DepartmentSupervisorLogic supervisor in supervisors)
            {
                string columnName = supervisor.Username;
                double YValue = supervisor.getApproveAmount();
                Chart1.Series[seriesName].Points.AddXY(columnName, YValue);
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

        private void updateReport(string reportID)
        {
            Report selectedReport = new Report();
            foreach (Report report in reports)
            {
                if (report.ReportID.Equals(reportID))
                {
                    LabelAmount.Text = report.getTotalReportAmount().ToString();
                    LabelDate.Text = report.Date;
                    selectedReport = report;
                }
            }

            if (isOverBudget(selectedReport))
            {
                Panel2.BackColor = Color.Red;
            }
            else
            {
                Panel2.BackColor = Color.White;
            }
        }

        private Boolean isOverBudget(Report report)
        {
            string supverId = report.DepartmentSupervisorID;
            DepartmentSupervisorLogic temp = new DepartmentSupervisorLogic(supverId);
            Department department = temp.Department;
            string month = DropDownListMonthReport.SelectedValue.ToString();
            string year = DropDownListYearReport.SelectedValue.ToString();
            return department.getRemainingBudget(month, year) < report.calculateExpenseInAUD();
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
            ListViewExpense.DataSource = dataTable;
            ListViewExpense.DataBind();
        }

        protected void ChartTotal_Load(object sender, EventArgs e)
        {
            ChartTotal.Titles.Add("Monthly Budget - Company");
            string seriesName = "CompanyBudget";
            ChartTotal.Series.Add(seriesName);
            ChartTotal.Series[seriesName].BorderWidth = 2;
            ChartTotal.Series[seriesName].IsValueShownAsLabel = true;
            ChartTotal.ChartAreas["ChartArea2"].AxisX.MajorGrid.Enabled = false;
            ChartTotal.ChartAreas["ChartArea2"].AxisY.MajorGrid.Enabled = false;
            List<Department> departments = accountStaff.getDepartments();
            double totalApprovedBudget = 0;
            foreach (Department department in departments)
            {
                string columnName = department.Name;
                double YValue = department.getTotalExpense();
                totalApprovedBudget += YValue;
                ChartTotal.Series[seriesName].Points.AddXY(columnName, YValue);
            }
            double remainBudget = 30000 - totalApprovedBudget;
            labRemainBudget.Text = "Remaining Monthly Budget: " + remainBudget;
        }

        protected void ButtonApprove_Click(object sender, EventArgs e)
        {
            string reportId = ListBoxReport.SelectedValue.ToString();
            accountStaff.update(reportId, Report.ReportStatuses.ApprovedByAccountStaff.ToString());
        }

        protected void ButtonReject_Click(object sender, EventArgs e)
        {
            string reportId = ListBoxReport.SelectedValue.ToString();
            accountStaff.update(reportId, Report.ReportStatuses.RejectedByAccountStaff.ToString());
        }

        protected void btnReceipt_Click(object sender, EventArgs e)
        {
            Report report = new Report(ListBoxReport.SelectedValue.ToString());
            byte[] receipt = report.Receipt;
            if (receipt != null)
            {
                Session["Receipt"] = receipt;
                Response.Write("<script language = 'javascript'> window.open('../Receipt.aspx'); </script>");
            }
            else
            {
                //
            }
        }

        protected void btnShow_Click(object sender, EventArgs e)
        {
            string selectedItem = ListBoxReport.SelectedItem.ToString();
            Session["Report"] = new Report(selectedItem);
            updateTable(selectedItem);
            updateReport(selectedItem);
        }
    }
}