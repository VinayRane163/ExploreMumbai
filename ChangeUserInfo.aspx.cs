using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class ChangeUserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session_id"] == null)
            {
                Response.Redirect("Login.aspx");

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txt_UserName.Text) || string.IsNullOrWhiteSpace(txt_phonenumber.Text))
            {
                string successScript = "alert('UserName & Number please enter both');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
                return;
            }

            string userId = Session["User_id"].ToString();
            SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("UPDATE UserInfo SET User_Name = @User_Name ,User_mobile = @User_mobile  WHERE User_id = @User_id ;", conn);
            cmd.Parameters.AddWithValue("@User_id", userId);
            cmd.Parameters.AddWithValue("@User_Name", txt_UserName.Text);
            cmd.Parameters.AddWithValue("@User_mobile", txt_phonenumber.Text);

            conn.Open();

            int rowsAffected = cmd.ExecuteNonQuery();

            conn.Close();

            if (rowsAffected > 0)
            {
                string successScript = "alert('UserName & Number Changed Successfully');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }
            ClearTextboxes();

           void ClearTextboxes()
            {
                txt_UserName.Text = " ";
                txt_phonenumber.Text = " ";
            }

        }
    }
}