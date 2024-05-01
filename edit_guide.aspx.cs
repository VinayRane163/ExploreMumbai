using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class edit_guide : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)    
        {
            if (Session["Admin_id"] == null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            string tourIdValue = TourId.Text;
            TourId.Text = tourIdValue;

            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open(); 
                string query = "SELECT * from GuideInfo ORDER BY GuideID ";
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

        

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
            {
                SqlCommand cmd = new SqlCommand("UPDATE GuideInfo SET " +
                                                "Guide_FirstName = ISNULL(NULLIF(@Guide_FirstName, ''), Guide_FirstName), " +
                                                "Guide_LastName = ISNULL(NULLIF(@Guide_LastName, ''), Guide_LastName), " +
                                                "Guide_Education = ISNULL(NULLIF(@Guide_Education, ''), Guide_Education), " +
                                                "Guide_Age = ISNULL(NULLIF(@Guide_Age, ''), Guide_Age), " +
                                                "Guide_Contact = ISNULL(NULLIF(@Guide_Contact, ''), Guide_Contact), " +
                                                "Guide_Description = ISNULL(NULLIF(@Guide_Description, ''), Guide_Description) " +
                                                "WHERE GuideID = @GuideID", conn);

                cmd.Parameters.AddWithValue("@GuideID", TourId.Text);
                cmd.Parameters.AddWithValue("@Guide_FirstName", FirstName.Text);
                cmd.Parameters.AddWithValue("@Guide_LastName", LastName.Text);
                cmd.Parameters.AddWithValue("@Guide_Education", GuideEducation.Text);
                cmd.Parameters.AddWithValue("@Guide_Age", GuideBirthDate.Text);
                cmd.Parameters.AddWithValue("@Guide_Contact", GuideContact.Text);
                cmd.Parameters.AddWithValue("@Guide_Description", GuideDescription.Text);

                conn.Open();
                cmd.ExecuteNonQuery();

                string successScript = "alert('Updated successfully.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);

                Response.Redirect(Request.RawUrl);
            }

        }


        protected void BtnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(TourId.Text))
            {
                string errorScript = "alert('Please fillin all the required fields.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationErrorScript", errorScript, true);
            }
            else
            {
                SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                conn.Open();
                SqlCommand cmd = new SqlCommand("DELETE FROM GuideInfo WHERE GuideID = @Tour_Id", conn);
                cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                cmd.ExecuteNonQuery();
                conn.Close();

                string errorScript = "alert('pack deleted');";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationErrorScript", errorScript, true);
                Response.Redirect(Request.RawUrl);

            }
        }

        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("guide_register.aspx");
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Panel.aspx");
        }
    }
}

