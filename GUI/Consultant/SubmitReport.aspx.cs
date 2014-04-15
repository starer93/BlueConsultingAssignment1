using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.Consultant
{
    public partial class SubmitReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmitReport_Click(object sender, EventArgs e)
        {
            //get dtats from the form and store in DB
            Report report = new Report(User.Identity.Name, "SubmittedByConsultant", null );
            //report.addReport();
            //BlueConsultingBusinessLogic.DatabaseAccess.insertReportToDatabase(report);

        }

        protected void btnBack_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(typeof(Page), "closePage", "window.close();", true);
        }
    }
}