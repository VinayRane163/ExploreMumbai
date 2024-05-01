using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class thankyou : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            string redirectScript = "setTimeout(function(){ window.location.href = 'home.aspx'; }, 2500);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RedirectScript", redirectScript, true);

        }
    }
}