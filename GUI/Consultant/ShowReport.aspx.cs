using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BlueConsultingBusinessLogic;

namespace GUI.Consultant
{
    public partial class ShowReport : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String reportID = (String)Session["ReportID"];
            List<Report> reports = (List<Report>)Session["Reports"];
            List<Expense> expenses = new List<Expense>();

            //foreach (Report report in reports)
            //{
            //    if (report.ReportID == reportID)
            //    {
            //        expenses = report.GetExpensesFromDB();

            //        foreach (Expense expense in expenses)
            //        {
            //            ListBox1.Items.Add(expense.GetExpense());

            //        }

            //    }
            //}


 
        }

        protected void btnBack_Click(object sender, EventArgs e)
        {

        }        
    }
}