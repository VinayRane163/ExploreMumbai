using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace ExploreMumbai
{
    public partial class AdminLogin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtUsername.Text) || string.IsNullOrWhiteSpace(TxtPassword.Text))
            {
                string script = "showFlashMessage('Please enter both Admin Name and password.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "EmptyFieldsScript", script, true);
                return;
            }

            SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("select * from AdminInfo where Admin_id=@Admin_id and Admin_password=@Admin_password", conn);
            cmd.Parameters.AddWithValue("@Admin_id", TxtUsername.Text);
            cmd.Parameters.AddWithValue("@Admin_password", TxtPassword.Text);

            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds, "AdminInfo");

            if (ds.Tables["AdminInfo"].Rows.Count == 0)
            {
                string script = "showFlashMessage('Invalid User or Password');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "InvalidUserScript", script, true);
            }
            else
            {
                Session.Timeout = 60;
                Session["session_id"] = Session.SessionID;
                Session["Admin_id"] = TxtUsername.Text;
                Response.Redirect("Admin_Panel.aspx");
            }
        }



    }
}