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
            if (Session["session_id"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            // Fetch all guides from the database
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT GuideId, Guide_FirstName, Guide_LastName, Guide_Education, Guide_Age, Guide_Contact, Guide_Description, Guide_Image FROM GuideInfo";
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
