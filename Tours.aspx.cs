using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Tours : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {/*
            if (Session["session_id"] == null)
            {

                ///Response.Redirect("Login.aspx");

                string successScript = "if (confirm('Need to Login')) { window.location.href = 'login.aspx'; } else { setTimeout(function(){ window.location.href = 'login.aspx'; }, 000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
            }
            else
            {*/

            
                // Fetch all tours from the database
                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                
                        connection.Open();
                        string query = "SELECT Tour_Id, Tour_Name, Tour_Price, Tour_Description, Tour_Image FROM ToursInfo";
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                rptGuides.DataSource = reader;
                                rptGuides.DataBind();
                            }
                        }
                
               
                        if (connection.State == System.Data.ConnectionState.Open)
                        {
                            connection.Close();
                        }
                
                }
         
            }
      //  }

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
