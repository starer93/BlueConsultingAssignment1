using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.DepartmentSupervisor
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        Report report;
        protected void Page_Load(object sender, EventArgs e)
        {
            report = (Report) Session["Report"];
            lblReportID.Text = report.ReportID;
        }
    }
}