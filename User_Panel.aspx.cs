using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class User_Panel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session_id"] == null)
            {
                Response.Redirect("Login.aspx");

            }
            string userId = Session["User_id"].ToString();
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * from UserInfo where User_id = @User_id";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@User_id", userId);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        rptGuides.DataSource = reader;
                        rptGuides.DataBind();
                    }
                }
            }
        }
        protected void BtnLogout_Click(object sender, EventArgs e)
        {           
            Session["session_id"] = null;
            Response.Redirect("Login.aspx");

        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
        }

        protected void CNG_Password_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangePassword.aspx");
        }

        protected void CNG_INFO_Click(object sender, EventArgs e)
        {
            Response.Redirect("ChangeUserInfo.aspx");
        }
    }
}