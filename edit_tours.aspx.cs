using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class edit_tours : System.Web.UI.Page
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
                string query = "SELECT * from ToursInfo ORDER BY Tour_Id ";
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

        /*  protected void BtnSelect_Click(object sender, EventArgs e)
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
                   SqlCommand cmd = new SqlCommand("select * from ToursInfo where Tour_Id=@Tour_Id ", conn);
                   cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));

                   SqlDataReader reader = cmd.ExecuteReader();

                   // Display  details
                   if (reader.Read())
                   {
                       Tour_Name.Text = reader["Tour_Name"].ToString();
                       Tour_Price.Text = reader["Tour_Price"].ToString();
                       Tour_Description.Text = reader["Tour_Description"].ToString();

                       TourDetails.InnerHtml = "";
                   }
                   else
                   {
                       TourDetails.InnerHtml = "Tour not found";
                   }
               }
           }
        */
        protected void BtnAdd_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_tours.aspx");
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
                SqlCommand cmd = new SqlCommand("DELETE FROM ToursInfo WHERE Tour_Id = @Tour_Id", conn);
                cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                cmd.ExecuteNonQuery();
                conn.Close();
                string errorScript = "alert('pack deleted');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationErrorScript", errorScript, true);
                Response.Redirect(Request.RawUrl);

            }
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            int t_id = Convert.ToInt32(TourId.Text);

            if (string.IsNullOrEmpty(TourId.Text))
            {
                string errorScript = "alert('Please fill in all the required fields.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationErrorScript", errorScript, true);
            }
            else if (string.IsNullOrEmpty(Tour_Name.Text) && string.IsNullOrEmpty(Tour_Price.Text))
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET  Tour_Description=@Tour_Description WHERE Tour_Id=@Tour_Id", conn);
                    cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                    cmd.Parameters.AddWithValue("@Tour_Description", Tour_Description.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string successScript = "alert('Updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);

                    Response.Redirect(Request.RawUrl);
                }
            }
            else if (string.IsNullOrEmpty(Tour_Description.Text) && string.IsNullOrEmpty(Tour_Price.Text))
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET Tour_Name=@Tour_Name WHERE Tour_Id=@Tour_Id", conn);
                    cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                    cmd.Parameters.AddWithValue("@Tour_Name", Tour_Name.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string successScript = "alert('Updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);

                    Response.Redirect(Request.RawUrl);
                }
            }
            else if (string.IsNullOrEmpty(Tour_Name.Text) && string.IsNullOrEmpty(Tour_Description.Text))
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET Tour_Price=@Tour_Price WHERE Tour_Id=@Tour_Id", conn);
                    cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                    cmd.Parameters.AddWithValue("@Tour_Price", Convert.ToInt32(Tour_Price.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string successScript = "alert('Updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);

                    Response.Redirect(Request.RawUrl);
                }
            }
            else if (string.IsNullOrEmpty(Tour_Description.Text))
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET Tour_Name=@Tour_Name, Tour_Price=@Tour_Price WHERE Tour_Id=@Tour_Id", conn);
                    cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                    cmd.Parameters.AddWithValue("@Tour_Name", Tour_Name.Text);
                    cmd.Parameters.AddWithValue("@Tour_Price", Convert.ToInt32(Tour_Price.Text));

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string successScript = "alert('Updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);


                    Response.Redirect(Request.RawUrl);
                }
            }

            else if (string.IsNullOrEmpty(Tour_Price.Text))
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET Tour_Name=@Tour_Name, Tour_Description=@Tour_Description WHERE Tour_Id=@Tour_Id", conn);
                    cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                    cmd.Parameters.AddWithValue("@Tour_Name", Tour_Name.Text);
                    cmd.Parameters.AddWithValue("@Tour_Description", Tour_Description.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string successScript = "alert('Updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);

                    Response.Redirect(Request.RawUrl);
                }
            }
            else if (string.IsNullOrEmpty(Tour_Name.Text))
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET  Tour_Price=@Tour_Price, Tour_Description=@Tour_Description WHERE Tour_Id=@Tour_Id", conn);
                    cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                    cmd.Parameters.AddWithValue("@Tour_Price", Convert.ToInt32(Tour_Price.Text));
                    cmd.Parameters.AddWithValue("@Tour_Description", Tour_Description.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string successScript = "alert('Updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);

                    Response.Redirect(Request.RawUrl);
                }
            }

            else
            {
                using (SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True"))
                {
                    SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET Tour_Name=@Tour_Name, Tour_Price=@Tour_Price, Tour_Description=@Tour_Description WHERE Tour_Id=@Tour_Id", conn);
                    cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
                    cmd.Parameters.AddWithValue("@Tour_Name", Tour_Name.Text);
                    cmd.Parameters.AddWithValue("@Tour_Price", Convert.ToInt32(Tour_Price.Text));
                    cmd.Parameters.AddWithValue("@Tour_Description", Tour_Description.Text);

                    conn.Open();
                    cmd.ExecuteNonQuery();

                    string successScript = "alert('Updated successfully.');";
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);

                    Response.Redirect(Request.RawUrl);
                }
            }
        }

        protected void BtnBack_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin_Panel.aspx");
        }
    }
}