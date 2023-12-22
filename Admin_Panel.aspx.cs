using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class Admin_Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if ( Session["Admin_id"]==null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
        }

        protected void BtnLogout_Click(object sender, EventArgs e)
        {
            Session["session_id"] = null;
            Session["Admin_id"] = null;
            Response.Redirect("AdminLogin.aspx");
        }
    }
}