using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }

        protected void BtnSelect_Click(object sender, EventArgs e)
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

        protected void BtnDelete_Click(object sender, EventArgs e)
        {

            SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand("DELETE FROM ToursInfo WHERE Tour_Id = @Tour_Id", conn);
            cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        protected void BtnUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection conn = new SqlConnection("Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True");
            SqlCommand cmd = new SqlCommand("UPDATE ToursInfo SET Tour_Name=@Tour_Name, Tour_Price=@Tour_Price, Tour_Description=@Tour_Description WHERE Tour_Id=@Tour_Id", conn);
            cmd.Parameters.AddWithValue("@Tour_Id", Convert.ToInt32(TourId.Text));
            cmd.Parameters.AddWithValue("@Tour_Name", Tour_Name.Text);
            cmd.Parameters.AddWithValue("@Tour_Price", Tour_Price.Text);
            cmd.Parameters.AddWithValue("@Tour_Description", Tour_Description.Text);

            conn.Open();
            cmd.ExecuteNonQuery();
            int rowsAffected = cmd.ExecuteNonQuery();

            if (rowsAffected > 0)
            {
                TourDetails.InnerHtml = "Tour details updated successfully";
                Tour_Name.Text = "";
                TourId.Text = "";
                Tour_Price.Text = "";
                Tour_Description.Text = "";
            }
            else 
            {
                TourDetails.InnerHtml = "Failed to update tour details";
            }
            conn.Close();



            string successScript = "alert('updated succesfully');";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationSuccessScript", successScript, true);
        }
    }
}