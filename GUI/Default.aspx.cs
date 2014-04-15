using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace GUI
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (User.IsInRole("Consultant"))
            {
                Response.Redirect("Consultant/ConsultantMainGUI.aspx");

            }
            else if (User.IsInRole("Department Supervisor"))
            {
                Response.Redirect("DepartmentSupervisor/DepartmentSupervisorMainGUI.aspx");

            }
            else if (User.IsInRole("Account Staff"))
            {
                Response.Redirect("AccountStaff/AccountStaffMainGUI.aspx");

            }
        }
    }
}