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
        protected void Page_Load(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            String reportID = (String)Session["ReportID"];
            lblSelectedReportID.Text = reportID;

            if (consultant != null)
            {
                Report report = consultant.findReport(reportID);

                if (report != null)
                {
                    ShowExpensesInReport(report);
                }
            }
        }

        private void ShowExpensesInReport(Report report)
        {
            txtReportPreview.Text = String.Empty;
            report.LoadExpensesFromDB();
            List<Expense> expenses = report.GetExpenses();

            foreach (Expense expense in expenses)
            {
                txtReportPreview.Text += expense.PrintExpense();
            }
        }

        protected void btnClose_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }

        protected void btnViewReceipt_Click(object sender, EventArgs e)
        {
            ConsultantLogic consultant = (ConsultantLogic)Session["Consultant"];
            String reportID = (String)Session["ReportID"];

            string connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            var connection = new SqlConnection(connectionString);

            connection.Open();

            SqlCommand command = new SqlCommand("SELECT Receipt FROM Reports WHERE Id = @ReportID", connection);
            command.Parameters.Add("@ReportID", SqlDbType.VarChar).Value = reportID;

            SqlDataReader dr = command.ExecuteReader(System.Data.CommandBehavior.Default);

            String destination = Server.MapPath("~\\Report.pdf");

            if (dr.Read())
            {
                byte[] receipt = (byte[])dr.GetValue(0);

                FileStream fs = new FileStream(destination, FileMode.Create, FileAccess.ReadWrite);

                BinaryWriter bw = new BinaryWriter(fs);

                bw.Write(receipt);
                bw.Close();

            }

            dr.Close();
            Response.Redirect("~\\Report.pdf");


            //open file from database
        }

       
    }
}