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



            //    report = CreateReport(); //create report
            //    consultant.addReport(report);
        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            CreateReport();
            //enable expenses input fields
        }

        private void CreateReport()
        {
            Report report = (Report)Session["Report"];

            report.DepartmentSupervisorID = "";
            report.ConsultantID = User.Identity.Name;
            report.Date = lblDate.Text;
            report.ReportStatus = Report.ReportStatuses.SubmittedByConsultant.ToString();
            report.Receipt = GetReceipt(); 

            Session["Report"] = report; //update session
        }

        private byte[] GetReceipt()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            SqlConnection cn = new SqlConnection(connectionString);
            cn.Open();

            int length = fupReceipts.PostedFile.ContentLength;
            byte[] data = new byte[length];
            fupReceipts.PostedFile.InputStream.Read(data, 0, length);

            return data;
        }

        protected void btnAddExpense_Click(object sender, EventArgs e)
        {
            CreateExpense();
            Report report = (Report)Session["Report"];
            List<Expense> expenses = report.GetExpenses();

            foreach (Expense expense in expenses)
            {
                listboxExpenses.Items.Add(expense.PrintExpense());
            }
        }



        private void CreateExpense()
        {
            Report report = (Report)Session["Report"];

            String location = txtLocation.Text;
            String description = txtDescription.Text;
            Double amount = Convert.ToDouble(txtAmount.Text);
            String currency = listCurrency.SelectedItem.ToString();

            DatabaseAccess db = new DatabaseAccess();
            SqlCommand command = new SqlCommand("SELECT Id FROM Reports ORDER BY Id DESC");
            DataTable dt = db.getDataTable(command); //get last id in table
            
            int reportID = Convert.ToInt32(dt.Rows[0]["Id"].ToString()) + 1; //get largest value
            //need to check if user skips empty fields

            Expense expense = new Expense(location, description, amount, currency, reportID);
            
            report.AddExpense(expense);

            Session["Report"] = report;
        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            Report report = (Report)Session["Report"];

            if (consultant != null)
            {
                consultant.submitReportToDatabase(report);
            }
        }


    }
}