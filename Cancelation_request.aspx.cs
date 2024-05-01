using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace ExploreMumbai
{
    public partial class Cancelation_request : System.Web.UI.Page
    {
        string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["User_id"] == null)
            {
                Response.Redirect("Login.aspx");

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

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string connectionString = "Server=LAPTOP-TAP8U6AD\\SQLEXPRESS;Database=ExploreMumbai;Trusted_Connection=True";

            if (!BookingIdExists(txtBookingID.Text, connectionString))
            {
                string errorScript = "alert('BookingID not present or already deleted.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "ErrorScript", errorScript, true);
                return;
            }
            if (string.IsNullOrEmpty(txtBookingID.Text) ||
            string.IsNullOrEmpty(txtReason.Text))
            {
                string errorScript = "alert('Please fill/select in all the required fields.');";
                ScriptManager.RegisterStartupScript(this, this.GetType(), "RegistrationErrorScript", errorScript, true);
                return;
            }
            else
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO cancelaton_request (BookingID, Reason) VALUES (@BookingID, @Reason)", conn))
                    {
                        cmd.Parameters.AddWithValue("@BookingID", txtBookingID.Text);
                        cmd.Parameters.AddWithValue("@Reason", txtReason.Text);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                        conn.Close();

                        cleartext();

                        // Show success message
                        string successScript = "alert('Request sent successfully.');";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "SuccessScript", successScript, true);
                    }
                }
            }
        }

        protected void btnBACK_Click(object sender, EventArgs e)
        {
            Response.Redirect("home.aspx");
        }
        private bool BookingIdExists(string bookingId, string connectionString)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM booking WHERE BookingID = @BookingID", conn))
                {
                    cmd.Parameters.AddWithValue("@BookingID", bookingId);

                    conn.Open();
                    int count = (int)cmd.ExecuteScalar();
                    conn.Close();

                    return count > 0;
                }
            }
        }

        private void cleartext()
        {
            txtBookingID.Text = "";
            txtReason.Text = "";
        }
    }
}
