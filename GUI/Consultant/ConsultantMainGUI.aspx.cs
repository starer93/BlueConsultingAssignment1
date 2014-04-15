using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;
using BlueConsultingBusinessLogic.ReportDataSetTableAdapters;
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

            List<Report> reports = new List<Report>();

            //var connectionString = ConfigurationManager.ConnectionStrings["LocalSqlServer"].ConnectionString;
            //var connection = new SqlConnection(connectionString);
            //var selectCommand = new SqlCommand("Select * From Reports where ConsultantID LIKE @id", connection);
            //var adapter = new SqlDataAdapter(selectCommand);

            //selectCommand.Parameters.Add("@Id", SqlDbType.VarChar).Value = "%" + User.Identity.Name + "%";

            //var resultSet = new DataSet();
            //adapter.Fill(resultSet);

            //GridView1.DataSource = resultSet;
            //GridView1.DataBind();

            DatabaseAccess database = new DatabaseAccess();
            ReportDataSet reportDataSet = database.getReportDataSet(User.Identity.Name);
            var table = new ReportsTableAdapter().GetData();
            GridView1.DataSource = table;
            GridView1.DataBind();
            //connection.Close();
            //if(User.IsInRole

        }

        protected void btnCreateReport_Click(object sender, EventArgs e)
        {
            Response.Write(" <script language='javascript'> window.open('SubmitReport.aspx','','width=500,Height=500,fullscreen=0,location=0,scrollbars=1,menubar=1,toolbar=1'); </script>"); ;
        }

        protected void btnShowReport_Click(object sender, EventArgs e)
        {



        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");

        }

    }
}