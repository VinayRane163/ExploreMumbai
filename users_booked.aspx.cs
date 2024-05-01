using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class users_booked : System.Web.UI.Page
    {
        string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session_id"] == null)
            {

                ///Response.Redirect("Login.aspx");

                string successScript = "if (confirm('Need to Login')) { window.location.href = 'login.aspx'; } else { setTimeout(function(){ window.location.href = 'login.aspx'; }, 000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }
            else
            {
               
                    
                    string userid = Session["User_id"].ToString();
                    SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                    conn.Open();
                 /*   SqlCommand cmd = new SqlCommand("select * from booking where User_id=@User_id ", conn);
                 ////////   c/md.Parameters.AddWithValue("@User_id", userid);*/



                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "SELECT * from booking where User_id=@User_id ORDER BY BookingID";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                        command.Parameters.AddWithValue("@User_id", userid);
                         
                        using (SqlDataReader reader = command.ExecuteReader())
                            {
                                rptGuides.DataSource = reader;
                                rptGuides.DataBind();
                            }
                        }
                    }
                
            }
        }
    }
}