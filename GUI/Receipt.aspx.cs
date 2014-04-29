using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Drawing;

namespace GUI
{
    public partial class Receipts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Receipt"] != null)
            {
                byte[] receipt = (byte[])Session["Receipt"];

                Response.ContentType = "application/pdf";
                Response.AddHeader("content-length", receipt.Length.ToString());
                Response.BinaryWrite(receipt);
            }

            

        }
    }
}