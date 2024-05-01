using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Admin_Review : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Admin_id"] == null)
            {
                Response.Redirect("AdminLogin.aspx");

            }
            if (!IsPostBack)
            {
                Guides();

                string selectedGuideId = GuideName.SelectedValue;
                string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Declare and instantiate the SqlCommand
                    using (SqlCommand command = new SqlCommand())
                    {
                        command.Connection = connection;

                        // Use parameters to prevent SQL injection
                        string query = "SELECT * FROM GuideReviews WHERE Guide_name = @Guide_name";
                        command.Parameters.AddWithValue("@Guide_name", selectedGuideId);
                        command.CommandText = query;

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            rptGuides.DataSource = reader;
                            rptGuides.DataBind();
                        }
                    }
                }

                /* image and data*/
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT GuideId, Guide_FirstName, Guide_LastName, Guide_Education, Guide_Age, Guide_Contact, Guide_Description, Guide_Image, CONCAT(Guide_FirstName, ' ', Guide_LastName) AS GuideName FROM GuideInfo WHERE  CONCAT(Guide_FirstName, ' ', Guide_LastName) = @GuideName;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Connection = connection;
                        command.Parameters.AddWithValue("@GuideName", selectedGuideId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Repeater1.DataSource = reader;
                            Repeater1.DataBind();
                        }
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



        private void Guides()
        {
            using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
            {
                conn.Open();
                string query = "SELECT GuideId, CONCAT(Guide_FirstName, ' ', Guide_LastName) AS GuideName FROM GuideInfo  where GuideId <> 0";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        GuideName.DataSource = reader;
                        GuideName.DataTextField = "GuideName";

                        GuideName.DataBind();
                    }
                }
            }

        }


        protected void GuideName_SelectedIndexChanged(object sender, EventArgs e)
        {

            // Get the selected value from the DropDownList
            string selectedGuideId = GuideName.SelectedValue;



            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Declare and instantiate the SqlCommand
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;

                    // Use parameters to prevent SQL injection
                    string query = "SELECT * FROM GuideReviews WHERE Guide_name = @Guide_name";
                    command.Parameters.AddWithValue("@Guide_name", selectedGuideId);
                    command.CommandText = query;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        rptGuides.DataSource = reader;
                        rptGuides.DataBind();
                    }
                }
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT GuideId, Guide_FirstName, Guide_LastName, Guide_Education, Guide_Age, Guide_Contact, Guide_Description, Guide_Image, CONCAT(Guide_FirstName, ' ', Guide_LastName) AS GuideName FROM GuideInfo WHERE  CONCAT(Guide_FirstName, ' ', Guide_LastName) = @GuideName;";

                using (SqlCommand command = new SqlCommand(query, connection))
                {

                    command.Connection = connection;
                    command.Parameters.AddWithValue("@GuideName", selectedGuideId);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Repeater1.DataSource = reader;
                        Repeater1.DataBind();
                    }
                }
            }
        }





        protected void Delete_Review(object sender, EventArgs e)
        {
            string selectedGuideId = GuideName.SelectedValue;

            if (string.IsNullOrEmpty(txt_Review.Text))
            {
                string nullscript = "alert('to update please fill in the required field');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ReviewUpdateScript", nullscript, true);

            }

            else
            {


                SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                conn.Open();



                SqlCommand cmd = new SqlCommand("delete from GuideReviews where UserId=@UserId and Guide_name=@Guide_name", conn);
                cmd.Parameters.AddWithValue("@UserId", txt_Review.Text);
                cmd.Parameters.AddWithValue("@Guide_name", GuideName.SelectedValue);


                cmd.ExecuteNonQuery();

                conn.Close();


                string script = "alert('deleted ');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ReviewUpdateScript", script, true);


                cleartext();

                void cleartext()
                {
                    txt_Review.Text = "";

                }

            }

        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("admin_panel.aspx");
        }

        protected void reload(object sender, EventArgs e)
        {
            Response.Redirect(Request.RawUrl);

        }

    }
}