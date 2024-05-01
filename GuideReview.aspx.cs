using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ExploreMumbai
{
    public partial class GuideReview : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["session_id"] == null)
            {


                ///Response.Redirect("Login.aspx");

                string successScript = "if (confirm('Need to Login')) { window.location.href = 'login.aspx'; } else { setTimeout(function(){ window.location.href = 'login.aspx'; }, 000); };";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
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

        protected void Add_Review(object sender, EventArgs e)
        {

            string selectedGuideId = GuideName.SelectedValue;

            if (Session["session_id"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (string.IsNullOrWhiteSpace(txt_Review.Text))
            {
                string script = "alert('empty review cant be added');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FReviewExistsScript", script, true);

                return;
            }

            if (ReviewExist())
            {
                string script = "alert('You already gave review, if you want you can update it');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "FReviewExistsScript", script, true);
                return;
            }
            else
            {


                string userid = Session["User_id"].ToString();

                SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                conn.Open();

                SqlCommand uname = new SqlCommand("SELECT User_Name FROM UserInfo WHERE User_id = @User_id", conn);
                uname.Parameters.AddWithValue("@User_id", userid);

                // Execute the query to get the username
                string username = uname.ExecuteScalar() as string;

                SqlCommand cmd = new SqlCommand("INSERT INTO GuideReviews (Username, Review,UserId ,Guide_name) VALUES (@Username, @Review,@UserId,@Guide_name)", conn);
                cmd.Parameters.AddWithValue("@Review", txt_Review.Text);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@Guide_name", selectedGuideId);

                cmd.Parameters.AddWithValue("@UserId", userid);

                cmd.ExecuteNonQuery();

                conn.Close();
                string script = "alert('Review added sucessfully');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ReviewUpdateScript", script, true);
                cleartext();
                Response.Redirect(Request.RawUrl);

                void cleartext()
                {
                    txt_Review.Text = "";
                }
            }
        }
        private bool ReviewExist()
        {
            string selectedGuideId = GuideName.SelectedValue;

            string userId = Session["User_id"]?.ToString();

            if (userId != null)
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    conn.Open();

                    // Check if a review already exists for the selected guide and user
                    SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM GuideReviews WHERE Guide_name  = @Guide_name  AND UserId = @UserId", conn);
                    cmd.Parameters.AddWithValue("@Guide_name ", selectedGuideId);
                    cmd.Parameters.AddWithValue("@UserId", userId);

                    int count = (int)cmd.ExecuteScalar();

                    return count > 0;
                }
            }

            return false; // User ID is not available
        }


        protected void Update_Review(object sender, EventArgs e)
        {   
                if (Session["session_id"] == null)
                {
                    Response.Redirect("Login.aspx");

                }
                if (string.IsNullOrEmpty(txt_Review.Text))
                {
                    string nullscript = "alert('to update please fill in the required field');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ReviewUpdateScript", nullscript, true);

                }

                else
                {
                    string selectedGuideId = GuideName.SelectedValue;

                    string userid = Session["User_id"].ToString();

                    SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                    conn.Open();

                    SqlCommand uname = new SqlCommand("SELECT User_Name FROM UserInfo WHERE User_id = @userid", conn);
                    uname.Parameters.AddWithValue("@userid", userid);

                    string username = uname.ExecuteScalar() as string;

                    SqlCommand cmd = new SqlCommand("Update  GuideReviews set Review=@Review where UserId=@UserId and Guide_name=@Guide_name", conn);
                    cmd.Parameters.AddWithValue("@Review", txt_Review.Text);
                    cmd.Parameters.AddWithValue("@Username", username);
                    cmd.Parameters.AddWithValue("@UserId", userid);
                    cmd.Parameters.AddWithValue("@Guide_name", selectedGuideId);

                    cmd.ExecuteNonQuery();

                    conn.Close();

                
               Response.Redirect(Request.RawUrl);


                    cleartext();

                    void cleartext()
                    {
                        txt_Review.Text = "";
                    
                    }

            }
            
        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }

        protected void reload(object sender, EventArgs e)
        {
           Response.Redirect(Request.RawUrl);

        }
    }
}


