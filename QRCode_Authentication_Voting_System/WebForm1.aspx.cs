using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static QRCoder.PayloadGenerator;

namespace FingerPrint_Voting_Systen
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string a = "xyz@xyz";
            Session["id"] = a;
            string url;
            url = "vote.aspx";
            Response.Redirect(url);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}