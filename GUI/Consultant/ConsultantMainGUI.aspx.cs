using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
namespace GUI.Consultant
{
    public partial class ConsultantMainGUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            //update the date time using session?
            labelDate.Text = DateTime.Now.ToString();

            DatabaseAccess database = new DatabaseAccess();
            DataTable reportDataSet = database.getReportDataTable(User.Identity.Name);

            ConsultantLogic consultant = new ConsultantLogic(User.Identity.Name);
            List<Report> reports = consultant.loadAllReports();

            foreach (Report report in reports)
            {
                listboxReports.Items.Add(report.ReportID);
            }

            if (listboxReports.SelectedItem != null)
            {
                Session["ReportID"] = listboxReports.SelectedItem.ToString();
                Session["Reports"] = reports;
            }
            //GridView1.DataSource = reportDataSet;
            //GridView1.DataBind();
        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            Response.Write(" <script language='javascript'> window.open('SubmitReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>"); ;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {
            Response.Write(" <script language='javascript'> window.open('ShowReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>"); ;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");

        }

    }
}