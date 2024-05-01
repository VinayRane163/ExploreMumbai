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
    public partial class Reviews : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * from Reviews ";
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

        protected void Add_Review(object sender, EventArgs e)
        {
            if (Session["session_id"] == null)
            {
                Response.Redirect("Login.aspx");

            }

            if (string.IsNullOrWhiteSpace(txt_Review.Text))
            {
                string script = "alert('are u comedy');";
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

                SqlCommand uname = new SqlCommand("SELECT User_Name FROM UserInfo WHERE User_id = @userid", conn);
                uname.Parameters.AddWithValue("@userid", userid);

                // Execute the query to get the username
                string username = uname.ExecuteScalar() as string;

                SqlCommand cmd = new SqlCommand("INSERT INTO Reviews (username, review,userid) VALUES (@username, @review,@userid)", conn);
                cmd.Parameters.AddWithValue("@review", txt_Review.Text);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userid", userid);

                cmd.ExecuteNonQuery();

                conn.Close();
                string script = "alert('review added sucessfully');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ReviewUpdateScript", script, true);
                cleartext();
                Response.Redirect(Request.RawUrl);


                Response.Redirect(Request.RawUrl);

                void cleartext()
                {
                    txt_Review.Text = "";
                }
            }

        }

        private bool ReviewExist()
        {
            string userid = Session["User_id"].ToString();
            SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Reviews WHERE userid = @userid", conn);
            cmd.Parameters.AddWithValue("@userid", userid);
            conn.Open();
            int count = (int)cmd.ExecuteScalar();
            conn.Close();

            return count > 0;


        }

        protected void back(object sender, EventArgs e)
        {
            Response.Redirect("Home.aspx");
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

                string userid = Session["User_id"].ToString();

                SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
                conn.Open();

                SqlCommand uname = new SqlCommand("SELECT User_Name FROM UserInfo WHERE User_id = @userid", conn);
                uname.Parameters.AddWithValue("@userid", userid);

                string username = uname.ExecuteScalar() as string;

                SqlCommand cmd = new SqlCommand("Update  Reviews set review=@review where userid=@userid ", conn);
                cmd.Parameters.AddWithValue("@review", txt_Review.Text);
                cmd.Parameters.AddWithValue("@username", username);
                cmd.Parameters.AddWithValue("@userid", userid);

                cmd.ExecuteNonQuery();

                conn.Close();
                Response.Redirect(Request.RawUrl);



                cleartext();
                Response.Redirect(Request.RawUrl);

                void cleartext()
                {
                    txt_Review.Text = "";
                }
            }
        }
    }
}