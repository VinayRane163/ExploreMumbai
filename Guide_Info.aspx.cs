using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace ExploreMumbai
{
    public partial class Guide_Info : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           // if (Session["session_id"] == null)
       //     {

         //       string successScript = "if (confirm('Need to Login')) { window.location.href = 'login.aspx'; } else { setTimeout(function(){ window.location.href = 'login.aspx'; }, 000); };";
             //   ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
        //    }
       //     else
       //     {



                // Fetch all guides from the database
                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT GuideId, Guide_FirstName, Guide_LastName, Guide_Education, Guide_Age, Guide_Contact, Guide_Description, Guide_Image FROM GuideInfo WHERE GuideId <> 0";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            rptGuides.DataSource = reader;
                            rptGuides.DataBind();
                        }
                    }
                }
            }
     //   }

        protected string GetBase64Image(object imageData)
        {
            if (imageData != DBNull.Value)
            {
                byte[] bytes = (byte[])imageData;
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
            return string.Empty;
        }

       
    }
}
